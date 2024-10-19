using DataLayer;
using Models1;

namespace BusinessLayer
{
    public class BusinessServices
    {
        private SqlDbData _scheduleData;

        public BusinessServices()
        {
            _scheduleData = new SqlDbData();
        }

        public List<Schedule> GetSchedules()
        {
            return _scheduleData.GetSchedules();
        }

        // Add a new schedule
        public bool AddSchedule(Schedule schedule)
        {
            try
            {
                _scheduleData.AddSchedule(schedule.Classes, schedule.Day, schedule.Subject, schedule.Time, schedule.Professor);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Delete an existing schedule
        public bool DeleteSchedule(string className, string subject, string professor)
        {
            try
            {
                _scheduleData.DeleteSchedule(className, subject, professor);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateSchedule(string className, string subject, string professor)
        {
            try
            {
                _scheduleData.UpdateSchedule(className, subject);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
