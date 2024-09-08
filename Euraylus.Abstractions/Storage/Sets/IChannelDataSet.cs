using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Storage.Sets;
public interface IChannelDataSet {
    string Uuid { get; set; }
    string Name { get; set; }
}
