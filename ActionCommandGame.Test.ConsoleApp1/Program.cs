using ActionCommandGame.Api.Authentication.Model;
using ActionCommandGame.Sdk.Abstractions;
using ActionCommandGame.Sdk.Extensions;
using ActionCommandGame.Test.ConsoleApp1.Stores;
using Microsoft.Extensions.DependencyInjection;


//Configuration and registration
var serviceCollection = new ServiceCollection();

serviceCollection.AddScoped<ITokenStore, TokenStore>();

serviceCollection.AddApi("https://localhost:7237");

// Running and Start 
/*Console.WriteLine("Press any key to continue...");
Console.ReadLine();*/

var serviceProvider = serviceCollection.BuildServiceProvider();
var tokenStore = serviceProvider.GetRequiredService<ITokenStore>();

var identitySdk = serviceProvider.GetRequiredService<IIdentityApi>();

// Registeren
Console.WriteLine("-----------------Registeren-----------------");

Console.Write("Email: ");
var regEmail = Console.ReadLine();

Console.Write("Password: ");
var regPassword = Console.ReadLine();

var registerRequest = new UserRegistrationRequest()
{
    Email = regEmail,
    Password = regPassword
};

var registerResult = await identitySdk.RegisterAsync(registerRequest);

Console.WriteLine($"Registeren gelukt? {registerResult.Success}\n");


// Inloggen
Console.WriteLine("------------------Aanmelden------------------");

Console.Write("Email: ");
var email = Console.ReadLine();

Console.Write("Password: ");
var passWord = Console.ReadLine();

var signInRequest = new UserSignInRequest()
{
    Email = email,
    Password = passWord
};


var logInResult = await identitySdk.SignInAsync(signInRequest);

Console.WriteLine(logInResult.Success);