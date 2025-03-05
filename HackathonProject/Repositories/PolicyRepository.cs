using InsurancePolicyManagementApp.Interfaces;
using InsurancePolicyManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InsurancePolicyManagementApp.Repositories
{
    public class PolicyRepository : IPolicyRepository
    {
        private List<Policy> policies = new List<Policy>();

       
        public void AddPolicy(Policy policy)
        {
            
            if (policies.Any(p => p.PolicyID == policy.PolicyID))
            {
                throw new Exception("Policy ID already exists.");
            }
            policies.Add(policy);
        }

        
        public void UpdatePolicy(int policyID, Policy updatedPolicy)
        {
            var policy = policies.FirstOrDefault(p => p.PolicyID == policyID);
            if (policy == null)
            {
                throw new Exception("Policy not found.");
            }
            policy.PolicyHolderName = updatedPolicy.PolicyHolderName;
            policy.PolicyType = updatedPolicy.PolicyType;
            policy.StartDate = updatedPolicy.StartDate;
            policy.EndDate = updatedPolicy.EndDate;
        }

       
        public Policy GetPolicyByID(int policyID)
        {
            return policies.FirstOrDefault(p => p.PolicyID == policyID);
        }

      
        public List<Policy> GetAllPolicies()
        {
            return policies;
        }

        
        public void DeletePolicy(int policyID)
        {
            var policy = policies.FirstOrDefault(p => p.PolicyID == policyID);
            if (policy == null)
            {
                throw new Exception("Policy not found.");
            }
            policies.Remove(policy);
        }
    }
}
