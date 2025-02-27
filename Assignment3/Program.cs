using System;
using System.Text.RegularExpressions;

namespace Assignment3
{
    //  Question 1 Start from here
    //{
    //    class Car
    //    {
    //        public int CarID { get; set; }
    //        public string Brand { get; set; }
    //        public string Model { get; set; }
    //        public int Year { get; set; }
    //        public double Price { get; set; }


    //        public Car(int carID, string brand, string modal, int year, double price)
    //        {
    //            CarID = carID;
    //            Brand = brand;
    //            Model = modal;
    //            Year = year;
    //            Price = price;

    //        }

    //        public void AcceptCarDetails()
    //        {
    //            Console.WriteLine("Receiving Car Information");

    //        }


    //        public void DisplayCarDetails()
    //        {
    //            Console.WriteLine($"Car ID: {CarID}");
    //            Console.WriteLine($"Brand: {Brand}");
    //            Console.WriteLine($"Model:{Model}");
    //            Console.WriteLine($"Year: {Year}");
    //            Console.WriteLine($"Price:{Price}");

    //        }
    //    }

    //    class CarDetails
    //    {
    //        static void Main()
    //        {

    //            Car car1 = new Car(101, "Toyota", "Corolla", 2020, 20000);


    //            car1.AcceptCarDetails();


    //            car1.DisplayCarDetails();
    //        }
    //    }




    //  Question 2 start from here

    //class Car
    //{

    //    private int carID;
    //    private string brand;
    //    private string model;
    //    private int year;
    //    private double price;


    //    public int CarID
    //    {
    //        get { return carID; }
    //        set { carID = value; }
    //    }

    //    public string Brand
    //    {
    //        get { return brand; }
    //        set { brand = value; }
    //    }

    //    public string Model
    //    {
    //        get { return model; }
    //        set { model = value; }
    //    }

    //    public int Year
    //    {
    //        get { return year; }
    //        set { year = value; }
    //    }

    //    public double Price
    //    {
    //        get { return price; }
    //        set { price = value; }
    //    }


    //    public Car()
    //    {
    //        carID = 0;
    //        brand = "Unknown";
    //        model = "Unknown";
    //        year = 2000;
    //        price = 0.0;
    //    }


    //    public Car(int carID, string brand, string model, int year, double price)
    //    {
    //        this.carID = carID;
    //        this.brand = brand;
    //        this.model = model;
    //        this.year = year;
    //        this.price = price;
    //    }


    //    public void AcceptCarDetails()
    //    {
    //        Console.WriteLine("Receiving Car Information");
    //    }


    //    public void DisplayCarDetails()
    //    {
    //        Console.WriteLine("Presenting Car Information");
    //        Console.WriteLine($"Car ID: {CarID}");
    //        Console.WriteLine($"Brand: {Brand}");
    //        Console.WriteLine($"Model: {Model}");
    //        Console.WriteLine($"Year: {Year}");
    //        Console.WriteLine($"Price: {Price:C}");
    //    }
    //}

    //class Program
    //{
    //    static void Main()
    //    {

    //        Car car1 = new Car();
    //        car1.AcceptCarDetails();
    //        car1.DisplayCarDetails();
    //        Console.WriteLine();


    //        Car car2 = new Car(102, "Ford", "Mustang", 2021, 35000);
    //        car2.AcceptCarDetails();
    //        car2.DisplayCarDetails();
    //    }
    //}


    //  Question 3 Start from here.

    class Program
    {
        static bool IsValidPassword(string password)
        {
            if (password.Length < 6)
            {
                Console.WriteLine("Password must be at least 6 characters long.");
                return false;
            }

            if (!Regex.IsMatch(password, @"[A-Z]"))
            {
                Console.WriteLine("Password must contain at least one uppercase letter.");
                return false;
            }

            if (!Regex.IsMatch(password, @"\d"))
            {
                Console.WriteLine("Password must contain at least one digit.");
                return false;
            }

            return true;
        }

        static void Main()
        {
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            if (IsValidPassword(password))
            {
                Console.WriteLine("Password is valid.");
            }
            else
            {
                Console.WriteLine("Password is invalid. Please try again.");
            }
        }
    }


}

