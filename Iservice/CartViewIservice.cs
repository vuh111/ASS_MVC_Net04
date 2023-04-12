using ASS_MVC.Models;

namespace ASS_MVC.Iservice
{
    public interface CartViewIservice
    {
        public List<CartView> Getall();
        public bool Add(Product product,int quantity);
        public bool Update(Product product);
        public bool Delete(Product product);
    }
}
