![.NET Core](https://github.com/contentstack/contentstack-dotnet-razor-pages-webapp-example/workflows/.NET%20Core/badge.svg)

[![Contentstack](https://www.contentstack.com/docs/static/images/contentstack.png)](https://www.contentstack.com/)

## About this Example
Create a professional website using ASP.NET Razor Pages and Contentstack.

![Homepage Screenshot](Screenshots/product-catalog.png?raw=true "Homepage Screenshot")

## About Contentstack
Contentstack is a headless CMS with an API-first approach that puts content at the center. It is designed to simplify the process of publication by separating code from content.

## Get Started

 - To get your app running quickly, we have created a sample .NET Product Catalog for this project. You will need to download the code and change the configuration. Download the code using the command given below:
 
```
$ git clone https://github.com/contentstack/contentstack-dotnet-razor-pages-webapp-example.git
```
  
 - Once you have downloaded the project, Create a new Stack, add your Contentstack API Key, Delivery Token, and Environment to the application settings. If you're new to Contentstack, follow these links to learn how to find your Stack's [API Key](https://www.contentstack.com/docs/guide/stack#edit-a-stack) and [Delivery Token](https://www.contentstack.com/docs/guide/tokens#create-a-delivery-token). Also consider reading more about [Environments](https://www.contentstack.com/docs/guide/environments).

- Extract the contents of `ContentTypes.zip` and import `products.json` into the stack created above. Publish several product entries to the environment created above.

 - Open ```ContentstackRazorPagesExample/appsettings.json``` and insert your credentials, so it looks like this:
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

You're all set. Now, run the project.

## Tutorial
We've also created a guide that further explains this project. [Click here](https://www.contentstack.com/docs/example-apps/build-product-catalog-example-app-using-razor-pages-in-asp-dotnet-core-and-contentstack-dotnet-sdk)
to learn more.

## Additional Documentation
 - [Visit the Contentstack Documentation](https://www.contentstack.com/docs/)
 - [Visit the Contentstack .NET SDK Documentation](https://github.com/contentstack/contentstack-dotnet)
