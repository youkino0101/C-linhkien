using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Wpf.Ui.SimpleDemo.Data.Dao;

namespace Wpf.Ui.SimpleDemo.ViewModels
{
    public class CreateProductViewModel : ViewModelBase
    {
        private String _name;
        private float _price;
        private int _quantity;
        private String _description;
        private int _categoryId;
        public ICommand CreateProductCommand { get; }

        public CreateProductViewModel()
        {
            CreateProductCommand = new ViewModelCommand(ExecuteCreateProductCommand);
        }
        private void ExecuteCreateProductCommand(object obj)
        {
            Product product = new Product();
            product.name = _name;
            product.price = _price;
            product.quantity = _quantity;
            product.description = _description;
            product.categoryId = _categoryId;

            ProductDao productDao = DataDao.Instance().GetProductDao();
            productDao.insert(product);
        }
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public float Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        public int CategoryId
        {
            get => _categoryId;
            set
            {
                _categoryId = value;
                OnPropertyChanged(nameof(CategoryId));
            }
        }

    }
}
