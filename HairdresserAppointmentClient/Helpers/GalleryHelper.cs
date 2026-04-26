using HairdresserAppointmentClient.Models;

namespace HairdresserAppointmentClient.Helpers
{
    public class GalleryHelper
    {
        public List<BeforeAndAfter> GetGalleri()
        {
            var galleriList = new List<BeforeAndAfter>();

            for (int i = 1; i <= 9; i++)
            {
                galleriList.Add(new BeforeAndAfter
                {
                    Before = $"Bef{i}.jpg",
                    After = $"Aft{i}.jpg"
                });
            }

            return galleriList;
        }
    }
}
