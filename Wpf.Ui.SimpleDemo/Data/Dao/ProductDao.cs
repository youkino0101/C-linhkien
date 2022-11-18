using System.Collections.Generic;

namespace Wpf.Ui.SimpleDemo.Data.Dao
{
    public interface ProductDao
    {
        void insert(Product product);
        void update(Product product);
        List<Product> findAll();
        int count();
        Product findById(int id);
        void deleteById(int id);
    }
}
