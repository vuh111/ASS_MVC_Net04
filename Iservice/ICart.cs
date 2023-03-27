using ASS_MVC.Models;

namespace ASS_MVC.Iservice
{
    public interface ICart
    {
        public List<Cart> Getall();
        public bool Add (Cart cart);
        public bool Update (Cart cart);
        public bool Delete (Cart cart);

    }
}
