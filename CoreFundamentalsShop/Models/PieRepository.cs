using Microsoft.EntityFrameworkCore;

namespace CoreFundamentalsShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly CoreFundamentalsShopDbContext _dbContext;

        public PieRepository(CoreFundamentalsShopDbContext context)
        {
            _dbContext = context;
        }

        public IEnumerable<Pie> AllPies => _dbContext.Pies.Include(c => c.Category);

        public IEnumerable<Pie> PiesOfTheWeek => _dbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);

        public Pie? GetPieById(int pieId)
        {
            return _dbContext.Pies.FirstOrDefault(p => p.PieId == pieId);
        }

        public IEnumerable<Pie> SearchPies(string searchQuery)
        {
            return _dbContext.Pies.Where(p => p.Name.Contains(searchQuery));
        }
    }
}
