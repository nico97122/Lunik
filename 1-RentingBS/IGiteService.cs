using _2_RentingModel;

namespace _1_RentingBS
{
    public interface IGiteService
    {
        public List<Gite> GetGites();
        public Gite? GetGiteById(int id);
    }
}