using System;
using System.Collections.Generic;

namespace Lab02_Unit_Testing
{
    public class Program
    {
        // These act as my global variables; I tried coming up with ways to do what I needed without usinng them but I couldn't think of how.
        public static double Balance = 5000;
        // This requires System.Collections.Generic and allows for me to record each transaction.
        public static Queue<string> History = new Queue<string>();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my bank!");
            Console.WriteLine(@"
                                    /\   /\
                                   /  \_/  \
                                  (  o . o  ) .
                                    ( v v )__/
                                                        ");
            // This while loop makes sure that the user keeps getting asked for more transactions
            bool moreTransactions = true;
            while (moreTransactions)
            {
                moreTransactions = Menu();
            }
            // This method prints out a receipt of all the transactions that were done once the user decides to exit.
            Transactions();
        }

        static bool Menu()
        {
            // This method holds all the questions
            Questions();
            int userResponse;
            string response = Console.ReadLine();
            // This is an easter egg
            if (response == "cat")
            {
                CatStop();
                return true;
            }
            // This try/catch is a TryParse but written in a different format.
            try
            {
                userResponse = Int32.Parse(response);
            }
            catch (Exception)
            {
                userResponse = -1;
            }
            // This switch statement gives the choices between Withdraw, Deposit, Check Balance, and Exit. The default is for when someone types something random and it forces them to go through the menu again.
            switch (userResponse)
            {
                case 1:
                    // I stored the majority of the Console.WriteLine()s into separate methods.
                    WithdrawText();
                    break;
                case 2:
                    DepositText();
                    break;
                case 3:
                    CheckBalance();
                    break;
                case 4:
                    return false;
                default:
                    Console.WriteLine("I'm sorry, I didn't understand what you wrote.");
                    return true;
            }
            // This hold a mehtod that will return a boolean and ask whether the user wants another transaction.
            return Another();
        }

        static void Questions ()
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1.) Withdraw");
            Console.WriteLine("2.) Deposit");
            Console.WriteLine("3.) Check Balance");
            Console.WriteLine("4.) Exit");
        }

        static bool Another ()
        {
            Console.WriteLine("Do you want to do another transaction? \n y/n");
            // There is the Trim() and ToLower() to account for the cases where someone adds extra spaces or if they use capitalization.
            string anotherTransaction = Console.ReadLine().Trim().ToLower();
            // This checks to see if they returned anything but y in which case they would then exit; otherwise they will loop again.
            if (anotherTransaction != "y")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // This Withdraw method takes in a double that acts as the value that will be withdrawn and returns a boolean on whether the user was able to withdraw or not.
        public static bool Withdraw(double value)
        {
            // This if statement checks to see if the user gives a valid amount where it then takes that amount out
            if ((value > 0) && (Balance >= value))
            {
                Balance -= value;
                return true;
            }
            return false;
        }

        // This method holds all the other aspects of withdrawing money.
        static void WithdrawText ()
        {
            double number;
            Console.WriteLine("How much money do you want to withdraw?");
            try
            {
                number = Double.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                number = -1;
            }
            // This if/else statment uses the boolean that is returned from the Withdraw method as a means of finding whether the withdraw worked or not.
            if (Withdraw(number))
            {
                Console.WriteLine("Withdrawal Successful");
                // Here we record the transaction that just occurred.
                History.Enqueue($"You withdrew ${number} from your account; you now have ${Balance}.");
            }
            else
                Console.WriteLine("Invalid Withdrawal");
        }

        // This acts the same as Withdraw but the if statement only needs the value to be greater than 0.
        public static bool Deposit(double value)
        {
            if (value > 0)
            {
                Balance += value;
                return true;
            }
            return false;
        }

        static void DepositText ()
        {
            double number;
            Console.WriteLine("How much money do you want to deposit?");
            try
            {
                number = Double.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                number = -1;
            }
            if (Deposit(number))
            {
                Console.WriteLine("Deposit Successful");
                History.Enqueue($"You deposited ${number} into your account; you now have ${Balance}.");
            }
            else
                Console.WriteLine("Invalid Deposit");
        }

        // I didn't really need to make this method but by the time I noticed I had already made it.
        static void CheckBalance ()
        {
            Console.WriteLine($"Your current balance is ${Balance}");
        }

        static void Transactions ()
        {
            Console.WriteLine("Here is a receipt of your transactions:");
            // This is how I have each transaction printed out
            foreach(string transaction in History)
            {
                Console.WriteLine(transaction);
            }
            Console.WriteLine($"Your current balance is: ${Balance}");
        }

        // The easter egg
        static void CatStop()
        {
            Console.WriteLine("Welcome the the cat stop!");
            Console.WriteLine("Have a fish!");
            Console.WriteLine(@"
                                        _J""-.
                                       / o )) \ ,'`;
                                       \   ))  ;   |
                                        `v-.-'' \._;
                                                            ");
            Console.WriteLine("Thanks for visiting!");
            History.Enqueue("Meow");
        }
    }
}
