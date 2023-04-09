using CoreFundamentalsShop.Models;
using Microsoft.AspNetCore.Components;

namespace CoreFundamentalsShop.Pages.App
{
    public partial class PieCard
    {
        [Parameter]
        public Pie? Pie { get; set; }
    }
}
