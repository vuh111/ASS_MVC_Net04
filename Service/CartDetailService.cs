using ASS_MVC.Iservice;
using ASS_MVC.Models;

namespace ASS_MVC.Service
{
    public class CartDetailService : ICartDetail
    {
        ShopDbContext Context;
        public CartDetailService() 
        {
            Context = new ShopDbContext();
        }
        public bool Add(CartDetail cartDetail)
        {
            try
            {
                Context.CartDetails.Add(cartDetail);
                Context.SaveChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }

        public bool Delete(CartDetail cartDetail)
        {
            try
            {
                var removeCartDetail = Context.CartDetails.ToList().FirstOrDefault(p => p.Id == cartDetail.Id);
                Context.CartDetails.Remove(removeCartDetail);
                Context.SaveChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }

        public List<CartDetail> Getall()
        {
            return Context.CartDetails.ToList();
        }

        public bool Update(CartDetail cartDetail)
        {
            try
            {
                var updateCartDetail = Context.CartDetails.ToList().FirstOrDefault(p => p.Id == cartDetail.Id);
                updateCartDetail.IdSP = cartDetail.IdSP;
                updateCartDetail.Cart = cartDetail.Cart;
                updateCartDetail.Quantity = cartDetail.Quantity;
                updateCartDetail.UserId = cartDetail.UserId;
                Context.CartDetails.Update(updateCartDetail);
                Context.SaveChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }
    }
}
