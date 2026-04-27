using HairdresserAppointmentClient.Helpers;
using HairdresserAppointmentClient.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairdresserAppointmentClient.Pages
{
    public class GalleryModel : PageModel
    {
        private readonly GalleryHelper _gallery;
        public GalleryModel(GalleryHelper gallery)
        {
            _gallery = gallery;
        }

        public List<BeforeAndAfter> GalleryImages { get; set; }
        public void OnGet()
        {
            GalleryImages = _gallery.GetGalleri();
        }
    }
}
