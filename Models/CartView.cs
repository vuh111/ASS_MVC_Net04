using System.Drawing.Printing;

namespace ASS_MVC.Models
{
    public class CartView
    {
        public Guid Id { get; set; }
        public Guid Idsp { get; set; }
        public Guid Idcart { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
    }
}
