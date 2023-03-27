using ASS_MVC.Iservice;
using ASS_MVC.Models;

namespace ASS_MVC.Service
{
    public class BillDetailService : IBillDetail
    {
        ShopDbContext Context;
        public BillDetailService()
        {
            Context = new ShopDbContext();
        }
        public bool Add(BillDetail billDetail)
        {
            try
            {
                Context.BillDetails.Add(billDetail);
                Context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public bool Delete(BillDetail billDetail)
        {
            try
            {
                var removeBillDetail = Context.BillDetails.ToList().FirstOrDefault(p => p.Id == billDetail.Id);
                Context.BillDetails.Remove(billDetail);
                Context.SaveChanges();

                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }

        public List<BillDetail> Getall()
        {
            return Context.BillDetails.ToList();
        }

        public bool Update(BillDetail billDetail)
        {
            try
            {
               var updateBillDetail=Context.BillDetails.ToList().FirstOrDefault(c=>c.Id==billDetail.Id);
                updateBillDetail.IdHD = billDetail.IdHD;
                updateBillDetail.IdSP=billDetail.IdSP;
                updateBillDetail.IdHD=billDetail.IdHD;
                updateBillDetail.Price= billDetail.Price;
                updateBillDetail.Quantity = billDetail.Quantity;
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }
    }
}
