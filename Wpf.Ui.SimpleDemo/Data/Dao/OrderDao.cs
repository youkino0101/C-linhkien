using System.Collections.Generic;

namespace Wpf.Ui.SimpleDemo.Data.Dao
{
    public interface OrderDao
    {
        void insert(Order order);
        void update(Order order);
        List<Order> findAll();
        int count();
        Order findById(int id);
        void deleteById(int id);
    }
}
