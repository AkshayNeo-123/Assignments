using System;

class Program
{
    static void Main()
    {

        Console.Write("Enter Student Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Student Age: ");
        int age;
        if (!int.TryParse(Console.ReadLine(), out age))
        {
            Console.WriteLine("Invalid input! Age must be a numeric value.");
            return;
        }

        Console.Write("Enter Student Percentage: ");
        float percentage;
        if (!float.TryParse(Console.ReadLine(), out percentage))
        {
            Console.WriteLine("Invalid input! Percentage must be a numeric value.");
            return;
        }

        Console.Write("Enter Student Email: ");
        string email = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(email))
        {
            Console.WriteLine("Email cannot be empty.");
            return;
        }


        Console.WriteLine("\nStudent Details:");
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Age: {age}");
        Console.WriteLine($"Percentage: {percentage}%");
        Console.WriteLine($"Email: {email}");


        Console.Write("\nEnter Patient Discharge Date or press Enter keyy if not discharged: ");
        string dischargeInput = Console.ReadLine();
        DateTime? dischargeDate = string.IsNullOrWhiteSpace(dischargeInput) ? (DateTime?)null : DateTime.Parse(dischargeInput);

        Console.WriteLine("\nPatient Discharge Status:");
        Console.WriteLine(dischargeDate.HasValue ? $"Discharged on: {dischargeDate.Value:yyyy-MM-dd}" : "Not Discharged");



    }
}
