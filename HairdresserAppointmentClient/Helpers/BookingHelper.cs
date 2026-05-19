using HairdresserAppointmentClient.Dto;

namespace HairdresserAppointmentClient.Helpers
{
    public class BookingHelper
    {
        public List<DateTime> GenerateTimeSlots(HairdresserBookingDto hairdresser, List<TreatmentDto> selectedTreatments)
        {
            var availableSlots = new List<DateTime>();
            var totalTreatmentTime = selectedTreatments.Sum(t => t.DurationInMinutes);
            var currentDate = DateTime.Today;
            var dayFound = 0;

            while (dayFound < 3)
            {
                var workingHour = hairdresser.WorkingHours.Where(w => w.DayOfWeek == currentDate.DayOfWeek).SingleOrDefault();

                if(workingHour == null)
                {
                    currentDate = currentDate.AddDays(1);
                    continue;
                }

                var startTime = currentDate.Date + workingHour.StartTime;
                var endTime = currentDate.Date + workingHour.EndTime;
                var dayHasAvailableSlots = false;

                while(startTime.AddMinutes(totalTreatmentTime) <= endTime)
                {
                    var available = IsTimeAvailable(startTime, totalTreatmentTime, hairdresser.Bookings);
                    if (available)
                    {
                        availableSlots.Add(startTime);
                        dayHasAvailableSlots = true;
                    }
                        startTime = startTime.AddMinutes(15);
                }

                if (dayHasAvailableSlots)
                {
                    dayFound++;
                }

                currentDate = currentDate.AddDays(1);
            }

            return availableSlots;

        }


        private bool IsTimeAvailable(DateTime slotStartTime, int totalTreatmentTime, List<BookingTimeDto> bookings)
        {
            var slotEndTime = slotStartTime.AddMinutes(totalTreatmentTime);
            foreach(var booking in bookings)
            {
                if(slotEndTime > booking.StartTime && slotStartTime < booking.EndTime)
                {
                    return false;
                }
            }

            return true;
        }









    }
}
