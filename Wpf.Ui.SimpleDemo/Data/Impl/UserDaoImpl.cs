using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Ui.SimpleDemo.Data.Dao;
using Wpf.Ui.SimpleDemo.Utils;

namespace Wpf.Ui.SimpleDemo.Data.Impl
{
    public class UserDaoImpl : UserDao
    {
        private DBDataContext db;
        public UserDaoImpl()
        {
            db = new DBDataContext(Constants.DB_CONNECT_STRING);
        }

        public int count()
        {
            var query = from user in db.GetTable<User>() select user;
            List<User> userList = query.ToList<User>();
            return userList.Count();
        }

        public void deleteById(int id)
        {
            User find = db.Users.Single(us => us.id == id);
            db.Users.DeleteOnSubmit(find);
            db.SubmitChanges();
        }

        public User find(string phone, string password)
        {
            try
            {
                return db.Users.Single(us => us.phone == phone && us.password == password);
            }
            catch (Exception ex) { }
            return null;
        }

        public List<User> findAll()
        {
            var all = from user in db.GetTable<User>() select user;
            var userList = all.ToList();
            return userList;
        }

        public User findById(int id)
        {
            return db.Users.Single(us => us.id == id);
        }

        public void insert(User user)
        {
            db.Users.InsertOnSubmit(user);
            db.SubmitChanges();
        }

        public User login(string username, string password)
        {
            string usname = username.ToLower();
            try
            {
                return db.Users.Single(us => ((us.phone == usname || us.email == usname || us.username == usname) && us.password == Function.MD5(password)));
            }
            catch (Exception ex) { }
            return null;
        }

        public void update(User user)
        {
            User find = db.Users.Single(us => us.id == user.id);
            find.username = user.username;
            find.password = user.password;
            find.email = user.email;
            find.phone = user.phone;
            find.address = user.address;
            find.role = user.role;
            db.SubmitChanges();
        }
    }
}
