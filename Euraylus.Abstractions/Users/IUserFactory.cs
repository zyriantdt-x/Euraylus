using Euraylus.Storage.Sets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Users;
public interface IUserFactory {
    IUser CreateUser( IUserDataSet set );
}
