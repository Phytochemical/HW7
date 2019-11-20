using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7
{
    public class UserInput
    {
        // obtain user user input
        // pass string -> return int
        public int indexToDelete;

        public int userMenuInput(string userPrompt)
        {
            int userInputNumber;
            bool userInputCorrect;

            // do while execute the block -> check condition
            do
            {
                // prints the prompt "Enter option number"
                Console.Out.Write(userPrompt);

                // convert string to int and returns bool
                userInputCorrect = Int32.TryParse(Console.ReadLine(), out userInputNumber);
            }
            while (userInputCorrect == false);

            return userInputNumber;
        }

        public void MenuDisplay()
        {
            Console.Out.WriteLine("\n ********* Inventory tracker menu **********");
            Console.Out.WriteLine("  1 Add items");
            Console.Out.WriteLine("  2 Change items");
            Console.Out.WriteLine("  3 Delete items");
            Console.Out.WriteLine("  4 List items");
            Console.Out.WriteLine("  0 Exit");
            Console.Out.WriteLine(" ******************************************* \n");
        }

        public int UserInputRemove()
        {
            Console.Out.Write("\nEnter index to add/change/delete value ");
            indexToDelete = Int32.Parse(Console.ReadLine());

            return indexToDelete;
        }
    }
}
