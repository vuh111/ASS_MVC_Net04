using ASS_MVC.Iservice;
using ASS_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASS_MVC.Models;

namespace ASS_MVC.Service
{
    public class CartViewService : CartViewIservice
    {
        public IProduct _ProductService = new ProductService();
        public ICart _CartService = new CartService();
        public ICartDetail _CartDeatailService = new CartDetailService();
        public CartViewService()
        {
            _ProductService = new ProductService();
            _CartDeatailService= new CartDetailService();
            _CartService = new CartService();
        }
        public bool Add(Product product,int quantity)
        {
             var y = _CartDeatailService.Getall().Any(x => x.IdSP == product.Id);
            if (y)
            {
                CartDetail product_in_cart=_CartDeatailService.Getall().FirstOrDefault(x => x.IdSP == product.Id);
                product_in_cart.Quantity += quantity;
                return _CartDeatailService.Update(product_in_cart);

            }
            else
            {
                return _CartDeatailService.Add(new CartDetail
                {
                    UserId = Guid.Parse("6DCB3756-D3CE-46E5-8562-35C2B70D1224"),
                    Id = Guid.NewGuid(),
                    IdSP = product.Id,
                    Quantity = quantity,
                });
            }
           
            
        }

        public bool Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public List<CartView> Getall()
        {
            List<Product> product_tb = _ProductService.Getall();
            int x = product_tb.ToList().Count();
            List<Cart> Cart_tb= _CartService.Getall();
            var y = Cart_tb.ToList();
            List<CartDetail> Cart_detail_tb = _CartDeatailService.Getall();
            var z = Cart_detail_tb.ToList();
            List<CartView> list = (from a in product_tb
                                   join b in Cart_detail_tb on a.Id equals b.IdSP
                                   join c in Cart_tb on b.UserId equals c.UserId
                                   select new CartView
                                   {
                                       Id = b.Id,
                                       Idcart = b.UserId,
                                       Idsp = a.Id,
                                       Name = a.Name,
                                       Quantity = b.Quantity,
                                       Price=a.Price,
                                       Description= a.Description
                                   }).ToList();
            return list;
        }

        public bool Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
