using InsurancePolicyManagementApp.Models;
using InsurancePolicyManagementApp.Repositories;
using InsurancePolicyManagementApp.Exceptions;
using InsurancePolicyManagementApp.Interfaces;
using System;
using System.Collections.Generic;

namespace InsurancePolicyManagementApp
{
    class Program
    {
        static IPolicyRepository policyRepository = new PolicyRepository();

        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("Insurance Policy Management System");
                Console.WriteLine("1. Add a New Policy");
                Console.WriteLine("2. View All Policies");
                Console.WriteLine("3. Search Policy by ID");
                Console.WriteLine("4. Update Policy");
                Console.WriteLine("5. Delete Policy");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddPolicy();
                        break;
                    case "2":
                        ViewAllPolicies();
                        break;
                    case "3":
                        SearchPolicyByID();
                        break;
                    case "4":
                        UpdatePolicy();
                        break;
                    case "5":
                        DeletePolicy();
                        break;
                    case "6":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private static void AddPolicy()
        {
            try
            {
                Console.Write("Enter Policy ID: ");
                int policyID = int.Parse(Console.ReadLine());

                Console.Write("Enter Policy Holder Name: ");
                string holderName = Console.ReadLine();

                Console.Write("Enter Policy Type (Life, Health, Vehicle, Property): ");
                PolicyType policyType = (PolicyType)Enum.Parse(typeof(PolicyType), Console.ReadLine());

                Console.Write("Enter Start Date (yyyy-mm-dd): ");
                DateTime startDate = DateTime.Parse(Console.ReadLine());

                Console.Write("Enter End Date (yyyy-mm-dd): ");
                DateTime endDate = DateTime.Parse(Console.ReadLine());

                var policy = new Policy(policyID, holderName, policyType, startDate, endDate);
                policyRepository.AddPolicy(policy);
                Console.WriteLine("Policy added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.WriteLine(); 
            Console.ReadLine();
        }

        private static void ViewAllPolicies()
        {
            var policies = policyRepository.GetAllPolicies();
            Console.WriteLine("All Policies:");

            foreach (var policy in policies)
            {
                Console.WriteLine(policy); 
                Console.WriteLine(); 
            }

            Console.ReadLine(); 
        }


        private static void SearchPolicyByID()
        {
            try
            {
                Console.Write("Enter Policy ID to search: ");
                int policyID = int.Parse(Console.ReadLine());

                var policy = policyRepository.GetPolicyByID(policyID);
                if (policy != null)
                {

                    Console.WriteLine($"Policy ID: {policy.PolicyID}");
                    Console.WriteLine($"Holder: {policy.PolicyHolderName}");
                    Console.WriteLine($"Type: {policy.PolicyType}");
                    Console.WriteLine($"Start Date: {policy.StartDate.ToShortDateString()}");
                    Console.WriteLine($"End Date: {policy.EndDate.ToShortDateString()}");
                }
                else
                {
                    Console.WriteLine("Policy not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.ReadLine();
        }


        private static void UpdatePolicy()
        {
            try
            {
                Console.Write("Enter Policy ID to update: ");
                int policyID = int.Parse(Console.ReadLine());

                Console.Write("Enter updated Policy Holder Name: ");
                string holderName = Console.ReadLine();

                Console.Write("Enter updated Policy Type (Life, Health, Vehicle, Property): ");
                PolicyType policyType = (PolicyType)Enum.Parse(typeof(PolicyType), Console.ReadLine());

                Console.Write("Enter updated Start Date (yyyy-mm-dd): ");
                DateTime startDate = DateTime.Parse(Console.ReadLine());

                Console.Write("Enter updated End Date (yyyy-mm-dd): ");
                DateTime endDate = DateTime.Parse(Console.ReadLine());

                var updatedPolicy = new Policy(policyID, holderName, policyType, startDate, endDate);
                policyRepository.UpdatePolicy(policyID, updatedPolicy);
                Console.WriteLine("Policy updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.WriteLine();
            Console.ReadLine();
        }

        private static void DeletePolicy()
        {
            try
            {
                Console.Write("Enter Policy ID to delete: ");
                int policyID = int.Parse(Console.ReadLine());
                policyRepository.DeletePolicy(policyID);
                Console.WriteLine("Policy deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.WriteLine(); 
            Console.ReadLine();
        }

    }
}
