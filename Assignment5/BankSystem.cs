using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentDay5
{
    class BankAccountSystem
    {

        static Dictionary<int, string> beneficiary = new Dictionary<int, string>
        {
            { 123456, "Jay" },
            { 234567, "Aman" },
            { 345678, "Ajay" }
        };

        public static void Run()
        {
            try
            {
                Console.WriteLine(" \n ===== Beneficiary Account Verificaton ==== ");
                Console.WriteLine("\n Enter Beneficiary Account Number: ");
                int accNumber = int.Parse(Console.ReadLine());


                if (!beneficiary.ContainsKey(accNumber))
                    throw new KeyNotFoundException("\n The account number was not found");

                Console.WriteLine($"\n Beneficiary found, Account Name : {beneficiary[accNumber]}");

            }
            catch (FormatException)
            {
                Console.WriteLine("\n Invalid Input .. Please Enter A Number");
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}