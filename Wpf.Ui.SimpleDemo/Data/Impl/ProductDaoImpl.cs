using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Wpf.Ui.SimpleDemo.Data.Dao;
using Wpf.Ui.SimpleDemo.Utils;

namespace Wpf.Ui.SimpleDemo.Data.Impl
{
    public class ProductDaoImpl : ProductDao
    {
        private DBDataContext db;
        public ProductDaoImpl()
        {
            db = new DBDataContext(Constants.DB_CONNECT_STRING);
        }

        public int count()
        {
            var query = from Product in db.GetTable<Product>() select Product;
            List<Product> ProductList = query.ToList<Product>();
            return ProductList.Count();
        }

        public void deleteById(int id)
        {
            Product find = db.Products.Single(us => us.id == id);
            find.status = 0;
            db.SubmitChanges();
        }    

        public List<Product> findAll()
        {
            var all = from Product in db.GetTable<Product>() select Product;
            var ProductList = all.ToList();
            return ProductList;
        }

        public Product findById(int id)
        {
            return db.Products.Single(us => us.id == id);
        }

        public Product findByName(string name)
        {
            return db.Products.Single(us => us.name == name);
        }

        public List<Product> findByCategory(int id)
        {
           /* var all = from Product in db.GetTable<Product>() where Product.categoryId == id select Product;
            var ProductList = all.ToList();*/
            return db.Products.Where(pr => pr.categoryId == id && pr.status == 1).ToList();
        }

        public List<Product> findKeyName(string name)
        {
            var all = from Product in db.GetTable<Product>() where Product.name.Contains(name) select Product;
            var ProductList = all.ToList();
            return ProductList;
        }

        public void insert(Product Product)
        {
            db.Products.InsertOnSubmit(Product);
            db.SubmitChanges();
        }

        public void update(Product Product)
        {
            Product find = db.Products.Single(us => us.id == Product.id);
            find.name = Product.name;
            find.description = Product.description;
            find.price = Product.price;
            find.quantity = Product.quantity;
            find.categoryId = Product.categoryId;
            db.SubmitChanges();
        }
    }
}
