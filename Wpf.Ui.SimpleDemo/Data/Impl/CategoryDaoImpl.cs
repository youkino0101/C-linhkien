using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Ui.SimpleDemo.Data.Dao;
using Wpf.Ui.SimpleDemo.Utils;

namespace Wpf.Ui.SimpleDemo.Data.Impl
{
    public class CategoryDaoImpl : CategoryDao
    {
        private DBDataContext db;
        public CategoryDaoImpl()
        {
            db = new DBDataContext(Constants.DB_CONNECT_STRING);
        }

        public int count()
        {
            var query = from Category in db.GetTable<Category>() select Category;
            List<Category> CategoryList = query.ToList<Category>();
            return CategoryList.Count();
        }

        public void deleteById(int id)
        {
            Category find = db.Categories.Single(us => us.id == id);
            find.status = 0;
            db.SubmitChanges();
        }    

        public List<Category> findAll()
        {
            var all = from Category in db.GetTable<Category>() select Category;
            var CategoryList = all.ToList();
            return CategoryList;
        }

        public Category findById(int id)
        {
            return db.Categories.Single(us => us.id == id);
        }

        public Category findByName(string name)
        {
            return db.Categories.Single(us => us.name == name);
        }

        public void insert(Category Category)
        {
            db.Categories.InsertOnSubmit(Category);
            db.SubmitChanges();
        }

        public void update(Category Category)
        {
            Category find = db.Categories.Single(us => us.id == Category.id);
            find.name = Category.name;
            find.description = Category.description;
            db.SubmitChanges();
        }
    }
}
