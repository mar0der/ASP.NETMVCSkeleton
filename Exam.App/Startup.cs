﻿using Exam.App;

using Microsoft.Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace Exam.App
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
