using ASS_MVC.Models;

namespace ASS_MVC.Iservice
{
    public interface IProduct
    {
        public List<Product> Getall();
        public bool Add (Product product);
        public bool Update (Product product);
        public bool Delete (Product product);

    }
}
