using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using MySql.Data.Entity;

namespace Orcamento
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            DbConfiguration.SetConfiguration(new MySqlEFConfiguration());

            // Código executado na inicialização do aplicativo
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}