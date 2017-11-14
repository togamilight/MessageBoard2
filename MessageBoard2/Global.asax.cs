using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using MvcContrib.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MessageBoard2
{
    public class MvcApplication : System.Web.HttpApplication, IUnityContainerAccessor
    {
        protected void Application_Start()
        {
            InitializeContainer();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private static UnityContainer _container;

        public static IUnityContainer Container {
            get { return _container; }
        }

        IUnityContainer IUnityContainerAccessor.Container {
            get { return Container; }
        }

        protected virtual void InitializeContainer() {
            if(_container == null) {
                _container = new UnityContainer();

                ControllerBuilder.Current.SetControllerFactory(typeof(UnityControllerFactory));

                string unityConfigFilePath = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["unityConfigPath"];
                FileConfigurationSource configExternal = new FileConfigurationSource(unityConfigFilePath);

                UnityConfigurationSection section = (UnityConfigurationSection)configExternal.GetSection("unity");
                section.Containers["dt"].Configure(_container);
            }
        }
    }
}
