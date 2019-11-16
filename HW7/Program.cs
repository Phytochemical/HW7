using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7
{
    class Program
    {
        public static void Main(string[] args)
        {
            // UserInput myUserInput = new UserInput();
            // myUserInput.userMenuInput();

            InventoryTracker myInventoryTracker = new InventoryTracker();
            // InventoryTracker myInventoryTracker = new InventoryTracker(0);
            myInventoryTracker.Start();
        }
    }
}
