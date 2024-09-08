using Euraylus.Storage.Sets;
using Euraylus.Users.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Users;
public class UserFactory : IUserFactory {
    public IUser CreateUser( IUserDataSet set )
        => new User() {
            Uuid = set.Uuid,
            Username = set.Username,
            Rank = ( UserRank )set.Rank
        };
}
