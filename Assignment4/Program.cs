
using System;
using System.Text.RegularExpressions;

namespace Assignment4
{

    //1st question 4th Assignment
    //class User
    //{
    //    public static int totalUsersLoggedIn = 0;

    //    public string username;

    //    public User(string name)
    //    {
    //        username = name;
    //        totalUsersLoggedIn++;
    //    }

    //    public void ShowUser()
    //    {
    //        Console.WriteLine($"User Logged In: {username}");
    //    }

    //    public static void ShowTotalUsers()
    //    {
    //        Console.WriteLine($"Total Users Logged In: {totalUsersLoggedIn}");
    //    }
    //}

    //class Program
    //{
    //    static void Main()
    //    {
    //        User user1 = new User("Alice");
    //        user1.ShowUser();

    //        User user2 = new User("Bob");
    //        user2.ShowUser();

    //        User user3 = new User("Charlie");
    //        user3.ShowUser();


    //        User.ShowTotalUsers();
    //    }
    //}


    //2nd question 4th Assignment

    class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; }

        public Employee(string name, double salary)
        {
            Name = name;
            Salary = salary;
        }

        public void DisplayEmployeeInfo()
        {
            Console.WriteLine($"Employee: {Name}, Salary: {Salary:C}");
        }
    }

    class Manager : Employee
    {
        public double Bonus { get; set; }

        public Manager(string name, double salary, double bonus) : base(name, salary)
        {
            Bonus = bonus;
        }

        public void DisplayManagerInfo()
        {
            Console.WriteLine($"Manager: {Name}, Salary: {Salary:C}, Bonus: {Bonus:C}");
        }
    }

    class Program
    {
        static void Main()
        {
            Employee emp = new Employee("John Doe", 50000);
            emp.DisplayEmployeeInfo();

            Manager mgr = new Manager("Alice Smith", 80000, 10000);
            mgr.DisplayManagerInfo();
        }

    }

    }