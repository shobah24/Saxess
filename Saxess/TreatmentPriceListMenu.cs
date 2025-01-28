using Saxess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saxess
{
    internal class TreatmentPriceListMenu : Menu
    {
        public override void ViewMenu()
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
    }
}
