using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Storage.Sets;
[Table( "channel_data" )]
[PrimaryKey( "Uuid" )]
public class ChannelDataSet : IChannelDataSet {
    public required string Uuid { get; set; }
    public required string Name { get; set; }
}
