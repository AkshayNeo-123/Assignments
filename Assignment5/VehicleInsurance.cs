using System;

namespace AssignmentDay5
{
    class VehicleInsurance
    {
        public abstract class VehicleInsurancePolicy
        {
            public string VehicleType { get; set; }
            public double VehicleValue { get; set; }

          
            public abstract double CalculatePremium();

            
            public void DisplayPolicyDetails()
            {
                Console.WriteLine($"Vehicle Type: {VehicleType}");
                Console.WriteLine($"Vehicle Value: {VehicleValue:C}");
                Console.WriteLine($"Premium: {CalculatePremium():C}");
            }
        }

       
        public class TwoWheelerInsurance : VehicleInsurancePolicy
        {
            public TwoWheelerInsurance(double value)
            {
                VehicleType = "Two-Wheeler";
                VehicleValue = value;
            }

           
            public override double CalculatePremium()
            {
                return VehicleValue * 0.05; 
            }
        }

        
        public class FourWheelerInsurance : VehicleInsurancePolicy
        {
            public FourWheelerInsurance(double value)
            {
                VehicleType = "Four-Wheeler";
                VehicleValue = value;
            }

          
            public override double CalculatePremium()
            {
                return VehicleValue * 0.07; 
            }
        }

       
        public class CommercialInsurance : VehicleInsurancePolicy
        {
            public CommercialInsurance(double value)
            {
                VehicleType = "Commercial";
                VehicleValue = value;
            }

           
            public override double CalculatePremium()
            {
                return VehicleValue * 0.1; 
            }
        }

       
        public static void Run()
        {
            try
            {
                Console.WriteLine("\n===== Vehicle Insurance System =====");
                Console.WriteLine("Enter Vehicle Type (1: Two-Wheeler, 2: Four-Wheeler, 3: Commercial): ");
                int choice = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the value of the vehicle: ");
                double vehicleValue = double.Parse(Console.ReadLine());

                VehicleInsurancePolicy policy = null;

                switch (choice)
                {
                    case 1:
                        policy = new TwoWheelerInsurance(vehicleValue);
                        break;
                    case 2:
                        policy = new FourWheelerInsurance(vehicleValue);
                        break;
                    case 3:
                        policy = new CommercialInsurance(vehicleValue);
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please enter a valid vehicle type.");
                        return;
                }

              
                policy.DisplayPolicyDetails();
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input! Please enter a valid number.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
