﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(GUI.Startup))]
namespace GUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            app.MapSignalR();
        }
    }
}
