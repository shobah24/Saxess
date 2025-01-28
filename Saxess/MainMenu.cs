namespace Saxess
{
    public class MainMenu : Menu
    {

        private string[] menuchoices = { "Employee Management", "Treatments", "Bookings" };
        public EmployeeMenu em;

        public MainMenu()
        {
            em = new EmployeeMenu();
        }
        public override void ViewMenu()
        {

            Console.WriteLine("SAXXEEESSSSSZZZ");

            Console.WriteLine("Main Menu");
            for(int i = 0; i < menuchoices.Length; i++)
            {
                Console.WriteLine($"{i}: {menuchoices[i]}");
            }
            int choice;
            switch(choice)
            {
                case 0:
                    em.ViewMenu();
                    break;
                case 1:
                    break;
                case 2:
                    break;
                default:
                    break;
                 

            }


        }

    }
}
