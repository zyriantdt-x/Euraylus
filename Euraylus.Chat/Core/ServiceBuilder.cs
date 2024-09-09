using Euraylus.Chat.Channels;
using Euraylus.Chat.Channels.Privileges;
using Euraylus.Chat.ChatUsers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Chat.Core;
public static class ServiceBuilder {
    public static void AddChatServices( this IServiceCollection services ) {
        services.AddChannelServices();
        services.AddChatUserServices();
    }

    public static void AddChannelServices( this IServiceCollection services ) {
        services.AddSingleton<IChannelMessageReceiver, ChannelMessageReceiver>();
        services.AddSingleton<IChannelMessageSender, ChannelMessageSender>();
        services.AddSingleton<IChannelService, ChannelService>();

        // privileges
        services.AddSingleton<IChannelPrivilegeFactory, ChannelPrivilegeFactory>();
        services.AddSingleton<IChannelPrivilegeService, ChannelPrivilegeService>();
    }

    public static void AddChatUserServices( this IServiceCollection services ) {
        services.AddSingleton<IChannelJoiner, ChannelJoiner>();
    }
}
