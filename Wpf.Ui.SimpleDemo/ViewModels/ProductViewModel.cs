using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FontAwesome.Sharp;
using System.Windows.Input;
using Wpf.Ui.SimpleDemo.Data.Dao;

namespace Wpf.Ui.SimpleDemo.ViewModels
{
    public class ProductViewModel : ViewModelBase
    {
        public MainViewModel _mainViewModel;
        private String _name;
        private decimal _price;
        private int _quantity;
        private String _description;
        private int _categoryId;
        public ICommand CreateProductCommand { get; }


        public ObservableCollection<Product> _productList;

        public ObservableCollection<Product> ProductList
        {
            get { return _productList; }
            set
            {
                _productList = value;
                OnPropertyChanged(nameof(ProductList));
            }
        }

        public ICommand ShowCreateProductViewCommand { get; }
        public ICommand ShowEditProductViewCommand { get; }

        public ICommand DeleteProductViewCommand { get; }

        public ProductViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            ShowCreateProductViewCommand = new ViewModelCommand(ExecuteShowCreateProductViewCommand);
            ShowEditProductViewCommand = new ViewModelCommand(ExecuteShowEditProductViewCommand);
            DeleteProductViewCommand = new ViewModelCommand(ExecuteDeleteProductViewCommand);
            InitData();
        }
        private void InitData()
        {
            _productList = new ObservableCollection<Product>();
            loadProductList();
        }

        private void loadProductList()
        {
            ProductDao productDao = DataDao.Instance().GetProductDao();
            List<Product> list = productDao.findByCategory(3);
            _productList.Clear();

            foreach (Product product in list)
            {
                // delete product code in product name
                string[] words = product.name.Trim().Split(' ');
                words[words.Length - 1] = "";
                product.name = String.Join(' ', words).Trim();
                _productList.Add(product);
            }
        }
        private void ExecuteShowCreateProductViewCommand(object obj)
        {
            //_mainViewModel.CurrentChildView = new CreateProductViewModel();
            //_mainViewModel.Caption = "Create Products";
            //_mainViewModel.Icon = IconChar.ShoppingBag;
        }
        private void ExecuteShowEditProductViewCommand(object obj)
        {
            //int Id = (int)obj;
            //_mainViewModel.CurrentChildView = new EditProductViewModel(Id);
            //_mainViewModel.Caption = "Edit Products";
            //_mainViewModel.Icon = IconChar.ShoppingBag;


        }
        private void ExecuteDeleteProductViewCommand(object obj)
        {
            int Id = (int)obj;
            DataDao.Instance().GetProductDao().deleteById(Id);
            loadProductList();
        }
        public string NameP
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(NameP));
            }
        }
        public decimal PriceP
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged(nameof(PriceP));
            }
        }
        public int QuantityP
        {
            get => _quantity;
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(QuantityP));
            }
        }
        public string DescriptionP
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(DescriptionP));
            }
        }
        public int CategoryIdP
        {
            get => _categoryId;
            set
            {
                _categoryId = value;
                OnPropertyChanged(nameof(CategoryIdP));
            }
        }
    }
}
