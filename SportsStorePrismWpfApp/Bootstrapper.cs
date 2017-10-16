using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Unity;
using Prism.Modularity;
using System.Windows;
using SportsStorePrism.Module.ToolBar;
using SportsStorePrism.Module.Services;
using SportsStorePrism.Module.Products;
using SportsStorePrism.Module.StatusBar;

namespace SportsStorePrismWpfApp
{
  public class Bootstrapper: UnityBootstrapper
  {
    protected override DependencyObject CreateShell()
    {
      return Container.TryResolve<Shell>();
      #region Default
      //return base.CreateShell(); 
      #endregion
    }

    protected override void InitializeShell()
    {
      base.InitializeShell();
      App.Current.MainWindow = Shell as Window;
      App.Current.MainWindow.Show();
    }

    protected override IModuleCatalog CreateModuleCatalog()
    {
      ModuleCatalog moduleCatalog = new ModuleCatalog();
      moduleCatalog.AddModule(typeof(ToolBarModule));
      moduleCatalog.AddModule(typeof(ServicesModule));
      moduleCatalog.AddModule(typeof(ProductsModule));
      moduleCatalog.AddModule(typeof(StatusBarModule));
      return moduleCatalog;
      //return base.CreateModuleCatalog();
    }
  }
}
