using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FontAwesome.Sharp;

namespace Wpf.Ui.SimpleDemo.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;

        public string Caption
        {
            get
            {
                return _caption;
            }
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }
        public IconChar Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }

        public ViewModelBase CurrentChildView
        {
            get
            {
                return _currentChildView;
            }
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }
        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowUserViewCommand { get; }
        public ICommand ShowProductViewCommand { get; }
        public ICommand ShowCategoryViewCommand { get; }
        public ICommand ShowOrderViewCommand { get; }
        public ICommand ShowOrderDetailViewCommand { get; }

        public MainViewModel()
        {
            ShowUserViewCommand = new ViewModelCommand(ExecuteShowUserViewCommand);
            ShowProductViewCommand = new ViewModelCommand(ExecuteShowProductViewCommand);
            //ShowCategoryViewCommand = new ViewModelCommand(ExecuteShowCategoryViewCommand);
            

        }

        public void ExecuteShowUserViewCommand(object obj)
        {
            CurrentChildView = new UserViewModel(this);
            Caption = "Users";
            Icon = IconChar.User;
        }

        public void ExecuteShowProductViewCommand(object obj)
        {
            CurrentChildView = new ProductViewModel(this);
            Caption = "Products";
            Icon = IconChar.ShoppingBag;
        }
        public void ExecuteShowCategoryViewCommand(object obj)
        {
            //CurrentChildView = new CategoryViewModel(this);
            //Caption = "Categories";
            //Icon = IconChar.Box;
        }
    }
}
