using System;
using System.Collections.Generic;

namespace AssignmentDay6
{
    public class WorkshopRegistration
    {
       
        private Dictionary<string, HashSet<int>> workshopRegistrations;

        public WorkshopRegistration()
        {
            
            workshopRegistrations = new Dictionary<string, HashSet<int>>();
        }

        
        public void RegisterStudent(string workshopName, int studentId)
        {
           
            if (!workshopRegistrations.ContainsKey(workshopName))
            {
                workshopRegistrations[workshopName] = new HashSet<int>();
            }

           
            bool added = workshopRegistrations[workshopName].Add(studentId);

            if (added)
            {
                Console.WriteLine($"Student {studentId} successfully registered for {workshopName}.");
            }
            else
            {
                Console.WriteLine($"Student {studentId} is already registered for {workshopName}. Registration failed.");
            }
        }

       
        public void DisplayRegisteredStudents(string workshopName)
        {
            if (workshopRegistrations.ContainsKey(workshopName))
            {
                Console.WriteLine($"Students registered for {workshopName}:");
                foreach (int studentId in workshopRegistrations[workshopName])
                {
                    Console.WriteLine($"Student ID: {studentId}");
                }
            }
            else
            {
                Console.WriteLine($"No registrations for {workshopName}.");
            }
        }

    
        public static void Run()
        {
           
            WorkshopRegistration registrationSystem = new WorkshopRegistration();

           
            registrationSystem.RegisterStudent("C# Programming", 101);
            registrationSystem.RegisterStudent("C# Programming", 102);
            registrationSystem.RegisterStudent("Web Development", 103);

          
            registrationSystem.RegisterStudent("C# Programming", 101);

          
            registrationSystem.DisplayRegisteredStudents("C# Programming");
            registrationSystem.DisplayRegisteredStudents("Web Development");
        }
    }
}
