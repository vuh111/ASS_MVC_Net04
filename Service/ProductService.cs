using ASS_MVC.Iservice;
using ASS_MVC.Models;

namespace ASS_MVC.Service
{
    public class ProductService : IProduct
    {
        ShopDbContext Context;
        public ProductService()
        {
            Context = new ShopDbContext();
        }
        public bool Add(Product product)
        {
            try
            {
                Context.Products.Add(product);
                Context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public bool Delete(Product product)
        {
            try
            {
                var removeProducts = Context.Products.ToList().FirstOrDefault(p => p.Id == product.Id);
                Context.Products.Remove(removeProducts);
                Context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public List<Product> Getall()
        {
            return Context.Products.ToList();
        }

        public bool Update(Product product)
        {
            try
            {
                var 
                updateProducts = Context.Products.ToList().FirstOrDefault(P => P.Id == product.Id);
                updateProducts.AvailableQuantity = product.AvailableQuantity;
                updateProducts.BillDetails = product.BillDetails;
                updateProducts.CartDetails = product.CartDetails;
                updateProducts.Description = product.Description;
                updateProducts.Name = product.Name;
                updateProducts.Price = product.Price;
                updateProducts.Status = product.Status;
                updateProducts.Supplier = product.Supplier;
                Context.Products.Update(updateProducts);
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
