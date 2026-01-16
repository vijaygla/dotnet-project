namespace BrowserBuddy
{
    public class BrowserApp
    {
        private TabHistory tabHistory;
        private ClosedTabStack closedTabStack;

        public BrowserApp()
        {
            tabHistory = new TabHistory();
            closedTabStack = new ClosedTabStack();
        }

        public void OpenNewTab()
        {
            Console.Write("Enter any url : ");
            string url = Console.ReadLine();

            if(!string.IsNullOrEmpty(url))
            {
                tabHistory.VisitPage(url);
            }
            else
            {
                Console.WriteLine("Invalid url");
            }
        }

        public void CloseTab()
        {
            string currentPage = tabHistory.GetCurrentPage();

            if(!currentPage.Equals("No tab opend"))
            {
                closedTabStack.Push(currentPage);
                tabHistory.ClearHistory();
                Console.WriteLine("Tab closed");
            }
            else
            {
                Console.WriteLine("No active tab to close");
            }
        }

        public void BackwardTab()
        {
            tabHistory.NavigateBack();
        }

        public void ForwardTab()
        {
            tabHistory.NavigateForward();
        }

        public void RestoreClosedTab()
        {
            if (!closedTabStack.IsEmpty())
            {
                string url = closedTabStack.Pop();
                tabHistory.VisitPage(url);
                Console.WriteLine("Tab restored.");
            }
            else
            {
                Console.WriteLine("No closed tabs available.");
            }
        }

        public void ShowCurrentTab()
        {
            Console.WriteLine("Current Page: " + tabHistory.GetCurrentPage());
        }
    }
}
