using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;

using Prism.Mvvm;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;

using SportsStorePrism.Infrastucture;
using SportsStorePrism.Infrastucture.Abstract;
using SportsStorePrism.Infrastucture.Entities;
using Prism.Interactivity.InteractionRequest;
using System.Windows.Input;

namespace SportsStorePrism.Module.Products.ViewModels
{
  public class ProductViewModel: BindableBase
  {
    private IRegionManager _regionManager;
    private IEventAggregator _eventAggregator;

    private IProductRepository _productRepository;
    private ObservableCollection<Product> _products;
    private List<Product> _allProducts;

    public ObservableCollection<Product> Products {
            get
            {
                return _products;
            }

            set
            {
                SetProperty(ref _products, value);
            }
        }

    public DelegateCommand<Product> EditProductCommand { get; set; }
    public event Action<Product> EditProductRequested = delegate { };
    public DelegateCommand<Product> DeleteProductCommand { get; set; }

    public InteractionRequest<IConfirmation> ConfirmationRequest { get; set; }
    public ICommand ConfirmationCommand { get; set; }
    public ProductViewModel(IProductRepository productRepository, IRegionManager regionManager, IEventAggregator eventAggregator)
    {
      _productRepository = productRepository;
      _regionManager = regionManager;
      _eventAggregator = eventAggregator;

      EditProductCommand = new DelegateCommand<Product>(OnEdit);
      DeleteProductCommand = new DelegateCommand<Product>(OnDeleteProduct);

      ConfirmationRequest = new InteractionRequest<IConfirmation>();
      ConfirmationCommand = new DelegateCommand<Product>(OnDeleteProduct);

      GetAllProducts();
      GetProducts();
    }

    private void GetProducts()
    {
      Products = new ObservableCollection<Product>(_allProducts);
    }

    private void GetAllProducts()
    {
      _allProducts = _productRepository.GetProductsAsync().Result;
    }

    private void OnDeleteProduct(Product product)
    {
      string question = string.Format($"Do you wish to delete\nProduct: {product.ProductName}, with the Id: {product.ProductId}");
      string message = string.Format($"Product: {product.ProductName}, With the Id: {product.ProductId}, Deleted Successfully, {DateTime.Now}");

      ConfirmationRequest.Raise(
        new Confirmation { Title = "Delete Product", Content = question },
        (result) => {
          if (result.Confirmed)
          {
            Products.Remove(product);
            _eventAggregator.GetEvent<ProductsMessagingEvent>().Publish(message);
          }
          else
          {
            _eventAggregator.GetEvent<ProductsMessagingEvent>().Publish("Did not Delete");
          }
        }
        );


      #region With StatuBar
      //string message = string.Format($"Product: {product.ProductName}, With the Id: {product.ProductId}, Deleted Successfully, {DateTime.Now}");
      //_eventAggregator.GetEvent<ProductsMessagingEvent>().Publish(message); 
      #endregion
    }

    private void OnEdit(Product product)
    {
      throw new NotImplementedException();
    }
  }
}
