using ASS_MVC.Models;

namespace ASS_MVC.Iservice
{
    public interface IBillDetail
    {
        public List<BillDetail> Getall();
        public bool Add(BillDetail billDetail);
        public bool Update(BillDetail billDetail);
        public bool Delete(BillDetail billDetail);

    }
}
