using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceTask1
{
    // This is the single Program class containing the application's entry point
    public class Program
    {
        public static void Main(string[] args)
        {
            // Declare an array of type Package with the size of 3
            // Ensure the 'Package' class (abstract) and 'InsuredPackage' class are also defined
            // within this namespace or are properly referenced.
            Package[] packages = new Package[3];

            Console.WriteLine("--- Enter Package Details ---");

            // Prompt the user for details for the 3 objects and populate the array
            for (int i = 0; i < packages.Length; i++)
            {
                Console.WriteLine($"\nEntering details for Package {i + 1}:");

                int weight = 0;
                char method = ' ';
                bool validInput = false;

                // Input validation for weight
                while (!validInput)
                {
                    Console.Write("Enter weight (kg, integer > 0): ");
                    string weightInput = Console.ReadLine();
                    if (int.TryParse(weightInput, out weight) && weight > 0)
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a positive integer for weight.");
                    }
                }

                validInput = false; // Reset for method input

                // Input validation for method
                while (!validInput)
                {
                    Console.Write("Enter shipping method (A for Air, T for Truck, M for Mail): ");
                    string methodInput = Console.ReadLine()?.ToUpper(); // Read and convert to uppercase
                    if (!string.IsNullOrEmpty(methodInput) && methodInput.Length == 1)
                    {
                        method = methodInput[0];
                        if (method == 'A' || method == 'T' || method == 'M')
                        {
                            validInput = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid method. Please enter A, T, or M.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a single character (A, T, or M).");
                    }
                }

                // Create an InsuredPackage object and add it to the array
                // We use InsuredPackage because Package is abstract and cannot be instantiated directly.
                packages[i] = new InsuredPackage(weight, method);
            }

            Console.WriteLine("\n--- Displaying Package Details ---");

            // Using the array, display the data of all objects
            foreach (Package package in packages)
            {
                // Call the display method.
                // If InsuredPackage overrides display(), that version will be called (Polymorphism).
                // Otherwise, the base Package display() will be called.
                package.display();

                // To explicitly show the total cost calculated using the abstract method:
                // double totalCost = package.calcCost() + package.increaseCost();
                // Console.WriteLine($"  Insurance Cost: ${package.increaseCost():F2}"); // Calls the overridden method
                // Console.WriteLine($"  Total Cost: ${totalCost:F2}");

                Console.WriteLine("---------------------------"); // Separator for clarity
            }

            // Keep console window open until user presses Enter
            Console.WriteLine("\nPress Enter to exit.");
            Console.ReadLine();
        }
    }
}