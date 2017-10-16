using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

using SportsStorePrism.Infrastucture;
using SportsStorePrism.Module.Products.Views;

namespace SportsStorePrism.Module.Products
{
  public class ProductsModule : IModule
  {
    IUnityContainer _container;
    IRegionManager _regionManager;
    public ProductsModule(IUnityContainer container, IRegionManager regionManager)
    {
      _container = container;
      _regionManager = regionManager;
    }

    public void Initialize()
    {
      //Later for AddEdit with Navigation


      var productView = _container.Resolve<ProductView>();
      _regionManager.Regions[RegionNames.ProductRegion].Add(productView);
    }
  }
}
