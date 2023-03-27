using ASS_MVC.Models;

namespace ASS_MVC.Iservice
{
    public interface IBill
    {
        public List<Bill> Getall();
        public bool Add(Bill bill);
        public bool Update(Bill bill);
        public bool Delete(Bill bill);
    }
}
