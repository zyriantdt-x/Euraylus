using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Storage.Sets;
public interface IChannelPrivilegesSet {
    string ChannelUuid { get; set; }
    string UserUuid { get; set; }
    int PrivilegeLevel { get; set; }
}
