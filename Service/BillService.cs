using ASS_MVC.Iservice;
using ASS_MVC.Models;

namespace ASS_MVC.Service
{
    public class BillService : IBill
    {
        ShopDbContext Context;
        public BillService()
        {
            Context = new ShopDbContext();
        }
        public bool Add(Bill bill)
        {
            try
            {
                Context.Bills.Add(bill);
                Context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(Bill bill)
        {
            try
            {
                var deleteBill = Context.Bills.ToList().FirstOrDefault(p => p.Id == bill.Id);
                Context.Bills.Remove(deleteBill);
                Context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public List<Bill> Getall()
        {
            return Context.Bills.ToList();
        }

        public bool Update(Bill bill)
        {
            try
            {
                var updateBill = Context.Bills.ToList().FirstOrDefault(p => p.Id == bill.Id);
                updateBill.User = bill.User;
                updateBill.CreateDate = bill.CreateDate;
                updateBill.Status = bill.Status;
                updateBill.UserId = bill.UserId;
                
                Context.Bills.Update(updateBill);
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
