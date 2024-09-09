using Euraylus.Storage;
using Euraylus.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Euraylus.Chat.Channels.Privileges;
public class ChannelPrivilegeService : IChannelPrivilegeService {
    private readonly EuraylusDbContext storage;
    private readonly IChannelPrivilegeFactory factory;

    public ChannelPrivilegeService( EuraylusDbContext storage,
                                    IChannelPrivilegeFactory factory ) {
        this.storage = storage; 
        this.factory = factory;
    }

    public IChannelPrivilege? GetChannelPrivilege( IChannel channel, IUser user )
        => this.storage.ChannelPrivilegesSet
           .Where( privilege => privilege.ChannelUuid == channel.Uuid )
           .Where( privilege => privilege.UserUuid == user.Uuid )
           .Select( set => this.factory.CreateChannelPrivilege( set ) )
           .FirstOrDefault();

    public List<IChannelPrivilege> GetChannelPrivilegesByChannel( IChannel channel )
        => this.storage.ChannelPrivilegesSet
           .Where( privilege => privilege.ChannelUuid == channel.Uuid )
           .Select( set => this.factory.CreateChannelPrivilege( set ) )
           .ToList();

    public List<IChannelPrivilege> GetChannelPrivilegesByUser( IUser user )
        => this.storage.ChannelPrivilegesSet
           .Where( privilege => privilege.UserUuid == user.Uuid )
           .Select( set => this.factory.CreateChannelPrivilege( set ) )
           .ToList();
}
