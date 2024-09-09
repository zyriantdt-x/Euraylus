using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Storage.Sets;
[Table( "channel_privileges" )]
[PrimaryKey("Uuid")]
public class ChannelPrivilegesSet : IChannelPrivilegesSet {
    [Column( "uuid" )] public required string Uuid { get; set; }
    [Column("channel_uuid")] public required string ChannelUuid { get; set; }
    [Column("user_uuid")] public required string UserUuid { get; set; }
    [Column("privilege_level")] public required int PrivilegeLevel { get; set; }
}
