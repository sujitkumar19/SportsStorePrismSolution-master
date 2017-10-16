using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Mvvm;
using Prism.Commands;

namespace SportsStorePrism.Module.ToolBar.ViewModels
{
  public class ToolBarViewModel: BindableBase
  {

    public ToolBarViewModel()
    {
      NavigateToAddEditProductViewCommand = new DelegateCommand(OnNavigateToAddEditProduct);
    }

    private void OnNavigateToAddEditProduct()
    {
      throw new NotImplementedException();
    }

    public DelegateCommand NavigateToAddEditProductViewCommand { get; set; }
  }
}
