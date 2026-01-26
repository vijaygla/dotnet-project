namespace BrowserBuddy
{
    internal class BrowserBuddyMenu
    {
        private BrowserApp browserApp;

        public BrowserBuddyMenu()
        {
            browserApp = new BrowserApp();
        }

        public void StartMenu()
        {
            bool isRunning = true;

            while(isRunning)
            {
                Console.WriteLine("=== BrowserBuddy Management System ===");
                Console.WriteLine("1. Open new Tab");
                Console.WriteLine("2. Close Tab");
                Console.WriteLine("3. Backward Tab");
                Console.WriteLine("4. Forward Tab");
                Console.WriteLine("5. Restore closed Tab");
                Console.WriteLine("6. Show current Tab");
                Console.WriteLine("7. Exit applicaion");

                Console.Write("Enter your choice: ");
                int choice;

                bool isValidInput = int.TryParse(Console.ReadLine(), out choice);
                if(!isValidInput)
                {
                    Console.WriteLine("Invalid Input Please enter a valid enter as given in menu");
                    continue;
                }
                
                switch(choice)
                {
                    case 1:
                        browserApp.OpenNewTab();
                        break;
                    case 2:
                        browserApp.CloseTab();
                        break;
                    case 3:
                        browserApp.BackwardTab();
                        break;
                    case 4:
                        browserApp.ForwardTab();
                        break;
                    case 5:
                        browserApp.RestoreClosedTab();
                        break;
                    case 6:
                        browserApp.ShowCurrentTab();
                        break;
                    case 7:
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input menu");
                        break;
                }
            }
        }
    }
}
