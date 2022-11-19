﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Wpf.Ui.SimpleDemo.Data.Dao;

namespace Wpf.Ui.SimpleDemo.ViewModels.Login
{
    public class LoginViewModel : ViewModelBase
    {
        public ICommand LoginCommand { get; }
        private string _phone;
        private string _password;
        private bool _isErrorVisible = false;
        private Visibility _IsVisible;
        public Visibility IsVisible
        {
            get { return _IsVisible; }
            set
            {
                _IsVisible = value;
                OnPropertyChanged(nameof(IsVisible));
            }
        }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand<object>(CanExecuteLoginCommand, ExecuteLoginCommand);
            Password = "";
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            return true;
        }

        private void ExecuteLoginCommand(object obj)
        {
            //SecureString myPass = Password.
            //string pass = Function.MD5(Password);
            DataDao.init(new SqlServerDataDao());
            UserDao userDao = DataDao.Instance().GetUserDao();

            User user = userDao.login(Phone, Password);
            if (user != null)
            {
                IsVisible = Visibility.Hidden;
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
            else
            {
                IsErrorVisible = true;
                MessageBox.Show("Login failed");
            }
        }
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public bool IsErrorVisible
        {
            get => _isErrorVisible;
            set
            {
                _isErrorVisible = value;
                OnPropertyChanged(nameof(IsErrorVisible));
            }
        }
    }
}
