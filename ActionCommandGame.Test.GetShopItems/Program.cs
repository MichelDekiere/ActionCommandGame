//Configuration and registration

using ActionCommandGame.Api.Authentication.Model;
using ActionCommandGame.Sdk.Abstractions;
using ActionCommandGame.Sdk.Extensions;
using ActionCommandGame.Test.ConsoleApp1.Stores;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();

serviceCollection.AddScoped<ITokenStore, TokenStore>();

serviceCollection.AddApi("https://localhost:7237");

var serviceProvider = serviceCollection.BuildServiceProvider();
var tokenStore = serviceProvider.GetRequiredService<ITokenStore>();

var identitySdk = serviceProvider.GetRequiredService<IIdentityApi>();
var itemApi = serviceProvider.GetRequiredService<IItemApi>();


//Inloggen
var signInRequest = new UserSignInRequest()
{
    Email = "bavo.ketels@vives.be",
    Password = "Test123$"
};

var logInResult = await identitySdk.SignInAsync(signInRequest);

var result = await itemApi.FindAsync();

if (!result.IsSuccess)
{
    Console.WriteLine("Niet gelukt");
}

foreach (var item in result.Data)
{
    Console.WriteLine(item.Name);
}
