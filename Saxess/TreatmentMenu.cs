using Saxess.Models;
namespace Saxess
{
    public class TreatmentMenu : Menu
    {

        public override void ViewMenu()
        {

            Console.WriteLine("Treatments");
            Console.WriteLine("1. View Treatment and Price list");
            Console.WriteLine("2. Add new Treatment");
            ConsoleKeyInfo cki = Console.ReadKey(true);
            int choice = Int32.Parse(cki.KeyChar.ToString());
            switch(choice)
            {
                case 1: 
                    PriceList();
                        break;
                case 2: 
                    AddTreatment();
                    break;
                default:
                    break;
            }

        }

        public void PriceList()
        {

                    using(var context = new SassexDbContext())
            {
                Console.WriteLine("Treatment Price List");
                Console.WriteLine("Treatment Name".PadRight(25) + "Treatment Type".PadRight(25) + "Price".PadRight(25));
                foreach (var treatment in context.Treatments)
                {
                    Console.WriteLine(treatment.TreatmentName.PadRight(25) + treatment.TreatmentType.PadRight(25) + treatment.Price.ToString().PadRight(25));
                }
            }
        }

        public void AddTreatment()
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
