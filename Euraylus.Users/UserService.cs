using Euraylus.Server.Messages;
using Euraylus.Server.Sessions;
using Euraylus.Storage;
using Euraylus.Storage.Sets;
using Euraylus.Users.MessageComposers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Users;
public class UserService : IUserService {
    private readonly ILogger<UserService> logger;
    private readonly EuraylusDbContext storage;
    private readonly IUserFactory factory;
    

    private List<IUser> active_users;

    public UserService( ILogger<UserService> logger,
                        EuraylusDbContext storage,
                        IUserFactory factory ) {
        this.logger = logger;
        this.storage = storage;
        this.factory = factory;

        this.active_users = new();
    }

    public void RegisterActiveUser( IUser user )
        => this.active_users.Add( user );
    public void DeregisterActiveUser( IUser user )
        => this.active_users.Remove( user );

    public IUser? GetUserByUuid( string uuid )
        => this.active_users
            .Where( user_pred => user_pred.Uuid == uuid )
            .FirstOrDefault()
        ?? this.storage.UserDataSet
            .Where( user_pred => user_pred.Uuid == uuid )
            .Select( user_data_set => this.factory.CreateUser( user_data_set ) )
            .FirstOrDefault();

    public IUser? GetUserByUsername( string username )
        => this.active_users
            .Where( user_pred => user_pred.Username.ToLower() == username.ToLower() )
            .FirstOrDefault()
        ?? this.storage.UserDataSet
            .Where( user_pred => user_pred.Username == username )
            .Select( user_data_set => this.factory.CreateUser( user_data_set ) )
            .FirstOrDefault();

    public IUser? GetUserByLogin( string username, string password )
        => this.active_users
            .Where( user_pred => user_pred.Username.ToLower() == username.ToLower() )
            .FirstOrDefault()
        ?? this.storage.UserDataSet
            .Where( user_pred => user_pred.Username == username )
            .Where( user_pred => user_pred.Password == password )
            .Select( user_data_set => this.factory.CreateUser( user_data_set ) )
            .FirstOrDefault();
}
