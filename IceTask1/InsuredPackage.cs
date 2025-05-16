using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceTask1
{ // <-- Opening curly brace for the namespace

    // InsuredPackage class inherits from the abstract Package class
    public class InsuredPackage : Package
    {
        // Parameterized constructor
        // It calls the base class constructor using the 'base' keyword
        public InsuredPackage(int weight, char method) : base(weight, method)
        {
            // No additional initialization needed in this constructor for now
        }

        // Implementation of the abstract increaseCost() method
        // This method calculates and returns the insurance cost based on the base shipping cost
        public override double increaseCost()
        {
            // Get the base shipping cost using the calcCost() method from the base class
            double baseShippingCost = calcCost();
            double insuranceCost = 0.0;

            // Determine insurance cost based on the base shipping cost (Table 2)
            if (baseShippingCost >= 0.00 && baseShippingCost <= 1.00)
            {
                insuranceCost = 2.45;
            }
            else if (baseShippingCost >= 1.01 && baseShippingCost <= 3.00)
            {
                insuranceCost = 3.95;
            }
            else if (baseShippingCost >= 3.01)
            {
                insuranceCost = 5.55;
            }
            // Note: No explicit handling for negative base costs as calcCost should not return negative

            return insuranceCost;
        }

        // Optional: Override the display method to show total cost including insurance
        // If you want display() to show the total cost in the derived class, you would override it like this:
        // public override void display()
        // {
        //     // Call the base display to show weight, method, and base cost
        //     base.display();
        //
        //     // Calculate the total cost
        //     double totalCost = calcCost() + increaseCost();
        //
        //     // Display the insurance cost and total cost
        //     Console.WriteLine($"  Insurance Cost: ${increaseCost():F2}");
        //     Console.WriteLine($"  Total Cost: ${totalCost:F2}");
        // }
    }

} // <-- Closing curly brace for the namespace