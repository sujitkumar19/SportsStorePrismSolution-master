using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using SportsStorePrism.Module.StatusBar.Views;
using SportsStorePrism.Infrastucture;

namespace SportsStorePrism.Module.StatusBar
{
  public class StatusBarModule : IModule
  {
    private IUnityContainer _container;
    private IRegionManager _regionManager;

    public StatusBarModule(IUnityContainer container, IRegionManager regionManager)
    {
      _container = container;
      _regionManager = regionManager;
    }
    public void Initialize()
    {
      var statusBarView = _container.Resolve<StatusBarView>();
      _regionManager.Regions[RegionNames.StatusBarRegion].Add(statusBarView);
    }
  }
}
