using System; // Required for Console.WriteLine, char.ToUpper, and F2 formatting
// The following using directives are often included by default but not strictly necessary for this specific class.
// They can be removed if not used elsewhere in your project.
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceTask1
{
    /// <summary>
    /// Represents a package to be shipped.
    /// This class is abstract and provides base functionality for package operations.
    /// </summary>
    public abstract class Package
    {
        // Data members
        // weight will store the package’s weight.
        private int weight;
        // method must store the shipping method. The shipping method is a character: A for air, T for truck or M for mail.
        private char method;

        /// <summary>
        /// Parameterized constructor for the Package class.
        /// </summary>
        /// <param name="weight">The weight of the package in kilograms.</param>
        /// <param name="method">The shipping method: 'A' for Air, 'T' for Truck, or 'M' for Mail.</param>
        public Package(int weight, char method)
        {
            this.weight = weight;
            this.method = method;
        }

        /// <summary>
        /// Determines and returns the shipping cost based on the package's weight and shipping method,
        /// according to Table 1.
        /// </summary>
        /// <returns>The calculated shipping cost as a double.</returns>
        public double calcCost()
        {
            double shippingCost = 0.0;

            // Use ToUpper to handle both lowercase and uppercase method characters
            switch (char.ToUpper(this.method))
            {
                case 'A': // Air
                    if (this.weight >= 1 && this.weight <= 8)
                    {
                        shippingCost = 2.00;
                    }
                    else if (this.weight >= 9 && this.weight <= 16)
                    {
                        shippingCost = 3.00;
                    }
                    else if (this.weight >= 17)
                    {
                        shippingCost = 4.50;
                    }
                    // If weight is less than 1, cost remains 0.0 as per this logic.
                    break;
                case 'T': // Truck
                    if (this.weight >= 1 && this.weight <= 8)
                    {
                        shippingCost = 1.50;
                    }
                    else if (this.weight >= 9 && this.weight <= 16)
                    {
                        shippingCost = 2.35;
                    }
                    else if (this.weight >= 17)
                    {
                        shippingCost = 3.25;
                    }
                    // If weight is less than 1, cost remains 0.0.
                    break;
                case 'M': // Mail
                    if (this.weight >= 1 && this.weight <= 8)
                    {
                        shippingCost = 0.50; // Table 1 shows .50
                    }
                    else if (this.weight >= 9 && this.weight <= 16)
                    {
                        shippingCost = 1.50;
                    }
                    else if (this.weight >= 17)
                    {
                        shippingCost = 2.15;
                    }
                    // If weight is less than 1, cost remains 0.0.
                    break;
                default:
                    // If an unrecognized shipping method is provided, the cost remains 0.0.
                    // Consider logging a warning or throwing an ArgumentException for robust error handling.
                    // Console.WriteLine($"Warning: Invalid shipping method '{this.method}' encountered for a package with weight {this.weight}kg.");
                    break;
            }
            return shippingCost;
        }

        /// <summary>
        /// Displays the package details, including weight, shipping method, and calculated shipping cost.
        /// The output format is based on common practice as Figure 2 was not provided.
        /// </summary>
        public void display()
        {
            string methodNameFull;
            // Use ToUpper to handle both lowercase and uppercase method characters
            char normalizedMethod = char.ToUpper(this.method);

            switch (normalizedMethod)
            {
                case 'A':
                    methodNameFull = "Air";
                    break;
                case 'T':
                    methodNameFull = "Truck";
                    break;
                case 'M':
                    methodNameFull = "Mail";
                    break;
                default:
                    methodNameFull = "Unknown Method";
                    break;
            }

            Console.WriteLine("Package Details:");
            Console.WriteLine($"Weight: {this.weight} kg");
            Console.WriteLine($"Shipping Method: {methodNameFull} ({normalizedMethod})");
            Console.WriteLine($"Shipping Cost: ${calcCost():F2}"); // :F2 formats the double to two decimal places
        }

        /// <summary>
        /// Abstract method to calculate an increase in cost.
        /// This method must be implemented by any concrete (non-abstract) derived class.
        /// It's intended for additional charges, such as insurance (potentially based on Table 2).
        /// </summary>
        /// <returns>The value of the increased cost as a double.</returns>
        public abstract double increaseCost();
    }
}