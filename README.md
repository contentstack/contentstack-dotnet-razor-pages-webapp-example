[![Contentstack](https://www.contentstack.com/docs/static/images/contentstack.png)](https://www.contentstack.com/)

## About this Example
Create a professional website using ASP.NET Razor Pages and Contentstack.

![Homepage Screenshot](Screenshots/product-catalog.png?raw=true "Homepage Screenshot")

## About Contentstack
Contentstack is a headless CMS with an API-first approach that puts content at the center. It is designed to simplify the process of publication by separating code from content.

## Perform the steps given below to get started

 - To get your app up and running quickly, we have created a sample .net Product Catalog for this project. You need to download it and change the configuration. Download the app using the command given below:
 
```
$ git clone https://github.com/contentstack/contentstack-dotnet-razor-pages-webapp-example.git
```
  
 - Once you have downloaded the project, add your Contentstack API Key, Delivery Token, and Environment to the project. (Learn how to find your Stack's [API Key](https://www.contentstack.com/docs/guide/stack#edit-a-stack) and [Delivery Token](https://www.contentstack.com/docs/guide/tokens#create-a-delivery-token). Read more about [Environments](https://www.contentstack.com/docs/guide/environments)).

 - Open ```contentstack-dotnet-razor-pages-webapp-example/appsettings.json``` and insert your credentials, so it looks like this:
```json
 {
  ....
  "ContentstackOptions": {
    "Host": "<HOST_NAME>",
    "ApiKey": "<API_KEY>",
    "DeliveryToken": "<DELIVERY_TOKEN>",
    "Environment": "<ENVIRONMENT_NAME>"
  },
  ...
}
```

## Tutorial
We have created an in-depth tutorial on how you can create a product catalog app using Contentstack's .NET SDK. Refer to the steps given in the following tutorial to create a fully functional product catalog app.

[Create a product catalog example app using Razor Pages in ASP.NET Core and Contentstack .NET SDK](https://www.contentstack.com/docs/example-apps/build-product-catalog-example-app-using-razor-pages-in-asp-dotnet-core-and-contentstack-dotnet-sdk)

## Documentation
 - [Visit the Contentstack Documentation](https://www.contentstack.com/docs/)
 - [Visit the Contentstack .NET SDK Documentation](https://github.com/contentstack/contentstack-dotnet)
