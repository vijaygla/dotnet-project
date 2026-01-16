using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesScheduleManager
{
    internal class MoviesMain
    {
        static void Main(string[] args)
        {
            MoviesMenu utility = new MoviesMenu();

            utility.ShowMenu();
        }
    }
}
