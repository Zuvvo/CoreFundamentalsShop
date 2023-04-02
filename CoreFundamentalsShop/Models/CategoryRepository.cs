namespace CoreFundamentalsShop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CoreFundamentalsShopDbContext _context;

        public CategoryRepository(CoreFundamentalsShopDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> AllCategories => _context.Categories.OrderBy(p => p.CategoryName);
    }
}
