using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Ui.SimpleDemo.Data.Dao;
using Wpf.Ui.SimpleDemo.Utils;

namespace Wpf.Ui.SimpleDemo.Data.Impl
{
    public class OrderDaoImpl : OrderDao
    {
        private DBDataContext db;
        public OrderDaoImpl()
        {
            db = new DBDataContext(Constants.DB_CONNECT_STRING);
        }

        public int count()
        {
            var query = from Order in db.GetTable<Order>() select Order;
            List<Order> OrderList = query.ToList<Order>();
            return OrderList.Count();
        }

        public void deleteById(int id)
        {
            Order find = db.Orders.Single(us => us.id == id);
            find.status = 0;
            db.SubmitChanges();
        }    

        public List<Order> findAll()
        {
            var all = from Order in db.GetTable<Order>() select Order;
            var OrderList = all.ToList();
            return OrderList;
        }

        public Order findById(int id)
        {
            return db.Orders.Single(us => us.id == id);
        }

        public void insert(Order Order)
        {
            db.Orders.InsertOnSubmit(Order);
            db.SubmitChanges();
        }

        public void update(Order Order)
        {
            Order find = db.Orders.Single(us => us.id == Order.id);
            find.name = Order.name;
            find.phone = Order.phone;
            find.address = Order.address;
            find.totalPrice = Order.totalPrice;
            db.SubmitChanges();
        }
    }
}
