# WitAi .NET Api Client
This .NET library implements most (not all) of wit.ai API features, for details please refer to the [official documentation](https://wit.ai/docs/http/20170307).

## Install
The library is also available as [**NuGet Package**](https://www.nuget.org/packages/WitAi.DotNet.Api), you can add the dependency to your project using *NuGet package manager*:

```bat
PM> Install-Package WitAi.DotNet.Api -Version 1.1.0
```


## How to use it

### Get an API instance
First you need to construct an instance of the **WitAiApi** class, using either the empty ctor or the one with the api version parameter:

```csharp
WitAiApi api = new WitAiApi();
```

or

```csharp
WitAiApi api = new WitAiApi(apiVersion: "20170307");
```

If you use the empty constructor, the api version used will be the ```20170307```, that is currently the latest available (at the time I'm writing this README).

### Calling an API method
Every method exposed by the API class takes a *request model* as input and returns a *response model*.

#### Request Models
Every request model extends the base request model ```BaseWitRequest```, which exposes a single property ```AccessToken```, that *MUST* have a value when the api method is called, since this access token will be used to authorize the request.

#### Response Models
Every response model extends the base response model ```BaseWitResponse```, which exposes the common properties ```IsSuccessful``` and ```ErrorMessage```, that can be used to check whether the API call was successful or not, exposing the error returned by the API in case of error.

#### Example Request
In the following example we're creating an entity: the *request model* is an ```AddWitEntityRequest``` and the *response model* is an ```AddWitEntityResponse```:

```csharp
string appAccessToken = "{YOUR_ACCESS_TOKEN_HERE}";
WitAiApi api = new WitAiApi();

AddWitEntityRequest request = new AddWitEntityRequest(appAccessToken)
{
    EntityName = "greeting",
    Description = "A simple greeting from the user"
};

AddWitEntityResponse response = await api.AddEntity(request);

if(response.isSuccessful) {
    // ...
}
else {
    // You can use response.ErrorMessage to get details about the error
}
```


## API requests covered by this library
The following API requests are covered by this library:

- ```CreateApp``` ([POST /apps](https://wit.ai/docs/http/20170307#post--apps-link))
- ```DeleteApp``` ([DELETE /apps/:app-id](https://wit.ai/docs/http/20170307#delete--apps-:app-id-link))
- ```AddEntity``` ([POST /entities](https://wit.ai/docs/http/20170307#post--entities-link))
- ```GetEntity``` ([GET /entities/:entity-id](https://wit.ai/docs/http/20170307#get--entities-:entity-id-link))
- ```GetEntities``` ([GET /entities](https://wit.ai/docs/http/20170307#get--entities-link))
- ```DeleteEntity``` ([DELETE /entities/:entity-id](https://wit.ai/docs/http/20170307#delete--entities-:entity-id-link))
- ```Train``` ([POST /samples](https://wit.ai/docs/http/20170307#post--samples-link))
- ```ParseMessage``` ([GET /message](https://wit.ai/docs/http/20170307#get--message-link))