using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Users.Core;
public static class ServiceBuilder {
    public static void AddUserServices( this IServiceCollection services ) {
        services.AddSingleton<IUserService, UserService>();
        services.AddSingleton<IUserFactory, UserFactory>();
        services.AddSingleton<IAuthenticationService, AuthenticationService>();
    }
}
