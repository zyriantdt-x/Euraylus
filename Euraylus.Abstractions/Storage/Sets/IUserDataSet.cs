using Euraylus.Users.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Storage.Sets;
public interface IUserDataSet {
    string Uuid { get; set; }
    string Username { get; set; }
    string Password { get; set; }
    int Rank { get; set; }
}
