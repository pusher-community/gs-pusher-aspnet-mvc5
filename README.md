# Pusher ASP.NET MVC 5 Getting Started (Work in Progress)

This is a sample project providing examples of all the basics of using Pusher in an ASP.NET MVC 5 application.

View the source of the project to see each completed example.

## Running the Samples

Create a file in `Pusher ASP.NET MVC 5 Getting Started` called `AppSettingsSecrets.config` with the following content:

```xml
<appSettings>
  <add key="pusherAppId" value="YOUR_PUSHER_APP_ID" />
  <add key="pusherAppKey" value="YOUR_PUSHER_APP_KEY" />
  <add key="pusherAppSecret" value="YOUR_PUSHER_APP_SECRET" />
</appSettings>
```

Replace the `YOUR_PUSHER_APP...` with your Pusher application credentials.

The solutions should now build and run.

## Done

* Processing & validating WebHooks
* Private channel subscription authentication *TODO*

## Todo

* Triggering an event on a single channel
* Triggering an event on multiple channels
* Presence channel subscription authentication
* Querying for existing channels within an app
* Querying for information on a single channel

*Note: Pull requests showing for the *TODO* examples would be greatly appreciated*
