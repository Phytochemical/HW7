using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7
{
    class InventoryTracker
    {
        public int indexToDeleteUserPrompt;
        // public int maxNumItem;

        UserInput myUserInput = new UserInput();

        public string[] inventoryTrackerArray;
        // string[] inventoryTracker = new string[3];

        public void Start()
        {
            UserMenuInput();
        }

        public InventoryTracker(int maxNumItem = 0)
        // public InventoryTracker(int maxNumItem)
        {
            inventoryTrackerArray = new string[maxNumItem];
        }

        /// <summary>
        /// executes until user format is correct
        /// </summary>
        public void CreateArrayInventory()
        {
            bool isMaxIndexValid = false;

            do
            {
                isMaxIndexValid = IsValid();
            }
            while (isMaxIndexValid == false);
        }

        /// <summary>
        /// returns true if user input is correct format
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            int maxIndex;
            int num;
            string strMaxIndex;
            bool isNumeric = true;

            Console.Out.Write("\nInitializing list \nEnter total number of items for the list 10 to 100 ");
            strMaxIndex = Console.ReadLine();

            if (int.TryParse(strMaxIndex, out num))
            {
                maxIndex = Int32.Parse(strMaxIndex);

                // returns true if the output is numeric try/catch internally without implementing exceptions
                if (maxIndex < 9 || maxIndex > 101)
                {
                    Console.Out.WriteLine("Invalid numeric value. Please use number 10 to 100");
                    Console.Out.WriteLine("isNumeric {0}", isNumeric);

                    isNumeric = false;
                    Console.Out.WriteLine("isNumeric {0}", isNumeric);
                }
                else
                {
                    // set array size from user input
                    // int[] inputInventory = new int[maxIndex];
                    inventoryTrackerArray = new string[maxIndex];
                    Console.Out.WriteLine("The list size is array size [{0}]", maxIndex);
                }
            }
            else
            {
                Console.Out.WriteLine("Invalid format. Please use correct format");
                isNumeric = false;
            }
            Console.Out.WriteLine("isNumeric {0}", isNumeric);
            return isNumeric;
        }

        public void UserMenuInput()
        {
            int userInputFromMenu;

            // set array size from user input
            CreateArrayInventory();

            // do while user input isn't to exit
            do
            {
                myUserInput.MenuDisplay();
                userInputFromMenu = myUserInput.userMenuInput("Enter option number ");

                switch (userInputFromMenu)
                {
                    case 1:
                        Console.Out.WriteLine("Add items ");
                        AddElements();
                        break;
                    case 2:
                        Console.Out.WriteLine("Change items ");
                        ChangeValue();
                        break;
                    case 3:
                        Console.Out.WriteLine("Delete items ");
                        DisplayArray();
                        Console.Out.WriteLine("\nUserInputRemove");
                        myUserInput.UserInputRemove();
                        indexToDeleteUserPrompt = myUserInput.indexToDelete;
                        Console.Out.WriteLine("indexToDeleteUserPrompt " + indexToDeleteUserPrompt);
                        DeleteElementAt(indexToDeleteUserPrompt);
                        Console.Out.WriteLine("indexToDeleteUserPrompt " + indexToDeleteUserPrompt);
                        DisplayArrayIndex();
                        Console.Out.WriteLine("\n");
                        break;
                    case 4:
                        Console.Out.WriteLine("List items ");
                        DisplayArray();
                        Console.Out.WriteLine("\n");
                        break;
                    case 0:
                        Console.Out.WriteLine("Exiting ");
                        break;

                    default:
                        Console.Out.WriteLine("Please enter correct option ");
                        break;
                }
            }
            while (userInputFromMenu != 0);
        }

        /// <summary>
        /// check if index is out of bounds
        /// </summary>
        /// <param name="index"></param>
        /// <returns>bool</returns>
        public bool CheckIndex(int indexToDeleteUserPrompt)
        {
            bool condition = true;
            Console.Out.WriteLine("indexToDeleteUserPrompt is within bounds " + condition);
            Console.Out.WriteLine("indexToDeleteUserPrompt  " + indexToDeleteUserPrompt);
            return (indexToDeleteUserPrompt >= 0) && (indexToDeleteUserPrompt < inventoryTrackerArray.Length);
        }

        // add items
        // TODO add array check
        public void AddElements()
        {
            int index;

            // iterate and add elements from userInput
            for (index = 0; index < inventoryTrackerArray.Length; index++)
            {
                Console.Out.Write("Enter items to be added ");
                inventoryTrackerArray[index] = Console.ReadLine();
            }
        }

        // delete items
        /// <summary>
        /// delete element at specified index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool DeleteElementAt(int indexToDeleteUserPrompt)
        {
            // check if the array is empty
            bool IsArrayEmpty = false;
            Console.WriteLine("IsArrayEmpty " + IsArrayEmpty);
            Console.Out.WriteLine("indexToDeleteUserPrompt  " + indexToDeleteUserPrompt);

            // if index is empty return true
            // don't use else or code returns error
            if (CheckIndex(indexToDeleteUserPrompt))
            {
                inventoryTrackerArray[indexToDeleteUserPrompt] = null;
                Console.WriteLine("Empty element at indexToDeleteUserPrompt [{0}] {1}", indexToDeleteUserPrompt, inventoryTrackerArray[indexToDeleteUserPrompt]);
                Console.WriteLine(" ");
                // move element so no index contains empty element
                MoveEmptyElement(indexToDeleteUserPrompt);
                IsArrayEmpty = true;
            }
            Console.WriteLine("IsArrayEmpty " + IsArrayEmpty);
            return IsArrayEmpty;
        }

        // move index contains empty element
        public void MoveEmptyElement(int indexToDeleteUserPrompt)
        {
            int i;
            int counter;

            Console.WriteLine("MoveEmptyElement");

            for (i = 0; i < inventoryTrackerArray.Length; i++)
            {
                Console.WriteLine("inventoryTrackerArray[{0}] {1}", i, inventoryTrackerArray[i]);
            }

            Console.WriteLine("move index by one");

            // the element after the indexToDelete need to move by one index
            for (counter = indexToDeleteUserPrompt + 1; counter < inventoryTrackerArray.Length; counter++)
            {
                Console.WriteLine("counter {0}", counter);
                // move index containing empty element by one
                // add element to previous index
                inventoryTrackerArray[counter - 1] = inventoryTrackerArray[counter];
                Console.WriteLine("inventoryTrackerArray[{0}] {1}", counter - 1, inventoryTrackerArray[counter - 1]);
                Console.WriteLine("inventoryTrackerArray[{0}] {1}", counter, inventoryTrackerArray[counter]);
                // empty last element
                inventoryTrackerArray[counter] = string.Empty;
                Console.WriteLine("inventoryTrackerArray[{0}] {1}", counter, inventoryTrackerArray[counter]);
            }
        }

        // change items
        public void ChangeValue()
        {
            int revisedIndex;
            string revisedValue;

            // list inventory
            for (int index = 0; index < inventoryTrackerArray.Length; index++)
            {
                Console.WriteLine("[{0}] {1} ", index, inventoryTrackerArray[index]);
            }

            Console.Out.Write("\nEnter index for value change ");
            revisedIndex = Int32.Parse(Console.ReadLine());
            Console.WriteLine("index [{0}] {1} ", revisedIndex, inventoryTrackerArray[revisedIndex]);

            Console.Out.Write("\nEnter value ");
            revisedValue = Console.ReadLine();
            Console.WriteLine("index [{0}] {1}", revisedIndex, revisedValue);
            Console.WriteLine(" ");

            // add uer input value to index
            inventoryTrackerArray[revisedIndex] = revisedValue;

            for (int index = 0; index < inventoryTrackerArray.Length; index++)
            {
                Console.WriteLine("[{0}] {1} ", index, inventoryTrackerArray[index]);
            }
        }

        // display items
        public void DisplayArray()
        {
            foreach (string item in inventoryTrackerArray)
            {
                Console.Out.Write(item + " ");
            }

            Console.Out.WriteLine(" ");

            for (int index = 0; index < inventoryTrackerArray.Length; index++)
            {
                Console.WriteLine("[{0}] {1} ", index, inventoryTrackerArray[index]);
            }
        }

        // display with index
        public void DisplayArrayIndex()
        {
            int i;

            for (i = 0; i < inventoryTrackerArray.Length; i++)
            {
                Console.Out.WriteLine("inventoryTrackerArray[{0}] {1}", i, inventoryTrackerArray[i]);
            }
        }
    }
}
