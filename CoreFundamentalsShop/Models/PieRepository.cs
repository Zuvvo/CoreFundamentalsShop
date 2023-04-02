using Microsoft.EntityFrameworkCore;

namespace CoreFundamentalsShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly CoreFundamentalsShopDbContext _context;

        public PieRepository(CoreFundamentalsShopDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Pie> AllPies => _context.Pies.Include(c => c.Category);

        public IEnumerable<Pie> PiesOfTheWeek => _context.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);

        public Pie? GetPieById(int pieId)
        {
            return _context.Pies.FirstOrDefault(p => p.PieId == pieId);
        }

        public IEnumerable<Pie> SearchPies(string searchQuery)
        {
            throw new NotImplementedException();
        }
    }
}
