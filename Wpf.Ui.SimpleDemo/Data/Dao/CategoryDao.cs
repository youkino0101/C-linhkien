using System.Collections.Generic;

namespace Wpf.Ui.SimpleDemo.Data.Dao
{
    public interface CategoryDao
    {
        void insert(Category user);
        void update(Category user);
        List<Category> findAll();
        int count();
        Category findById(int id);
        void deleteById(int id);

        Category findByName(string name);
    }
}
