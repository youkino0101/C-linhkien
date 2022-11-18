using System.Collections.Generic;

namespace Wpf.Ui.SimpleDemo.Data.Dao
{
    public interface UserDao
    {
        void insert(User user);
        void update(User user);
        List<User> findAll();
        int count();
        User findById(int id);
        void deleteById(int id);
        User find(string phone, string password);

        User login(string username, string password);
    }
}
