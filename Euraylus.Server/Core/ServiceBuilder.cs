using Euraylus.Chat.Core;
using Euraylus.Server.Messages;
using Euraylus.Server.Messages.Handlers;
using Euraylus.Server.Messages.Handlers.Chat;
using Euraylus.Server.Messages.Handlers.Handshake;
using Euraylus.Server.Sessions;
using Euraylus.Server.Sockets;
using Euraylus.Storage.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Server.Core;
public static class ServiceBuilder {
    public static void AddServerServices( this IServiceCollection services ) {
        services.AddSocketServices();
        services.AddSessionServices();
        services.AddMessageServices();
        services.AddChatServices();
    }

    private static void AddSocketServices( this IServiceCollection services ) {
        services.AddSingleton<ISocketEventHandler, SocketEventHandler>();
    }

    private static void AddSessionServices( this IServiceCollection services ) { 
        services.AddSingleton<ISessionService, SessionService>();
    }

    private static void AddMessageServices( this IServiceCollection services ) {
        services.AddSingleton<IMessageReceiver, MessageReceiver>();
        services.AddSingleton<IMessageFactory, MessageFactory>();
        services.AddSingleton<IMessageSender, MessageSender>();

        services.AddIncomingMessages();
    }

    private static void AddIncomingMessages( this IServiceCollection services ) {
        // handshake
        services.AddSingleton<IMessageHandler, PingMessageHandler>();
        services.AddSingleton<IMessageHandler, TryLoginMessageHandler>();

        // chat
        services.AddSingleton<IMessageHandler, JoinChannelMessageHandler>();
        services.AddSingleton<IMessageHandler, ChatMessageMessageHandler>();
        services.AddSingleton<IMessageHandler, GetChannelsMessageHandler>();
        services.AddSingleton<IMessageHandler, KickChannelUserMessageHandler>();
    }
}
