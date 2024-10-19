using Models1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ScheduleData
    {
        private SqlDbData sqlDbData;
        public ScheduleData()
        {
            sqlDbData = new SqlDbData();
        }

        public List<Schedule> GetSchedules()
        {
            return sqlDbData.GetSchedules();
        }

        public bool AddSchedules(string Class, string Day, string Subject, string Time, string Professor)
        {

            var sched = sqlDbData.GetSchedulesForDay(Day, Subject, Professor);
            if (!sched.Any())
            {
                sqlDbData.AddSchedule(Class, Day, Subject, Time, Professor);
                return true;
            }
            return false;
        }

        public bool DeleteSchedules(string Class, string Subject, string Day, string Professor)
        {
            var sched = sqlDbData.GetSchedulesForDay(Day, Subject, Professor);
            if (sched != null)
            {
                sqlDbData.DeleteSchedule(Class, Subject, Professor);
                return true;
            }
            return false;
        }
        public bool UpdateSchedules(string Class, string Subject, string Day, string Professor)
        {
            var sched = sqlDbData.GetSchedulesForDay(Day, Subject, Professor);
            if (sched != null)
            {
                sqlDbData.UpdateSchedule(Class, Subject);
                return true;
            }
            return false;
        }
    }
}