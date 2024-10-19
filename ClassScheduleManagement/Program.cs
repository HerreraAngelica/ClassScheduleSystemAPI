//using BusinessLayer;
//using System;
//using System.Collections.Generic;
//using Models1;
//using DataLayer;

//namespace ClassScheduleManagement
//{
//    public class Program
//    {
//        static void Main(string[] args)
//        {

//            BusinessServices services = new BusinessServices();
//            services.GetSchedules();
//            List<.Schedule> schedules = services.GetSchedules();

//            Console.WriteLine("Enter a number: ");
//            Console.WriteLine("1. Display Schedule ");
//            Console.WriteLine("2. Add Schedule ");
//            Console.WriteLine("3. Delete Schedule ");
//            int choice = Convert.ToInt16(Console.ReadLine());

//            if (choice == 1)
//            {
//                foreach (var schedule in schedules)
//                {
//                    Console.WriteLine("");
//                    Console.WriteLine($"Class: {schedule.Class},\n Day: {schedule.Day},\n Day: {schedule.Professor}");
//                }
//            }
//            else if (choice == 2)
//            {

//                Console.WriteLine("Enter Class: ");
//                string classInput = Console.ReadLine();

//                Console.WriteLine("Enter Day: ");
//                string dayInput = Console.ReadLine();

//                Console.WriteLine("Enter Subject: ");
//                string subjectInput = Console.ReadLine();

//                Console.WriteLine("Enter Time: ");
//                string timeInput = Console.ReadLine();

//                Console.WriteLine("Enter Professor: ");
//                string professorInput = Console.ReadLine();

//                bool result = services.AddSchedule(classInput, dayInput, subjectInput, timeInput, professorInput);

//                if (result)
//                {
//                    Console.WriteLine("Schedule added successfully!");
//                }
//                else
//                {
//                    Console.WriteLine("Failed to add schedule.");
//                }

//            }
//            else if (choice == 3)
//            {
//                Console.WriteLine("Enter Class: ");
//                string classInputs = Console.ReadLine();

//                Console.WriteLine("Enter Day: ");
//                string subjectInputs = Console.ReadLine();

//                Console.WriteLine("Enter Subject: ");
//                string dayInputs = Console.ReadLine();


//                Console.WriteLine("Enter Professor: ");
//                string professorInputs = Console.ReadLine();

//                bool result = services.DeleteSchedule(classInputs, dayInputs, subjectInputs, professorInputs);

//                if (result)
//                {
//                    Console.WriteLine("Schedule deleted successfully!");
//                }
//                else
//                {
//                    Console.WriteLine("Failed to delete schedule. No matching schedule found.");
//                }

//            }
//            else
//            {
//                Console.WriteLine("Not a number");
//            }

//        }
//    }
//}