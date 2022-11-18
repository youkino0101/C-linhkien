using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Ui.SimpleDemo.Data.Dao;
using Wpf.Ui.SimpleDemo.Utils;

namespace Wpf.Ui.SimpleDemo.Data.Impl
{
    public class OrderDetailDaoImpl : OrderDetailDao
    {
        private DBDataContext db;
        public OrderDetailDaoImpl()
        {
            db = new DBDataContext(Constants.DB_CONNECT_STRING);
        }

        public int count()
        {
            var query = from Order_detail in db.GetTable<Order_detail>() select Order_detail;
            List<Order_detail> Order_detailList = query.ToList<Order_detail>();
            return Order_detailList.Count();
        }

        public void deleteById(int id)
        {
            Order_detail find = db.Order_details.Single(us => us.id == id);
            db.Order_details.DeleteOnSubmit(find);
            db.SubmitChanges();
        }    

        public List<Order_detail> findAll()
        {
            var all = from Order_detail in db.GetTable<Order_detail>() select Order_detail;
            var Order_detailList = all.ToList();
            return Order_detailList;
        }

        public Order_detail findById(int id)
        {
            return db.Order_details.Single(us => us.id == id);
        }

        public void insert(Order_detail Order_detail)
        {
            db.Order_details.InsertOnSubmit(Order_detail);
            db.SubmitChanges();
        }

        public void update(Order_detail Order_detail)
        {
            Order_detail find = db.Order_details.Single(us => us.id == Order_detail.id);
            find.quantity = Order_detail.quantity;
            find.price = Order_detail.price;
            find.orderId = Order_detail.orderId;
            find.productId = Order_detail.productId;
            db.SubmitChanges();
        }
    }
}
