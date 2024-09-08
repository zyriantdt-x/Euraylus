using Euraylus.Server.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Users;
public interface IUserService {
    void RegisterActiveUser( IUser user );
    void DeregisterActiveUser( IUser user );

    IUser? GetUserByUuid( string uuid );
    IUser? GetUserByUsername( string username );
    IUser? GetUserByLogin( string username, string password );
}
