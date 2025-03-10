using System;
using System.Collections.Generic;



namespace Assingment6
{
    public class BankQueueSystem
    {
        private Queue<string> customerQueue;

        public BankQueueSystem()
        {
            customerQueue = new Queue<string>();
        }

        public void AddCustomer(string customerName)
        {
            customerQueue.Enqueue(customerName);
            Console.WriteLine($"{customerName} has taken a token and is in the queue.");
        }

        public void ServeCustomer()
        {
            if (customerQueue.Count > 0)
            {
                string customer = customerQueue.Dequeue();
                Console.WriteLine($"{customer} has been served.");
            }
            else
            {
                Console.WriteLine("No customers in the queue to serve.");
            }
        }

        public void CheckNextCustomer()
        {
            if (customerQueue.Count > 0)
            {
                string customer = customerQueue.Peek();
                Console.WriteLine($"{customer} is next in line.");
            }
            else
            {
                Console.WriteLine("No customers in the queue.");
            }
        }

        public void DisplayQueue()
        {
            if (customerQueue.Count > 0)
            {
                Console.WriteLine("Current queue: ");
                foreach (var customer in customerQueue)
                {
                    Console.WriteLine(customer);
                }
            }
            else
            {
                Console.WriteLine("The queue is empty.");
            }
        }

        public static void Run()
        {
            BankQueueSystem bankQueue = new BankQueueSystem();

            bankQueue.AddCustomer("Aniket");
            bankQueue.AddCustomer("Dinesh");
            bankQueue.AddCustomer("Raghav");

            bankQueue.CheckNextCustomer();

           
            bankQueue.ServeCustomer();

           
            bankQueue.CheckNextCustomer();

          
            bankQueue.DisplayQueue();

            
            bankQueue.ServeCustomer();
            bankQueue.ServeCustomer();

            
            bankQueue.ServeCustomer();
        }

    }
}
