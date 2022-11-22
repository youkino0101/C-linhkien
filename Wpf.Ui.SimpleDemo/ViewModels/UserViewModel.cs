using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FontAwesome.Sharp;
using System.Windows.Input;
using Wpf.Ui.SimpleDemo.Data.Dao;
using Wpf.Ui.SimpleDemo.Utils;

namespace Wpf.Ui.SimpleDemo.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        private MainViewModel _mainViewModel;
        private int _id;
        private String _name;
        private String _phone;
        private String _address;

        public ObservableCollection<User> _userList;
        public ObservableCollection<User> UserList
        {
            get { return _userList; }
            set
            {
                _userList = value;
                OnPropertyChanged(nameof(UserList));
            }
        }

        public ICommand CreateUserViewCommand { get; }
        public ICommand EditUserViewCommand { get; }
        public ICommand DeleteUserCommand { get; }
        public UserViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            CreateUserViewCommand = new ViewModelCommand(ExecuteCreateUserViewCommand);
            EditUserViewCommand = new ViewModelCommand(ExecuteEditUserViewCommand);
            DeleteUserCommand = new ViewModelCommand(ExecuteDeleteUserCommand);
            InitData();
        }

        private void InitData()
        {
            _userList = new ObservableCollection<User>();
            loadUserList();
        }

        private void loadUserList()
        {
            UserDao userDao = DataDao.Instance().GetUserDao();
            List<User> list = userDao.findAllCustomer("customer");

            _userList.Clear();
            foreach (User user in list)
            {
                _userList.Add(user);
            }
        }
        private void ExecuteCreateUserViewCommand(object obj)
        {
            User user = new User();
            user.username = _name;
            user.password = Function.MD5(_name);
            user.email = _name;
            user.phone = _phone;
            user.address = _address;
            user.status = 1;
            user.role = "customer";
            UserDao userDao = DataDao.Instance().GetUserDao();
            userDao.insert(user);
            loadUserList();
        }
        private void ExecuteEditUserViewCommand(object obj)
        {
            User user = new User();
            user.id = _id;            
            user.email = _name;
            user.phone = _phone;
            user.address = _address;
            UserDao userDao = DataDao.Instance().GetUserDao();
            userDao.update(user);
            loadUserList();
        }

        private void ExecuteDeleteUserCommand(object obj)
        {
            DataDao.Instance().GetUserDao().deleteById(_id);
            loadUserList();
        }

        public int IdU
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(IdU));
            }
        }
        public string NameU
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(NameU));
            }
        }
        public string PhoneU
        {
            get => _phone;
            set
            {
                _phone = value;
                OnPropertyChanged(nameof(PhoneU));
            }
        }
        public string AddressU
        {
            get => _address;
            set
            {
                _address = value;
                OnPropertyChanged(nameof(AddressU));
            }
        }

    }
}
