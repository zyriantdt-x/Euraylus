using Euraylus.Users.Util;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Storage.Sets;
[Table("user_data")]
[PrimaryKey("Uuid")]
public class UserDataSet : IUserDataSet {
    public required string Uuid { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required int Rank { get; set; }
}
