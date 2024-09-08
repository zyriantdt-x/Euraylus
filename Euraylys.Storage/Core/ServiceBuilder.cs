using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Storage.Core;
public static class ServiceBuilder {
    public static void AddStorageServices( this IServiceCollection services ) 
        => services.AddDbContext<EuraylusDbContext>( options => {
                string connection_string = "server=localhost;database=euraylus_dev;user=root;password=;";
                options.UseMySql( connection_string, ServerVersion.AutoDetect( connection_string ) );
        } );
  
}
