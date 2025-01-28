using Microsoft.Identity.Client;
using System.Runtime.Intrinsics.X86;

namespace Saxess
{
    public class MainMenu : Menu
    {

        private string[] menuchoices = { "Employee Management", "Treatments", "Bookings", "Exit" };
        public EmployeeMenu em;
        public TreatmentMenu tm;
        public BookingMenu bm;

        public MainMenu()
        {
            em = new EmployeeMenu();
        }
        public override void ViewMenu()
        {
            bool running = true;
            Console.WriteLine("SAXXEEESSSSSZZZ");

            while(running)
            {

            Console.WriteLine("Main Menu");
            for(int i = 0; i < menuchoices.Length; i++)
            {
                Console.WriteLine($"{i}: {menuchoices[i]}");
            }
            ConsoleKeyInfo cki = Console.ReadKey(true);
            int choice = Int32.Parse(cki.Key.ToString());
            switch(choice)
            {
                case 0:
                    em.ViewMenu();
                    break;
                case 1:
                    tm.ViewMenu();
                    break;
                case 2:
                    bm.ViewMenu();
                    break;
                case 3:
                    running = false;
                        break;
                default:
                    break;
                 

            }

            }

        }

    }
}
