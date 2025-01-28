using Saxess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Saxess
{
    internal class AddNewTreatmentMenu : Menu
    {
        public override void ViewMenu()
        {
            using (var context = new SassexDbContext())
            {
                while (true)
                {
                    try
                    {
                        Console.Write("Enter the name of the new treatment:");
                        var treatmentName = Console.ReadLine();
                        foreach (var _treatment in context.Treatments)
                        {
                            if (_treatment.TreatmentName == treatmentName)
                            {
                                throw new Exception("Treatment already exists");
                            }
                        }
                        if (treatmentName.Trim() == "")
                        {
                            throw new Exception("Treatment name cannot be empty");
                        }
                        Console.Write("Enter the treatment type:");
                        var treatmentType = Console.ReadLine();
                        if (treatmentType.Trim() == "")
                        {
                            throw new Exception("Treatment type cannot be empty");
                        }

                        Console.Write("Enter the treatment price:");
                        var treatmentPrice = decimal.Parse(Console.ReadLine());
                        if (treatmentPrice <= 0)
                        {
                            throw new Exception("Invalid Price");
                        }


                        var treatment = new Treatment
                        {
                            TreatmentName = treatmentName,
                            TreatmentType = treatmentType,
                            Price = treatmentPrice
                        };

                        context.Treatments.Add(treatment);
                        context.SaveChanges();
                        Console.WriteLine("Added new treatment");
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(e.Message);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }
    }
}
