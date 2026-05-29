using HairdresserAppointmentClient.Dto;
using HairdresserAppointmentClient.Models;

namespace HairdresserAppointmentClient.Helpers
{
    public class BookingHelper
    {

        private const int SearchPeriodInDays = 180;
        private const int TimeSlotIntervalMinutes = 15;

        public List<TimeSlot> GenerateTimeSlots(HairdresserBookingDto hairdresser, List<TreatmentDto> selectedTreatments)
        {
            var availableSlots = new List<TimeSlot>();

            var totalTreatmentTime = selectedTreatments.Sum(t => t.DurationInMinutes);

            var currentDate = DateTime.Today;

            var daysSearched = 0;

            while (daysSearched < SearchPeriodInDays)
            {
                var workingHour = hairdresser.WorkingHours
                    .SingleOrDefault(w => w.DayOfWeek == currentDate.DayOfWeek);

                if(workingHour == null)
                {
                    currentDate = currentDate.AddDays(1);
                    daysSearched++;
                    continue;
                }

                var currentStartTime = currentDate.Date + workingHour.StartTime;
                var currentEndTime = currentDate.Date + workingHour.EndTime;

                currentStartTime = AdjustStartTimeForToday(currentStartTime, currentEndTime);

                while(currentStartTime.AddMinutes(totalTreatmentTime) <= currentEndTime)
                {
                    var isAvailable = IsTimeAvailable(currentStartTime, totalTreatmentTime, hairdresser.Bookings);
                    if (isAvailable)
                    {
                        availableSlots.Add(new TimeSlot
                        {
                            StartTime = currentStartTime,
                            EndTime = currentStartTime.AddMinutes(totalTreatmentTime)
                        });

                    }
                        currentStartTime = currentStartTime
                        .AddMinutes(TimeSlotIntervalMinutes);
                }

                daysSearched++;
                currentDate = currentDate.AddDays(1);
                
            }

            return availableSlots;

        }


        //Justerar starttiden om den valda dagen är idag
        private DateTime AdjustStartTimeForToday(DateTime currentStartTime, DateTime currentEndTime)
        {
            if(currentStartTime.Date == DateTime.Today)
            {
                if(DateTime.Now > currentStartTime && DateTime.Now < currentEndTime)
                {
                    return DateTime.Now;
                }
            }
            return currentStartTime;
        }

        // Kontrollerar att den nya tiden inte krockar med befintliga bokningar
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
