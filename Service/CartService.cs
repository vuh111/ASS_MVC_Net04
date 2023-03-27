using ASS_MVC.Iservice;
using ASS_MVC.Models;

namespace ASS_MVC.Service
{
    public class CartService : ICart
    {
        ShopDbContext Context;
        public CartService()
        {
            Context = new ShopDbContext();
        }

        public bool Add(Cart cart)
        {
            try
            {
                Context.Carts.Add(cart);
                Context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public bool Delete(Cart cart)
        {
            try
            {
                var removeCart = Context.Carts.ToList().FirstOrDefault(p => p.UserId == cart.UserId);
                Context.Carts.Remove(removeCart);
                Context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public List<Cart> Getall()
        {
            return Context.Carts.ToList();
        }

        public bool Update(Cart cart)
        {
            try
            {
                var updateCart = Context.Carts.ToList().FirstOrDefault(p => p.UserId == cart.UserId);
                updateCart.User = cart.User;
                updateCart.CartDetails = cart.CartDetails;
                updateCart.Description = cart.Description;
                Context.Carts.Update(updateCart);
                Context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}
