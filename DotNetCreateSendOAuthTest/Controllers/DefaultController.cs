using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using createsend_dotnet;
using System.Configuration;

namespace DotNetCreateSendOAuthTest.Controllers
{
    public class DefaultController : Controller
    {
        public RedirectResult Index()
        {
            var authorizeUrl = General.AuthorizeUrl(
                int.Parse(ConfigurationManager.AppSettings.Get("CREATESEND_CLIENT_ID")),
                ConfigurationManager.AppSettings.Get("CREATESEND_CLIENT_SECRET"),
                ConfigurationManager.AppSettings.Get("CREATESEND_REDIRECT_URI"),
                "ViewReports,CreateCampaigns,SendCampaigns");
            return Redirect(authorizeUrl);
        }

        public ContentResult ExchangeToken()
        {
            var code = Request.Params.Get("code");
            var tokenDetails = General.ExchangeToken(
                int.Parse(ConfigurationManager.AppSettings.Get("CREATESEND_CLIENT_ID")),
                ConfigurationManager.AppSettings.Get("CREATESEND_CLIENT_SECRET"),
                ConfigurationManager.AppSettings.Get("CREATESEND_REDIRECT_URI"),
                code);

            var accessToken = tokenDetails.access_token;
            var refreshToken = tokenDetails.refresh_token;

            var response = "";
            response = "<pre>";
            response += "Your user is successfully authenticated. Here are the details you need:<br/><br/>";
            response += "access token: " + accessToken + "<br/>";
            response += "refresh token: " + refreshToken + "<br/>";
            response += "<br/><br/>";
 
            AuthenticationDetails auth = new OAuthAuthenticationDetails(
                accessToken, refreshToken);
            General general = new General(auth);
            var clients = general.Clients();
 
            response += "We've made an API call too. Here are your clients:<br/><br/>";
            foreach (BasicClient c in clients) {
                response += c.Name + "<br/>";
            }
            response += "</pre>";
            return Content(response);
        }
    }
}
