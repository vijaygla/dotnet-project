namespace BrowserBuddy
{
    public class TabHistory
    {
        private TabHistoryNode current;

        // method to visit the current page in the browser
        public void VisitPage(string url)
        {
            TabHistoryNode newNode = new TabHistoryNode(url);

            if(current != null)
            {
                current.Next = null;
                newNode.Previous = current;
                current.Next = newNode;
            }

            current = newNode;
        }

        // method to naviaget back in the browser
        public void NavigateBack()
        {
            if(current != null && current.Previous != null)
            {
                current = current.Previous;
            }
            else
            {
                Console.WriteLine("No previous page available");
            }
        }

        // method to naviagte forward
        public void NavigateForward()
        {
            if (current != null && current.Next != null)
            {
                current = current.Next;
            }
            else
            {
                Console.WriteLine("No forward page available.");
            }
        }

        // method to get the current page
        public string GetCurrentPage()
        {
            if(current == null)
            {
                return "No page opened";
            }
            return current.Url;
        }

        // method clear History
        public void ClearHistory()
        {
            current = null;
        }
    }
}
