using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Ui.SimpleDemo.Data.Impl;

namespace Wpf.Ui.SimpleDemo.Data.Dao
{
    public class SqlServerDataDao : DataDao
    {
        public override UserDao GetUserDao()
        {
            return new UserDaoImpl();
        }
    }
}
