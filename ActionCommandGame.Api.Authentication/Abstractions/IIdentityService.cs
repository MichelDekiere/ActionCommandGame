using ActionCommandGame.Api.Authentication.Model;
using Microsoft.AspNetCore.Identity;

namespace ActionCommandGame.Api.Authentication.Abstractions
{
	public interface IIdentityService
	{
		Task<AuthenticationResult> RegisterAsync(UserRegistrationRequest request);
		Task<AuthenticationResult> SignInAsync(UserSignInRequest request);
        /*Task<IdentityUser?> UpdateEmailAsync(string id);*/
    }
}
