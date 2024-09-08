using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Users.Util;
public interface ILoginCredentials {
    string Username { get; init; }
    string Password { get; init; }
}
