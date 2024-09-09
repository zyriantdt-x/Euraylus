using Euraylus.Chat.Channels.Privileges;
using Euraylus.Chat.ChatUsers;
using Euraylus.Chat.Composers;
using Euraylus.Server.Messages;
using Euraylus.Storage;
using Euraylus.Storage.Sets;
using Euraylus.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Euraylus.Chat.Channels;
internal class ChannelService : IChannelService {
    private readonly EuraylusDbContext storage;

    private readonly List<IChannel> channels;

    public ChannelService( EuraylusDbContext storage,
                           IMessageSender message_sender ) {
        this.storage = storage;

        this.channels = new();
        this.LoadChannels();
    }

    private IChannel CreateChannel( IChannelDataSet set ) 
        => new Channel() { 
                Uuid = set.Uuid, 
                Name = set.Name 
        };

    private void LoadChannels()
        => this.storage.ChannelDataSet.ToList().ForEach(set => {
            IChannel channel = this.CreateChannel( set );
            this.RegisterChannel( channel );
        } );

    private void RegisterChannel( IChannel channel )
        => this.channels.Add( channel );

    public IChannel? GetChannelByUuid( string uuid )
        => this.channels.Where( channel => channel.Uuid == uuid ).FirstOrDefault();
}
