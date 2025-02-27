using System;

1st Question
class SalaryCalculationSystem
{
    static void Main()
    {

        int numOfEmployees;


        Console.Write("Enter the number of employees: ");
        numOfEmployees = int.Parse(Console.ReadLine());


        double[] basicSalaries = new double[numOfEmployees];
        double[] ratings = new double[numOfEmployees];
        double[] finalSalaries = new double[numOfEmployees];


        for (int i = 0; i < numOfEmployees; i++)
        {
            Console.WriteLine($"\nEmployee {i + 1}:");


            Console.Write("Enter the basic salary: ");
            basicSalaries[i] = double.Parse(Console.ReadLine());


            Console.Write("Enter the performance rating (0 to 10): ");
            ratings[i] = double.Parse(Console.ReadLine());


            double taxDeduction = basicSalaries[i] * 0.10;


            double bonus = 0;

            if (ratings[i] >= 8)
            {
                bonus = basicSalaries[i] * 0.20;
            }
            else if (ratings[i] >= 5)
            {
                bonus = basicSalaries[i] * 0.10;
            }


            finalSalaries[i] = basicSalaries[i] - taxDeduction + bonus;


            Console.WriteLine($"\nEmployee {i + 1} Salary Details:");
            Console.WriteLine($"Basic Salary: {basicSalaries[i]}");
            Console.WriteLine($"Tax Deduction: {taxDeduction}");
            Console.WriteLine($"Bonus: {bonus}");
            Console.WriteLine($"Net Salary: {finalSalaries[i]}\n");
        }


        Console.WriteLine("\nFinal Salary Details for All Employees:");
        for (int i = 0; i < numOfEmployees; i++)
        {
            Console.WriteLine($"Employee {i + 1}: Net Salary = {finalSalaries[i]}");
        }
    }
}



2nd Question

class TrainTicketBooking
{
    static void Main()
    {
        int generalPrice = 200;
        int acPrice = 1000;
        int sleeperPrice = 500;

        string[] ticketTypes = { "General", "AC", "Sleeper" };
        int[] ticketPrices = { generalPrice, acPrice, sleeperPrice };

        while (true)
        {

            Console.WriteLine("Select a ticket type:");
            for (int i = 0; i < ticketTypes.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {ticketTypes[i]} - Rs {ticketPrices[i]}");
            }

            Console.WriteLine("Enter the number of your choice (1 for General, 2 for AC, 3 for Sleeper), or type 'exit' to quit:");
            string input = Console.ReadLine();


            if (input.ToLower() == "exit")
            {
                Console.WriteLine("Thank you for using the ticket booking system!");
                break;
            }


            int ticketTypeIndex;
            if (int.TryParse(input, out ticketTypeIndex) && ticketTypeIndex >= 1 && ticketTypeIndex <= 3)
            {
                ticketTypeIndex--;

                Console.WriteLine($"You selected {ticketTypes[ticketTypeIndex]} ticket.");


                Console.WriteLine("Enter the number of tickets you want to book:");
                int numberOfTickets;
                if (int.TryParse(Console.ReadLine(), out numberOfTickets) && numberOfTickets > 0)
                {

                    int totalCost = ticketPrices[ticketTypeIndex] * numberOfTickets;
                    Console.WriteLine($"Total cost for {numberOfTickets} {ticketTypes[ticketTypeIndex]} ticket(s): Rs {totalCost}");
                }
                else
                {
                    Console.WriteLine("Invalid number of tickets. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid selection. Please try again.");
            }


            Console.WriteLine("\nDo you want to book more tickets? (Type 'exit' to quit or press any key to continue)");
            string continueBooking = Console.ReadLine();
            if (continueBooking.ToLower() == "exit")
            {
                Console.WriteLine("Thank you for using the ticket booking system!");
                break;
            }
        }
    }
}


3nd Question

class OnlineShoppingPlatform
{
    static void Main()
    {
       
        string[] userIds = { "user1", "user2", "user3", "user4" };
        double[] walletBalances = { 150.75, 200.50, 320.30, 400.10 };

        string inputId;
        bool idFound = false;

        Console.WriteLine("Welcome to the Online Shopping Platform!");

       
        while (!idFound)
        {
            Console.Write("Please enter your user ID: ");
            inputId = Console.ReadLine();

           
            for (int i = 0; i < userIds.Length; i++)
            {
                if (inputId == userIds[i])
                {
                   
                    Console.WriteLine($"Your wallet balance is: ${walletBalances[i]:F2}");
                    idFound = true; 
                    break;
                }
            }

           
            if (!idFound)
            {
                Console.WriteLine("Invalid user ID. Please try again.");
            }
        }
    }
}


