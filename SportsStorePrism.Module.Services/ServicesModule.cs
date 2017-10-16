using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Modularity;
using SportsStorePrism.Infrastucture.Abstract;
using Microsoft.Practices.Unity;

namespace SportsStorePrism.Module.Services
{
  public class ServicesModule : IModule
  {
    private IUnityContainer _unityContainer;
    public ServicesModule(IUnityContainer unityContainer)
    {
      _unityContainer = unityContainer;
    }
    public void Initialize()
    {
      _unityContainer.RegisterType<IProductRepository, EfProductRepository>(new ContainerControlledLifetimeManager());
    }
  }
}
