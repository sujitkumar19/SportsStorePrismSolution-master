using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Mvvm;
using Prism.Events;
using SportsStorePrism.Infrastucture;

namespace SportsStorePrism.Module.StatusBar.ViewModels
{
  public class StatusBarViewModel:BindableBase
  {
    private IEventAggregator _eventAggregator;
    private string _statusBarContent;

    public StatusBarViewModel(IEventAggregator eventAggregator)
    {
      _eventAggregator = eventAggregator;
      StatusBarContent = "Message from StatusBar";
      _eventAggregator.GetEvent<ProductsMessagingEvent>().Subscribe(ProductMessaging);
    }

    private void ProductMessaging(string message)
    {
      StatusBarContent = message;
    }

        //public string StatusBarContent {
        //  get => _statusBarContent;
        //  set => SetProperty(ref _statusBarContent, value); }
        public string StatusBarContent
        {
            get
            {
                return _statusBarContent;
            }

            set
            {
                SetProperty(ref _statusBarContent, value);
            }
        }
    }
}
