﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf.Ui.SimpleDemo.Data.Dao
{
    public abstract class DataDao
    {
        //Singleton
        private static DataDao instance;
        public static void init(DataDao _instance)
        {
            instance = _instance;
        }
        public static DataDao Instance()
        {
            return instance;
        }
        abstract public UserDao GetUserDao();
        abstract public ProductDao GetProductDao(); 

    }
}
