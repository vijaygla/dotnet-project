using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesScheduleManager
{
    internal class Movies
    {
        public string Title { get; set; }
        public string Time { get; set; }

        public Movies(string title, string time)
        {
            Title = title;
            Time = time;
        }
    }
}
