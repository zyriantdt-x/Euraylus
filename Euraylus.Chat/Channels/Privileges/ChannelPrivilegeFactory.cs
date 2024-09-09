using Euraylus.Storage.Sets;
using Euraylus.Users;
using Euraylus.Users.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Chat.Channels.Privileges;
public class ChannelPrivilegeFactory : IChannelPrivilegeFactory {
    private readonly IChannelService channel_service;
    private readonly IUserService user_service;

    public ChannelPrivilegeFactory( IChannelService channel_service,
                                    IUserService user_service ) {
        this.channel_service = channel_service;
        this.user_service = user_service;

    }

    public IChannelPrivilege CreateChannelPrivilege( IChannelPrivilegesSet set ) {
        IUser? user = this.user_service.GetUserByUuid( set.UserUuid );
        IChannel? channel = this.channel_service.GetChannelByUuid( set.ChannelUuid );
        UserRank privilege_level = ( UserRank )set.PrivilegeLevel;
        if( user == null || channel == null )
            throw new Exception( "dodgy value in database" );

        return new ChannelPrivilege() {
            User = user,
            Channel = channel,
            PrivilegeLevel = privilege_level
        };
    }
}
