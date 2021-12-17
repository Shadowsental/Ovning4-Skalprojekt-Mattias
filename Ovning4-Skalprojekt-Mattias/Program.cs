using System;
using System.Collections;
using System.Linq;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            List<String> theList = new List<string>();
            bool isOn = true;
            while (isOn)
            {
                Console.Write("Add '+' or Remove '-' input. Q for quits.: ");


                string typeThis = Console.ReadLine()!;
                char input = typeThis[0]; string value = typeThis.Substring(1);
                switch (input)
                {
                    case '+':
                        theList.Add(value);
                        Console.WriteLine($"The List Count: {theList.Count}, The List Capacity: {theList.Capacity}");
                        foreach (var guys in theList)
                        {
                            Console.WriteLine($"{guys} \n");
                        }
                        break;

                    case '-':
                        theList.Remove(value);
                        Console.WriteLine($"The List Count: {theList.Count}, The List Capacity: {theList.Capacity}");
                        foreach (var guys in theList)
                        {
                            Console.WriteLine($"{guys} \n");
                        }
                        break;

                    case 'Q':
                        isOn = false;
                        break;

                    default:
                        Console.WriteLine("Only use + or -.");
                        break;

                        //Jag får en capacity på 4. När jag når den capacitin och lägger till ett nytt objekt i listan så ökas capacitin med 4.
                        //När jag tar bort saker från listan så minskar inte capacitin. Den stannar på det numret som den sist inkremerade.
                }
            }
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            //List<string> theList = new List<string>();
            //string input = Console.ReadLine();
            //char nav = input[0];
            //string value = input.substring(1);

            //switch(nav){...}
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            Queue myQ = new Queue()!;
            bool isOn = true;
            while(isOn) {
                Console.Write("+: Add to queue. -: Remove from queue. Q to quit.");

                string input = Console.ReadLine()!;
                switch(input)
                {
                    case "+":
                        Console.Write("Type something to add to your queue: ");
                        string enqueue = Console.ReadLine()!;
                        myQ.Enqueue(enqueue);
                        foreach (var people in myQ)
                        {
                            Console.WriteLine($"{people} is in queue.");
                        }
                        break;

                    case "-":
                        Console.WriteLine($"{myQ.Peek()} has left the queue.");
                        myQ.Dequeue();
                        foreach (var people in myQ)
                        {
                            Console.WriteLine($"{people} is in queue.");
                        }
                        break;

                    case "Q":
                        isOn = false;
                        break;

                    default:
                        Console.WriteLine("No.");
                        break;
                }
            }
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            Stack myStack = new Stack()!;
            bool isOn = true;
            while (isOn)
            {
                Console.Write("+ to push items to the stack. - to pop items away from the stack. R to reverse a string. Q to quit.");

                string input = Console.ReadLine()!;
                switch(input)
                {
                    case "+":
                        Console.Write("Add an item: ");
                        string item = Console.ReadLine()!;
                        myStack.Push(item);
                        Console.WriteLine($"Added {item} to the stack.");
                        break;

                    case "-":
                        Console.WriteLine($"Popped {myStack.Peek()}");
                        myStack.Pop();
                        break;

                    case "R":
                        Console.Write("Type in a string to reverse: ");
                        string reverseThis = Console.ReadLine()!;
                        var reversed = new string(reverseThis.ToCharArray().Reverse().ToArray());
                        Console.WriteLine(reversed);
                        break;

                    case "Q":
                        isOn = false;
                        break;

                    default:
                        Console.WriteLine("No.");
                        break;
                }

            }
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
        }

        static void CheckParanthesis()
        {
            //JAg valde att använde en stack för att göra denna uppgift, då jag tyckte att det var enklare att hantera.

            Console.Write("Type in a new list. Example: List<int>() { 1, 2, 3 ,4 }: ");
            string check = Console.ReadLine()!;

            Stack<char> checking = new Stack<char>()!;

            foreach (var c in check!)
            {
                switch (c)
                {
                    case ')':
                        if (checking.Count == 0 || checking.Pop() != '(')
                        {
                            Console.WriteLine("Paranthesis error. Use these to close the thing '( )'.");
                        }
                        break;

                    case ']':
                        if(checking.Count == 0 || checking.Pop() != '[')
                        {
                            Console.WriteLine("Paranthesis error. Use these to close the thing '[ ]'.");
                        }
                        break;

                    case '}':
                        if(checking.Count == 0 || checking.Pop() != '{')
                        {
                            Console.WriteLine("Paranthesis error. Use these to close the thing '{ }'.");
                        }
                        break;
                    case '>':
                        if(checking.Count == 0 || checking.Pop() != '<')
                        {
                            Console.WriteLine("Paranthesis error. Use these to close the thing '< >'.");
                        }
                        break;


                    case '(': 
                        checking.Push(c);
                        break;

                    case '[':
                        checking.Push(c);
                        break;

                    case '{':
                        checking.Push(c);
                        break;
                    case '<':
                        checking.Push(c);
                        break;
                }
            }

            if (checking.Count == 0)
            {
                Console.WriteLine(check);
            }


            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }

    }
}

