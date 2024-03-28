using LIbrary.ViewModels.Reader;
using Microsoft.AspNetCore.Mvc;

namespace LIbrary.ViewComponents
{
    public class ReaderMiniProfileViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(ICollection<ReaderReadVM> readers)
        {
            return View(readers);
        }

        // @await Component.InvokeAsync("ReaderMiniProfile", readers)
    }
}
