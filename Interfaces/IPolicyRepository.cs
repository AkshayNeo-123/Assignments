using InsurancePolicyManagementApp.Models;
using System.Collections.Generic;

namespace InsurancePolicyManagementApp.Interfaces
{
    public interface IPolicyRepository
    {
        void AddPolicy(Policy policy);
        void UpdatePolicy(int policyID, Policy updatedPolicy);
        Policy GetPolicyByID(int policyID);
        List<Policy> GetAllPolicies();
        void DeletePolicy(int policyID);
    }
}
