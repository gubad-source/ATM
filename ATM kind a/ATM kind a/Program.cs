using System;
using System.Collections.Generic;
using System.Linq;


namespace ATM_kind_a
{
   
    class Program
    {
       
        static void Main(string[] args)
        {
           void printOptions()
            {
                Console.WriteLine("Please choose one of the following options...");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Show Balance");
                Console.WriteLine("4. Exit");
            }
            void deposit(cardHolder currentUser)
            {
                Console.WriteLine("How much $$ would you like to deposit");
                double deposit = Double.Parse(Console.ReadLine());
                currentUser.setBalance(currentUser.getBalance()+deposit);
                Console.WriteLine("Thank you for your money.Your new balance is: "+currentUser.getBalance());
            }
            void withdraw(cardHolder currentUser)
            {
                Console.WriteLine("How much $$ would you like to withdraw: ");
                double withdrawal = Double.Parse(Console.ReadLine());

                if (currentUser.getBalance() < withdrawal) //
                {
                    Console.WriteLine("Insufficient balance :(");
                }
                else
                {
                    currentUser.setBalance(currentUser.getBalance() - withdrawal);
                    Console.WriteLine("You're good to go.Thank you :)");
                }
            }
            void balance(cardHolder currentUser)
            {
                Console.WriteLine("Current balance: "+currentUser.getBalance());
            }

            List<cardHolder> cardHolders = new List<cardHolder>();
            cardHolders.Add(new cardHolder("2555474858566", 1234, "Dash", "William", 66.7));
            cardHolders.Add(new cardHolder("2566474858563", 6634, "Josh", "Birkin", 22.7));

            Console.WriteLine("Welcome to ATM");
            Console.WriteLine("Please insert your debit card: ");
            string debitCardNum = "";
            cardHolder currentUser;

            while (true)
            {
                try
                {
                    debitCardNum = Console.ReadLine();
                    currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                    if(currentUser != null) { break; }
                    else { Console.WriteLine("Card not recognized.Please try again"); }
                }
                catch
                {
                    Console.WriteLine("Card not recognized.Please try again");
                }
            }

            Console.WriteLine("Please enter your pin: ");
            int userPin = 0;
            while (true)
            {
                try
                {
                    userPin =int.Parse(Console.ReadLine());

                    if (currentUser.getPin() == userPin) { break; }
                    else { Console.WriteLine("Incorrect Pin.Please try again"); }
                }
                catch
                {
                    Console.WriteLine("Incorrect Pin.Please try again");
                }
            }
            Console.WriteLine("Welcome "+currentUser.getFirstName());
            int option = 0;
            do
            {
                printOptions();
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch
                {

                }
                if (option == 1) { deposit(currentUser); }
                else if (option == 2) { withdraw(currentUser);}
                else if (option == 3) { balance(currentUser); }
                else if (option == 4) { break; }
                else { option = 0; }
            } while (option != 0);
            Console.WriteLine("Thank you have a nice day");
        }
    }
}
