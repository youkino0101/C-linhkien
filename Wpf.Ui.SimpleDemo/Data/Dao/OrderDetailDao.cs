using System.Collections.Generic;

namespace Wpf.Ui.SimpleDemo.Data.Dao
{
    public interface OrderDetailDao
    {
        void insert(Order_detail OrderDetail);
        void update(Order_detail OrderDetail);
        List<Order_detail> findAll();
        int count();
        Order_detail findById(int id);
        void deleteById(int id);
    }
}
