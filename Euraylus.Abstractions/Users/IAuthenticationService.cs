using Euraylus.Server.Sessions;
using Euraylus.Users.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Users;
public interface IAuthenticationService {
    void Login( ISession session, ILoginCredentials credentials );
    void Logout( IUser user );
}
