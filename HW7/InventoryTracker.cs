using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7
{
    class InventoryTracker
    {
        public int indexUserPrompt;
        public int indexToDelete;
        public bool isValueEmpty;
        public bool isIndexEmpty;

        UserInput myUserInput = new UserInput();

        public string[] inventoryTrackerArray;
        // string[] inventoryTracker = new string[3];

        public void Start()
        {
            // set array size based on user input
            UserIndexInput();
            UserMenuInput();
        }

        public InventoryTracker(int maxNumItem = 0)
        // public InventoryTracker(int maxNumItem)
        {
            inventoryTrackerArray = new string[maxNumItem];
        }

        public void CreateArrayInventory()
        {
            bool isMaxIndexValid = false;

            do
            {
                isMaxIndexValid = IsValid();
            }
            while (isMaxIndexValid == false);

            DisplayArray();
        }

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
                if (maxIndex < 3)
                // if (maxIndex < 10 || maxIndex > 101)
                {
                    Console.Out.WriteLine("Invalid numeric value. Please use number 10 to 100");
                    Console.Out.WriteLine("isNumeric {0}", isNumeric);

                    isNumeric = false;
                    Console.Out.WriteLine("isNumeric {0}", isNumeric);
                }
                else
                {
                    // set array size from user input
                    inventoryTrackerArray = new string[maxIndex];
                    Console.Out.WriteLine("The list size [{0}]", maxIndex);
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

        public int UserPrompt()
        {
            int userInputFromMenu;

            myUserInput.MenuDisplay();
            userInputFromMenu = myUserInput.userMenuInput("Enter option number ");

            return userInputFromMenu;
        }

        public void UserIndexInput()
        {
            // set array size from user input
            CreateArrayInventory();
        }

        public void UserMenuInput()
        {
            int userInput;

            // do while user input isn't to exit
            do
            {
                userInput = UserPrompt();

                switch (userInput)
                {
                    case 1:
                        Console.Out.WriteLine("Add items ");
                        AddElement();
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
                        indexUserPrompt = myUserInput.indexToDelete;
                        Console.Out.WriteLine("indexUserPrompt " + indexUserPrompt);
                        DeleteElementAt(indexUserPrompt);
                        Console.Out.WriteLine("indexUserPrompt " + indexUserPrompt);
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
            while (userInput != 0);
        }

        /// <summary>
        /// check if index is out of bounds
        /// </summary>
        /// <param name="index"></param>
        /// <returns>bool</returns>
        public bool CheckIndex(int indexUserPrompt)
        {
            bool condition = true;

            return (indexUserPrompt >= 0) && (indexUserPrompt < inventoryTrackerArray.Length);
        }

        public string ReviseValue()
        {
            int revisedIndex;
            int outOfBounds;
            string revisedValue;
            bool isIndexNotOutOfBound;

            Console.Out.Write("\nEnter index to add/change/delete value ");
            revisedIndex = Int32.Parse(Console.ReadLine());
            Console.WriteLine("[{0}]", revisedIndex);

            // check indexOutOfBounds
            // if outOfBounds display error message
            isIndexNotOutOfBound = (CheckIndex(revisedIndex));

            if (isIndexNotOutOfBound == false)
            {
                Console.WriteLine("Enter correct index ");
                Console.WriteLine(" ");

                outOfBounds = revisedIndex - inventoryTrackerArray.Length;

                Console.WriteLine("Index [{0}] is out of bounds by {1}", revisedIndex, outOfBounds);

                // return to menu
                UserMenuInput();
            }

            Console.WriteLine("index [{0}] {1} ", revisedIndex, inventoryTrackerArray[revisedIndex]);

            Console.Out.Write("\nEnter value for [{0}] ", revisedIndex);
            revisedValue = Console.ReadLine();
            Console.WriteLine("index [{0}] {1}", revisedIndex, revisedValue);
            Console.WriteLine(" ");

            return inventoryTrackerArray[revisedIndex] = revisedValue;
        }

        public bool IsIndexOutOfBound(int indexUserPrompt)
        {
            bool isIndexOutOfBound = false;
            Console.WriteLine("isIndexOutOfBound " + isIndexOutOfBound);
            Console.Out.WriteLine("indexUserPrompt  " + indexUserPrompt);
            Console.WriteLine("CheckIndex(indexUserPrompt) {0} ", CheckIndex(indexUserPrompt));

            if (CheckIndex(indexUserPrompt))
            {
                Console.WriteLine("Idnex full [{0}] {1}", indexUserPrompt, inventoryTrackerArray[indexUserPrompt]);
                Console.WriteLine(" ");
                // move element so no index contains empty element
                // MoveEmptyElement(indexToDeleteUserPrompt);
                isIndexOutOfBound = true;
            }

            Console.WriteLine("isIndexOutOfBound " + isIndexOutOfBound);

            return isIndexOutOfBound;
        }

        public bool IsValueEmpty(int indexUserPrompt)
        {
            int currentIndex;
            string currentValue;
            bool isValueEmpty;

            currentIndex = myUserInput.indexToDelete;

            // display current value
            currentValue = inventoryTrackerArray[currentIndex];
            // Console.WriteLine("currentValue - {0} ", currentValue);
            // Console.WriteLine("index [{0}] {1} ", currentIndex, inventoryTrackerArray[currentIndex]);

            // IsNullOrEmpty
            isValueEmpty = string.IsNullOrEmpty(currentValue);

            if (!isValueEmpty)
            {
                Console.WriteLine("Array full. Please delete element");
            }

            return isValueEmpty;
        }

        public void AddElement()
        {
            bool isEmptyValue;

            // display array 
            DisplayArray();

            // index to add value
            myUserInput.UserInputRemove();

            indexUserPrompt = indexToDelete;

            // is index empty
            isEmptyValue = IsValueEmpty(indexUserPrompt);

            // if index is empty enable add value
            if (isEmptyValue == true)
            {
                AddElementAt();
            }

            DisplayArray();
        }

        // add items
        public void AddElementAt()
        {
            int currentIndex;
            string currentValue;
            bool isIndexEmpty;

            // check if index is empty
            isIndexEmpty = IsValueEmpty(indexUserPrompt);

            if (isIndexEmpty)
            {
                // if empty add element
                currentIndex = myUserInput.indexToDelete;

                // overwrite current empty value
                Console.Out.Write("\nEnter value ");
                currentValue = Console.ReadLine();
                inventoryTrackerArray[currentIndex] = currentValue;

                Console.Out.WriteLine("Item added {0} \nExisting function \nDisplaying list\n", currentValue);
            }
            // if full prompt delete
            else
            {
                Console.WriteLine("Array full. Please delete element");
            }
        }

        // delete items
        /// <summary>
        /// delete element at specified index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool DeleteElementAt(int indexUserPrompt)
        {
            // check if the array is empty
            bool isArrayEmpty = false;
            Console.WriteLine("isArrayEmpty default " + isArrayEmpty);
            Console.Out.WriteLine("indexUserPrompt  " + indexUserPrompt);

            // if index is empty return true
            // don't use else or code returns error
            if (CheckIndex(indexUserPrompt))
            {
                inventoryTrackerArray[indexUserPrompt] = null;
                Console.WriteLine("Empty element at indexUserPrompt [{0}] {1}", indexUserPrompt, inventoryTrackerArray[indexUserPrompt]);
                Console.WriteLine(" ");
                // move element so no index contains empty element
                MoveEmptyElement(indexUserPrompt);
                isArrayEmpty = true;
            }

            Console.WriteLine("isArrayEmpty " + isArrayEmpty);

            return isArrayEmpty;
        }

        // move index contains empty element
        public void MoveEmptyElement(int indexUserPrompt)
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
            for (counter = indexUserPrompt + 1; counter < inventoryTrackerArray.Length; counter++)
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
            // list inventory
            DisplayArray();

            ReviseValue();

            DisplayArray();
        }

        // display items
        public void DisplayArray()
        {
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
