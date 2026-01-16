namespace BrowserBuddy
{
    public class TabHistoryNode
    {
        private string url;
        private TabHistoryNode previous;
        private TabHistoryNode next;

        public TabHistoryNode(string urlValue)
        {
            url = urlValue;
            previous = null;
            next = null;
        } 

        public string Url
        {
            get {return url; }
        }

        public TabHistoryNode Previous
        {
            get {return previous; }
            set {previous = value; }
        }

        public TabHistoryNode Next
        {
            get {return next; }
            set {next = value; }
        }
    }
}
