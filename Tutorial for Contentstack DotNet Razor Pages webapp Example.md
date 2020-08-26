[![Contentstack](https://www.contentstack.com/docs/static/images/contentstack.png)](https://www.contentstack.com/)

##  Build an product catalog example app using  Razor Pages in ASP.NET Core and Contentstack .Net SDK

We have created a sample product catalog app that is built using Contentstack .Net SDK. The content of this app is powered by Contentstack Delivery APIs, and the app uses Contentstack .Net SDK.

This document covers the steps to get this app up and running for you. Try out the app and play with it, before building bigger and better applications.

## Prerequisite
- [Visual Studio 2019 16.4 or later](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2019) with the ASP.NET and web development workload
- [.NET Core 3.1 SDK or later](https://dotnet.microsoft.com/download/dotnet-core/3.1)
- [Contentstack account](https://www.app.contentstack.com/)
- [Basic knowledge of Contentstack](https://www.contentstack.com/docs/)

## Step 1: Create a stack
Log in to your Contentstack account, and [create a new stack](https://www.contentstack.com/docs/guide/stack#create-a-new-stack). Read more about [stack](https://www.contentstack.com/docs/guide/stack).

## Step 2: Add a publishing environment 
[Add a publishing environment](https://www.contentstack.com/docs/guide/environments#add-an-environment) to publish your content in Contentstack. Provide the necessary details as per your requirement. Read more about [environments](https://www.contentstack.com/docs/guide/environments).

## Step 3: Import content types
For this app, we need one content type: Product. Here’s what it is needed for:  
  
- **Product**: Lets you add the product content into your app.    

For quick integration, we have already created the content type. [Download the content types](https://github.com/contentstack/contentstack-ruby-graphql-example/raw/master/ContentTypes.zip)  and [import](https://www.contentstack.com/docs/guide/content-types#importing-a-content-type) it to your stack. (If needed, you can [create your own content types](https://www.contentstack.com/docs/guide/content-types#creating-a-content-type). Read more about [Content Types](https://www.contentstack.com/docs/guide/content-types).)

Now that all the content types are ready, let’s add some content for your Product app.

## Step 4: Add content
[Create](https://www.contentstack.com/docs/guide/content-management#add-a-new-entry) and [publish](https://www.contentstack.com/docs/guide/content-management#publish-an-entry) entries for the ‘Product’ content type.  
  
Now that we have created the sample data, it’s time to use and configure the presentation layer.

## Step 5: Create a Razor Pages web app

- Go to link to [Create a Razor Pages web app](https://docs.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/razor-pages-start?view=aspnetcore-3.1&tabs=visual-studio-code#create-a-razor-pages-web-app)

- Once you create web app to run it Press ```Ctrl+F5``` to run without the debugger.

## Step 6: Install Contentstack SDK Dependencies

- Now, we can install the ```Contentstack.csharp``` and ```Contentstack.AspNetCore``` library:
    - Right Click on **Dependencies** from Solution and Click **Manage NuGet Packages...**
    - Search for Contentstack.csharp and Contentstack.AspNetCore, select and click Add Package

## Step 7: Configuration for a Contentstack .NET SDK Client

- Open ```appsettings.json``` and inject your credentials so it looks like this:
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
- Open ```Startup.cs``` file and add following code:
```c#
using Contentstack.AspNetCore;

```
- Now we are going to register ```ContentstackClient``` in ```Startup.cs```:
```c#
public void ConfigureServices(IServiceCollection services)
{
    services.AddContentstack(Configuration);
    services.AddRazorPages();
}
```

## Step 8: Create Product Content Type Model using ```Contentstack.Model.Generator```

- Install ```Contentstack.Model.Generator``` using following command on terminal:
```sh
dotnet tool install --global contentstack.model.generator --version 0.2.3
```

- Go to your project folder and run following command:
```sh
contentstack.model.generator -a <API_KEY> -d <DELIVERY_TOKEN>
```
- With above we have created the Product Model class in you project folder
- Add all generated models into your Project solution.
    - Right click on Project in Visual Studio.
    - Go to ```Add->Existing Folder```.
    - Select Folder that is created in above step and click Add.

## Step 9: Create Product List page and Fetch Products from Contentstack .NET SDK
- Once we have added model for our Content Types, open ```Index.cshtml.cs``` and add following code:
```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contentstack.Core;
using Contentstack.Core.Models;
using ContentstackModels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace contentstack_dotnet_razor_pages_webapp_example.Pages
{
    public class IndexModel : PageModel
    {
        private readonly String _contentType = "product";
        private readonly ContentstackClient _contentstackClient;

        [BindProperty]
        public ContentstackCollection<Product> contentstackCollection { get; set; }

        public IndexModel(ContentstackClient contentstackClient)
        {
            _contentstackClient = contentstackClient;
        }

        public async Task OnGetAsync()
        {
            contentstackCollection = await _contentstackClient.ContentType(_contentType).Query().Find<Product>();
        }
    }
}

```
- Now lets update ```Index.cshtml``` with following code:
```html
@page
@model IndexModel
@{
    ViewData["Title"] = "Product page";
}

    <div class="product">
        <strong>Your products Count: @Model.contentstackCollection.Items.Count()</strong>
        <h1 class="display-4">Products</h1>
        <ul class="list-group">

            @foreach (ContentstackModels.Models.Product product in Model.contentstackCollection.Items)
            {
                <li class="list-group-item">
                    <span>@product.Title</span>
                </li>
            }
        </ul>
    </div>
```
- Now run the app. With this, we have started our app and now you have to open the browser and go to https://localhost:5001.

# Clone And Configure The Application

 - To get your app up and running quickly, we have created a sample DotNet Product catelog for this project. You need to download it and change the configuration. Download the app using the command given below:
```
$ git clone https://github.com/contentstack/contentstack-dotnet-razor-pages-webapp-example.git
```
  
 - Once you have downloaded the project, add your Contentstack API Key, Delivery Token, and Environment to the project. (Learn how to find your Stack's [API Key](https://www.contentstack.com/docs/guide/stack#edit-a-stack) and [Delivery Token](https://www.contentstack.com/docs/guide/tokens#create-a-delivery-token). Read more about [Environments](https://www.contentstack.com/docs/guide/environments)).

 - Open ```contentstack-dotnet-razor-pages-webapp-example/appsettings.json``` and inject your credentials so it looks like this:
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
- Now that we have a working project, you can build and run it.
