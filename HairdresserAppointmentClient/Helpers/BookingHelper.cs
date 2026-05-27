using HairdresserAppointmentClient.Dto;
using HairdresserAppointmentClient.Models;

namespace HairdresserAppointmentClient.Helpers
{
    public class BookingHelper
    {
        public List<TimeSlot> GenerateTimeSlots(HairdresserBookingDto hairdresser, List<TreatmentDto> selectedTreatments)
        {
            var availableSlots = new List<TimeSlot>();
            var totalTreatmentTime = selectedTreatments.Sum(t => t.DurationInMinutes);
            var currentDate = DateTime.Today;
            var dayFound = 0;

            var dayCounter = 0;
            var maxDayCount = 150;

            while (dayFound < 90 && dayCounter < maxDayCount )
            {
                var workingHour = hairdresser.WorkingHours.Where(w => w.DayOfWeek == currentDate.DayOfWeek).SingleOrDefault();

                if(workingHour == null)
                {
                    currentDate = currentDate.AddDays(1);
                    continue;
                }

                var currentStartTime = currentDate.Date + workingHour.StartTime;
                var currentEndTime = currentDate.Date + workingHour.EndTime;

                if(currentStartTime.Date == DateTime.Today)
                {
                    if(DateTime.Now > currentStartTime && DateTime.Now < currentEndTime)
                    {
                        currentStartTime = DateTime.Now;
                    }
                    
                }
                var dayHasAvailableSlots = false;

                while(currentStartTime.AddMinutes(totalTreatmentTime) <= currentEndTime)
                {
                    var available = IsTimeAvailable(currentStartTime, totalTreatmentTime, hairdresser.Bookings);
                    if (available)
                    {
                        availableSlots.Add(new TimeSlot
                        {
                            StartTime = currentStartTime,
                            EndTime = currentStartTime.AddMinutes(totalTreatmentTime)
                        });

                        dayHasAvailableSlots = true;
                    }
                        currentStartTime = currentStartTime.AddMinutes(15);
                }

                if (dayHasAvailableSlots)
                {
                    dayFound++;
                }

                dayCounter++;
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


        public string GenerateBookingNumber()
        {
            string month = DateTime.Now.ToString("MMM").ToUpper();
            string numbers = Random.Shared.Next(100000, 999999).ToString();

            return $"{month}-{numbers}";
        }






    }
}
