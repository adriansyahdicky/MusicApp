using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusicRoom.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicRoom.Services;

namespace MusicRoom.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection")) 
                    );



            services.AddScoped<IArtistService, ArtistService>();
        }
    }
}
