using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using InsurancePolicyManagementApp.Interfaces;
using InsurancePolicyManagementApp.Models;
using CollectionsHackathon.Utility;

namespace InsurancePolicyManagementApp.Repositories
{
    public class PolicyRepository : IPolicyRepository
    {
        private string connectionString = DbConnUtil.GetConnectionString(); // Get the connection string

        // Add a new policy
        public void AddPolicy(Policy policy)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    var query = "INSERT INTO Policies (PolicyID, PolicyHolderName, PolicyType, StartDate, EndDate) " +
                                "VALUES (@PolicyID, @PolicyHolderName, @PolicyType, @StartDate, @EndDate)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@PolicyID", policy.PolicyID);
                    command.Parameters.AddWithValue("@PolicyHolderName", policy.PolicyHolderName);

                    // Convert PolicyType enum to its underlying integer value
                    command.Parameters.AddWithValue("@PolicyType", (int)policy.PolicyType);

                    command.Parameters.AddWithValue("@StartDate", policy.StartDate);
                    command.Parameters.AddWithValue("@EndDate", policy.EndDate);

                    int rowsAffected = command.ExecuteNonQuery(); // Execute the insert query

                    if (rowsAffected > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        //Console.WriteLine("Policy added successfully.");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: Policy not added.");
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error adding policy: {ex.Message}");
                }
                finally
                {
                    Console.ResetColor();
                }
            }
        }

        // Update an existing policy
        public void UpdatePolicy(int policyID, Policy updatedPolicy)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    var query = "UPDATE Policies SET PolicyHolderName = @PolicyHolderName, " +
                                "PolicyType = @PolicyType, StartDate = @StartDate, EndDate = @EndDate " +
                                "WHERE PolicyID = @PolicyID";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@PolicyID", policyID);
                    command.Parameters.AddWithValue("@PolicyHolderName", updatedPolicy.PolicyHolderName);

                    // Convert PolicyType enum to its underlying integer value
                    command.Parameters.AddWithValue("@PolicyType", (int)updatedPolicy.PolicyType);

                    command.Parameters.AddWithValue("@StartDate", updatedPolicy.StartDate);
                    command.Parameters.AddWithValue("@EndDate", updatedPolicy.EndDate);

                    int rowsAffected = command.ExecuteNonQuery(); // Execute the update query

                    if (rowsAffected > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        //Console.WriteLine("Policy updated successfully.");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: Policy not found.");
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error updating policy: {ex.Message}");
                }
                finally
                {
                    Console.ResetColor();
                }
            }
        }

        // Get a policy by ID
        public Policy GetPolicyByID(int policyID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    var query = "SELECT * FROM Policies WHERE PolicyID = @PolicyID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@PolicyID", policyID);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        return new Policy(
                            (int)reader["PolicyID"],
                            reader["PolicyHolderName"].ToString(),
                            (PolicyType)Enum.Parse(typeof(PolicyType), reader["PolicyType"].ToString()),
                            (DateTime)reader["StartDate"],
                            (DateTime)reader["EndDate"]
                        );
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Policy not found.");
                        return null; // No policy found with the given ID
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error fetching policy: {ex.Message}");
                    return null;
                }
                finally
                {
                    Console.ResetColor();
                }
            }
        }

        // Get all policies
        public List<Policy> GetAllPolicies()
        {
            List<Policy> policies = new List<Policy>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    var query = "SELECT * FROM Policies";
                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        policies.Add(new Policy(
                            (int)reader["PolicyID"],
                            reader["PolicyHolderName"].ToString(),
                            (PolicyType)Enum.Parse(typeof(PolicyType), reader["PolicyType"].ToString()),
                            (DateTime)reader["StartDate"],
                            (DateTime)reader["EndDate"]
                        ));
                    }

                    return policies;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error fetching policies: {ex.Message}");
                    return policies;
                }
                finally
                {
                    Console.ResetColor();
                }
            }
        }

        // Delete a policy by ID
        public void DeletePolicy(int policyID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    var query = "DELETE FROM Policies WHERE PolicyID = @PolicyID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@PolicyID", policyID);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        //Console.WriteLine("Policy deleted successfully.");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: Policy not found.");
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error deleting policy: {ex.Message}");
                }
                finally
                {
                    Console.ResetColor();
                }
            }
        }
    }
}
