using System;

namespace InsurancePolicyManagementApp.Models
{
    public enum PolicyType
    {
        Life,
        Health,
        Vehicle,
        Property
    }

    public class Policy
    {
        public int PolicyID { get; set; }
        public string PolicyHolderName { get; set; }
        public PolicyType PolicyType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Constructor
        public Policy(int policyID, string policyHolderName, PolicyType policyType, DateTime startDate, DateTime endDate)
        {
            PolicyID = policyID;
            PolicyHolderName = policyHolderName;
            PolicyType = policyType;
            StartDate = startDate;
            EndDate = endDate;
        }

        // ToString method for displaying policy details
        public override string ToString()
        {
            return $"Policy ID: {PolicyID}{Environment.NewLine}" +
                   $"Holder: {PolicyHolderName}{Environment.NewLine}" +
                   $"Type: {PolicyType}{Environment.NewLine}" +
                   $"Start Date: {StartDate.ToShortDateString()}{Environment.NewLine}" +
                   $"End Date: {EndDate.ToShortDateString()}";
        }

    }
}
