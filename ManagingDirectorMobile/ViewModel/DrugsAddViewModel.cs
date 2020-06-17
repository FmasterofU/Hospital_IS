using ManagingDirectorMobile.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingDirectorMobile.ViewModel
{
    class DrugsAddViewModel
    {
        private static readonly Random _random = new Random();
        public static void Add(String name, int number)
        {
            Drug.drugs.Add(new Drug() { Name = name, Threshold=number,Code= _random.Next(0,10000).ToString() });
        }
    }
}
