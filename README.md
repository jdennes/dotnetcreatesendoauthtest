# dotnetcreatesendoauthtest

A very basic example application to demonstrate authenticating with the [Campaign Monitor API](http://www.campaignmonitor.com/api/) using OAuth.

This is an ASP.NET MVC application which uses the [createsend-dotnet](https://github.com/campaignmonitor/createsend-dotnet) library.

Most of the code is in the [DefaultController](DotNetCreateSendOAuthTest/Controllers/DefaultController.cs).

You'll want to set the following config settings in your `web.config` (or `user.config`) before you deploy this sample app:

```xml
<add key="CREATESEND_CLIENT_ID" value="client id for your app" />
<add key="CREATESEND_CLIENT_SECRET" value="client secret for your app" />
<add key="CREATESEND_REDIRECT_URI" value="redirect uri for your app" />
```
