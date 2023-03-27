using ASS_MVC.Models;

namespace ASS_MVC.Iservice
{
    public interface ICartDetail
    {
        public List<CartDetail> Getall();
        public bool Add( CartDetail cartDetail);
        public bool Update( CartDetail cartDetail);
        public bool Delete( CartDetail cartDetail);

    }
}
