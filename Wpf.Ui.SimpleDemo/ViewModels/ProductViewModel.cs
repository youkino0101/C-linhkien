using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FontAwesome.Sharp;
using System.Windows.Input;
using Wpf.Ui.SimpleDemo.Data.Dao;
using Wpf.Ui.SimpleDemo.Views;
using System.Windows;

namespace Wpf.Ui.SimpleDemo.ViewModels
{
    public class ProductViewModel : ViewModelBase
    {
        public MainViewModel _mainViewModel;
        private int _id;
        private String _name;
        private float _price;
        private int _quantity;
        private String _description;
        private int _categoryId;
        private String _searchName;
        public ICommand CreateProductCommand { get; }
        public ICommand EditProductCommand { get; }
        public ICommand DeleteProductCommand { get; }
        public ICommand SearchProductCommand { get; }


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


        public ICommand DeleteProductViewCommand { get; }

        public ProductViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            SearchProductCommand = new ViewModelCommand(ExecuteSearchProductViewCommand);
            CreateProductCommand = new ViewModelCommand(ExecuteCreateProductViewCommand);
            EditProductCommand = new ViewModelCommand(ExecuteEditProductViewCommand);
            DeleteProductCommand = new ViewModelCommand(ExecuteDeleteProductViewCommand);
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
                if (product.name.Length > 5){
                    string[] words = product.name.Trim().Split(' ');
                    words[words.Length - 1] = "";
                    product.name = String.Join(' ', words).Trim();
                }
                _productList.Add(product);
            }
        }
        private void ExecuteCreateProductViewCommand(object obj)
        {
            Product product = new Product();
            product.name = _name;
            product.price = _price;
            product.quantity = _quantity;
            product.description = _description;
            product.status = 1;
            product.categoryId = ProductView.temp;
            
            ProductDao productDao = DataDao.Instance().GetProductDao();
            productDao.insert(product);
            loadProductList();
        }
        private void ExecuteEditProductViewCommand(object obj)
        {
            Product product = new Product();
            product.id = _id;
            product.name = _name;
            product.price = _price;
            product.quantity = _quantity;
            product.description = _description;
            product.categoryId = ProductView.temp;
            ProductDao productDao = DataDao.Instance().GetProductDao();
            productDao.update(product);
            loadProductList();
        }
        private void ExecuteDeleteProductViewCommand(object obj)
        {
            Product product = new Product();
            product.id = _id;
            DataDao.Instance().GetProductDao().deleteById(product.id);
            loadProductList();
        }

        private void ExecuteSearchProductViewCommand(object obj)
        {
            ProductDao productDao = DataDao.Instance().GetProductDao();
            List<Product> list = productDao.findKeyName(_searchName);
            _productList.Clear();

            foreach (Product product in list)
            {
                // delete product code in product name
                if (product.name.Length > 5)
                {
                    string[] words = product.name.Trim().Split(' ');
                    words[words.Length - 1] = "";
                    product.name = String.Join(' ', words).Trim();
                }
                _productList.Add(product);
            }
        }

        public int IdP
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(IdP));
            }
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
        public float PriceP
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
                _categoryId = ProductView.temp;

            }
        }

        public string SearchName
        {
            get => _searchName;
            set
            {
                _searchName = value;
                OnPropertyChanged(nameof(SearchName));

            }
        }
    }
}
