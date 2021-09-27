using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BankingApp_Assignment_1
{
    class MainMenu
    {
        private readonly Validations valObj;
        private readonly GlobalFunctions obj;

        public MainMenu()
        {
            valObj = new Validations();
            obj = new GlobalFunctions();
        }
        public void MainPage()
        {
            
            Console.Clear();
            var response = MenuOptions();
            //display menu until exit (7) is selected
            while (response != 7)
            {
                Console.Clear();
                response = MenuOptions();
            }

        }

        int MenuOptions()
        {

            Console.WriteLine("┌────────────────────────────────────────────────┐");
            Console.WriteLine("|                BANKING SYSTEM                  |");
            Console.WriteLine("|────────────────────────────────────────────────|");
            Console.WriteLine("|           1. Create New Account                |");
            Console.WriteLine("|           2. Search for an Account             |");
            Console.WriteLine("|           3. Deposit                           |");
            Console.WriteLine("|           4. Withdraw                          |");
            Console.WriteLine("|           5. A/C Statement                     |");
            Console.WriteLine("|           6. Delete Account                    |");
            Console.WriteLine("|           7. Exit                              |");
            Console.WriteLine("|────────────────────────────────────────────────|");
            Console.WriteLine("|Enter your choice :                             |");
            Console.WriteLine("|────────────────────────────────────────────────|");
            GlobalMethods.SetCursorPosition(2);
            var option = Console.ReadLine();

            //validate the input
            bool flag = false;
            while (!flag)
            {
                if (!valObj.IntegerValidation(option))
                {
                    GlobalMethods.SetCursorPosition(1, 51);
                    Console.WriteLine("(Invalid choice ! Enter Again)");
                    GlobalMethods.SetCursorPosition(1, 22);
                    option = Console.ReadLine();
                    flag = false;
                }
                else
                {
                    flag = true;
                }
            }
            SelectOption(option);
            return int.Parse(option);
        }

        void SelectOption(string option)
        {
            try
            {
                GlobalMethods.Clear();
                //parse the input to integer
                var temp = Int32.Parse(option);
                //check if input is within bounds
                if (temp > 0 && temp < 8)
                {
                    switch (temp)
                    {
                        case 1:
                            //Create account is selected
                            CreateAccount();
                            break;
                        case 2:
                            //search account is selected
                            SearchAccount();
                            break;
                        case 3:
                            //deposit to account is selected
                            DepositAmount();
                            break;
                        case 4:
                            //withdraw from account is selected
                            WithDrawAmount();
                            break;
                        case 5:
                            //view account statement is selected
                            AcccountStatement();
                            break;
                        case 6:
                            //delete account is selected
                            DeleteAccount();
                            break;
                        case 7:
                            //exit the system is selected
                            Exit();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    //invalid option
                }


            }
            //an exception occured
            catch (Exception e)
            {               
                Console.WriteLine("Exception occured in the system. Please contact the vendor!!!");
                Console.ReadLine();
            }
        }

        void CreateAccount()
        {
            Console.WriteLine("┌────────────────────────────────────────────────┐");
            Console.WriteLine("|                BANKING SYSTEM                  |");
            Console.WriteLine("|────────────────────────────────────────────────|");
            Console.WriteLine("|              Create New Account                |");
            Console.WriteLine("|                                                |");
            Console.WriteLine("|     First Name :                               |");
            Console.WriteLine("|     Last Name  :                               |");
            Console.WriteLine("|     Address    :                               |");
            Console.WriteLine("|     Phone No.  :                               |");
            Console.WriteLine("|     Email      :                               |");
            Console.WriteLine("|────────────────────────────────────────────────|");
            GlobalMethods.SetCursorPosition(6);

            var firstName = Console.ReadLine();
            bool flag = false;
            //validate the First Name
            while (!flag)
            {
                //validate required 
                if (!valObj.RequiredValidation(firstName))
                {
                    GlobalMethods.SetCursorPosition(1, 51);
                    Console.WriteLine("(First Name is not valid! Enter Again)");
                    GlobalMethods.SetCursorPosition(1, 22);
                    firstName = Console.ReadLine();
                    flag = false;
                }
                else
                {
                    flag = true;
                }
            }
            flag = false;
            GlobalMethods.SetCursorPosition(0);

            var lastName = Console.ReadLine();
            //validate the Last Name
            while (!flag)
            {
                //validate required 
                if (!valObj.RequiredValidation(lastName))
                {
                    GlobalMethods.SetCursorPosition(1, 51);
                    Console.WriteLine("(Last Name is not valid! Enter Again)");
                    GlobalMethods.SetCursorPosition(1, 22);
                    lastName = Console.ReadLine();
                    flag = false;
                }
                else
                {
                    flag = true;
                }
            }
            flag = false;
            GlobalMethods.SetCursorPosition(0);

            var address = Console.ReadLine();
            //validate the Address
            while (!flag)
            {
                //validate required 
                if (!valObj.RequiredValidation(address))
                {
                    GlobalMethods.SetCursorPosition(1, 51);
                    Console.WriteLine("(Address is not valid! Enter Again)");
                    GlobalMethods.SetCursorPosition(1, 22);
                    address = Console.ReadLine();
                    flag = false;
                }
                else
                {
                    flag = true;
                }
            }
            flag = false;

            GlobalMethods.SetCursorPosition(0);
            var phone = Console.ReadLine();
            //validate Phone Number
            while (!flag)
            {
                //validate required  and whether the input is an integer
                if (!valObj.RequiredValidation(phone) || !valObj.IntegerValidation(phone))
                {
                    GlobalMethods.SetCursorPosition(1, 51);
                    Console.WriteLine("(Phone Number is not valid! Enter Again)");
                    GlobalMethods.SetCursorPosition(1, 22);
                    phone = Console.ReadLine();
                    flag = false;
                }
                else
                {
                    flag = true;
                }
            }
            flag = false;
            GlobalMethods.SetCursorPosition(0);

            var email = Console.ReadLine();
            //validate Email and required
            while (!flag)
            {
                if (!valObj.EmailValidation(email) || !valObj.RequiredValidation(email))
                {
                    GlobalMethods.SetCursorPosition(1, 51);
                    Console.WriteLine("(Email is not valid! Enter Again)");
                    GlobalMethods.SetCursorPosition(1, 22);
                    email = Console.ReadLine();
                    flag = false;
                }
                else
                {
                    flag = true;
                }
            }

            Console.WriteLine("|────────────────────────────────────────────────|");
            Console.WriteLine("|  Confirm Details (Y/N) :                       |");
            Console.SetCursorPosition(Console.CursorLeft + 28, Console.CursorTop - 1);

            var ans = Console.ReadLine();
            if (ans == "y" || ans == "Y")
            {

                var acc =  obj.GenerateAccountNumber();
                Console.WriteLine("|                                                |");
                Console.WriteLine("|                                                |");
                Console.WriteLine("|     New Account Number :    {0}        |", acc);
                Console.WriteLine("|                                                |");
                Console.WriteLine("|────────────────────────────────────────────────|");
                Console.WriteLine("|     Press any key to return to main menu...    |");

                //using "|" as the split character
                var content = "First Name|" + firstName + Environment.NewLine +
                              "Last Name|" + lastName + Environment.NewLine +
                              "Address|" + address + Environment.NewLine +
                              "Phone|" + phone + Environment.NewLine +
                              "Email|" + email + Environment.NewLine +
                              "Account No.|" + acc + Environment.NewLine +
                              "Balance|0";
                obj.CreateFile(acc, content);
                content = content.Replace("|", " : ");
                obj.SendEmail(email, content);

                Console.WriteLine("");
                Console.ReadLine();
            }
        }

        void SearchAccount()
        {
            GlobalMethods.Clear();
            Console.WriteLine("┌────────────────────────────────────────────────┐");
            Console.WriteLine("|                BANKING SYSTEM                  |");
            Console.WriteLine("|────────────────────────────────────────────────|");
            Console.WriteLine("|              SEARCH FOR AN ACCOUNT             |");
            Console.WriteLine("|                                                |");
            Console.WriteLine("|        Search :                                |");
            Console.WriteLine("|────────────────────────────────────────────────|");
            GlobalMethods.SetCursorPosition(2);
            var acc = Console.ReadLine();
            bool flag = false;
            while (!flag)
            {
                if (!valObj.RequiredValidation(acc) || !valObj.MaxLength(acc, 10))
                {
                    GlobalMethods.SetCursorPosition(1, 51);
                    Console.WriteLine("(Account Number is not valid! Enter Again)");
                    GlobalMethods.SetCursorPosition(1, 22);
                    acc = Console.ReadLine();
                    flag = false;
                }
                else
                {
                    //GlobalMethods.ClearText(0, 51);
                    flag = true;
                }
            }

            string[] files = Directory.GetFiles(obj.GetFilePath(), "*.txt", SearchOption.AllDirectories);
            bool accountFound = false;
            // Display all the files.
            foreach (string file in files)
            {
                if (file.Contains(acc))
                {
                    var filePath = obj.GetFilePath() + acc + ".txt";
                    if (File.Exists(filePath))
                    {
                        accountFound = true;
                        // Read entire text file content   
                        string content = obj.AccountDetails(acc);  //File.ReadAllText(filePath);
                        var array = content.Split("|");
                        //GlobalMethods.clear();
                        Console.WriteLine("┌────────────────────────────────────────────────┐");
                        Console.WriteLine("|                ACCOUNT FOUND                   |");
                        Console.WriteLine("|────────────────────────────────────────────────|");
                        Console.WriteLine("|                                                |");
                        Console.WriteLine("     Acc No.    :  {0}                           ", acc);
                        Console.WriteLine("     First Name :  {0}                           ", array[0]);
                        Console.WriteLine("     Last Name  :  {0}                           ", array[1]);
                        Console.WriteLine("     Address    :  {0}                           ", array[2]);
                        Console.WriteLine("     Phone No.  :  {0}                           ", array[3]);
                        Console.WriteLine("     Email      :  {0}                           ", array[4]);
                        Console.WriteLine("|────────────────────────────────────────────────|", array[5]);
                        break;
                    }
                }
            }

            if (!accountFound)
            {
                Console.WriteLine("|                                                |");
                Console.WriteLine("|         ACCOUNT NOT FOUND!!                    |");
                Console.WriteLine("|                                                |");
                Console.WriteLine("|────────────────────────────────────────────────|");


            }
            Console.WriteLine("|     Search Again (Y/N) ?  :                    |");
            GlobalMethods.SetCursorPosition(1, 30);
            var res = Console.ReadLine();
            if (res == "y" || res == "Y")
            {
                SearchAccount();
            }

        }

        void DepositAmount()
        {
            GlobalMethods.Clear();
            Console.WriteLine("┌────────────────────────────────────────────────┐");
            Console.WriteLine("|                MAKE A DEPOSIT                  |");
            Console.WriteLine("|────────────────────────────────────────────────|");
            Console.WriteLine("|────────────────────────────────────────────────|");
            Console.WriteLine("|         Enter Account Number to Withdraw       |");
            Console.WriteLine("|                                                |");
            Console.WriteLine("|              Acc No.  :                        |");
            Console.WriteLine("|────────────────────────────────────────────────|");
            GlobalMethods.SetCursorPosition(2, 27);
            var accNo = Console.ReadLine();
            bool flag = false;
            while (!flag)
            {
                if (!valObj.RequiredValidation(accNo) || !valObj.MaxLength(accNo, 10))
                {
                    GlobalMethods.SetCursorPosition(1, 51);
                    Console.WriteLine("(Account Number is not valid! Enter Again)");
                    GlobalMethods.SetCursorPosition(1, 27);
                    accNo = Console.ReadLine();
                    flag = false;
                }
                else
                {
                    //GlobalMethods.ClearText(0, 51);
                    flag = true;
                }
            }
            decimal balance = 0;
            if (obj.CheckAccountExists(accNo))
            {
                balance = obj.GetBalance(accNo);
                Console.WriteLine("|                                                |");
                Console.WriteLine("|       Current Balance : $                      |");
                Console.WriteLine("|                                                |");
                Console.WriteLine("|  Enter Deposit Amount : $                      |");
                Console.WriteLine("|                                                |");
                Console.WriteLine("|────────────────────────────────────────────────|");
                GlobalMethods.SetCursorPosition(5, 27);
                Console.WriteLine(balance);
                GlobalMethods.SetCursorPosition(-1, 27);
                var depositAmount = Console.ReadLine();
                flag = false;
                while (!flag)
                {
                    if (!valObj.RequiredValidation(depositAmount) || !valObj.DecimalValidation(depositAmount))
                    {
                        GlobalMethods.SetCursorPosition(1, 51);
                        Console.WriteLine("(Invalid Amount! Enter Again)");
                        GlobalMethods.SetCursorPosition(1, 27);
                        depositAmount = Console.ReadLine();
                        flag = false;
                    }
                    else
                    {
                        flag = true;
                    }
                }

                //exception handling
                bool res = obj.DepositToAccount(accNo, decimal.Parse(depositAmount));
                //account not found
                if (res == false)
                {
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
                    Console.WriteLine("|                                                |");
                    Console.WriteLine("|              DEPOSIT UNSUCCESSFUL    !!        |");
                }
                else
                {
                    Console.WriteLine("|                                                |");
                    Console.WriteLine("|              DEPOSIT SUCCESSFUL    !!          |");
                    Console.WriteLine("|                                                |");
                    Console.WriteLine("|       Current Balance :                        |");
                    GlobalMethods.SetCursorPosition(1, 27);
                    balance = obj.GetBalance(accNo);
                    Console.WriteLine(balance);
                }
                Console.WriteLine("|────────────────────────────────────────────────|");
                Console.WriteLine("          Press any key to continue...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("|                                                |");
                Console.WriteLine("|         ACCOUNT NOT FOUND!!                    |");
                Console.WriteLine("|                                                |");
                Console.WriteLine("|────────────────────────────────────────────────|");
                Console.WriteLine("|     Search Again (Y/N) ?  :                    |");
                GlobalMethods.SetCursorPosition(1, 30);
                var res = Console.ReadLine();
                if (res == "y" || res == "Y")
                {
                    DepositAmount();
                }

            }
        }

        void WithDrawAmount()
        {
            GlobalMethods.Clear();
            Console.WriteLine("┌────────────────────────────────────────────────┐");
            Console.WriteLine("|                WITHDRAWAL                      |");
            Console.WriteLine("|────────────────────────────────────────────────|");
            Console.WriteLine("|         Enter Account Number to Withdraw       |");
            Console.WriteLine("|                                                |");
            Console.WriteLine("|              Acc No.  :                        |");
            Console.WriteLine("|────────────────────────────────────────────────|");

            GlobalMethods.SetCursorPosition(2, 27);
            var accNo = Console.ReadLine();
            decimal balance = 0;
            if (obj.CheckAccountExists(accNo))
            {
                balance = obj.GetBalance(accNo);
                Console.WriteLine("|                                                |");
                Console.WriteLine("|       Current Balance :                        |");
                Console.WriteLine("|                                                |");
                Console.WriteLine("| Enter Withdraw Amount :                        |");
                Console.WriteLine("|                                                |");
                Console.WriteLine("|────────────────────────────────────────────────|");
                GlobalMethods.SetCursorPosition(5, 27);
                Console.WriteLine(balance);
                GlobalMethods.SetCursorPosition(-1, 27);
                var withdrawAmount = Console.ReadLine();
                bool flag = false;
                while (!flag)
                {
                    if (!valObj.RequiredValidation(withdrawAmount) || !valObj.DecimalValidation(withdrawAmount))
                    {
                        GlobalMethods.SetCursorPosition(1, 51);
                        Console.WriteLine("(Invalid Amount! Enter Again)");
                        GlobalMethods.SetCursorPosition(1, 27);
                        withdrawAmount = Console.ReadLine();
                        flag = false;
                    }
                    else
                    {
                        flag = true;
                    }
                }

                // in-sufficient funds
                if (decimal.Parse(withdrawAmount) > balance)
                {
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
                    Console.WriteLine("|                                                |");
                    Console.WriteLine("|       INSUFFICIENT FUNDS TO WITHDRAW !!        |");
                    Console.WriteLine("|────────────────────────────────────────────────|");
                    Console.WriteLine("          Press any key to continue...");
                    Console.ReadLine();
                    return;
                }

                bool res = obj.WithdrawAmount(accNo, decimal.Parse(withdrawAmount));
                //Unsuccessful
                if (!res)
                {
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
                    Console.WriteLine("|                                                |");
                    Console.WriteLine("|            WITHDRAWL UNSUCCESSFUL    !!        |");
                }
                else
                {
                    Console.WriteLine("|                                                |");
                    Console.WriteLine("|             WITHDRAWL SUCCESSFUL    !!         |");
                    Console.WriteLine("|                                                |");
                    Console.WriteLine("|       Current Balance :                        |");
                    GlobalMethods.SetCursorPosition(1, 27);
                    balance = obj.GetBalance(accNo);
                    Console.WriteLine(balance);
                }
                Console.WriteLine("|────────────────────────────────────────────────|");
                Console.WriteLine("          Press any key to continue...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("|                                                |");
                Console.WriteLine("|         ACCOUNT NOT FOUND!!                    |");
                Console.WriteLine("|                                                |");
                Console.WriteLine("|────────────────────────────────────────────────|");
                Console.WriteLine("|     Search Again (Y/N) ?  :                    |");
                GlobalMethods.SetCursorPosition(1, 30);

                var res = Console.ReadLine();
                if (res == "y" || res == "Y")
                {
                    WithDrawAmount();
                }

            }


        }

        void AcccountStatement()
        {
            Console.WriteLine("┌────────────────────────────────────────────────┐");
            Console.WriteLine("|              ACCOUNT STATEMENT                 |");
            Console.WriteLine("|────────────────────────────────────────────────|");
            Console.WriteLine("|         Enter the Account Number               |");
            Console.WriteLine("|                                                |");
            Console.WriteLine("|              Acc No.  :                        |");
            Console.WriteLine("|────────────────────────────────────────────────|");

            GlobalMethods.SetCursorPosition(2, 27);
            var accNo = Console.ReadLine();
            bool flag = false;
            while (!flag)
            {
                if (!valObj.RequiredValidation(accNo) || !valObj.MaxLength(accNo, 10))
                {
                    GlobalMethods.SetCursorPosition(1, 51);
                    Console.WriteLine("(Account Number is not valid! Enter Again)");
                    GlobalMethods.SetCursorPosition(1, 22);
                    accNo = Console.ReadLine();
                    flag = false;
                }
                else
                {
                    //GlobalMethods.ClearText(0, 51);
                    flag = true;
                }
            }
            if (obj.CheckAccountExists(accNo))
            {
                decimal balance = obj.GetBalance(accNo);
                var details = obj.AccountDetails(accNo).Split("|");
                Console.WriteLine("");
                Console.WriteLine("┌────────────────────────────────────────────────┐");
                Console.WriteLine("|                BANKING SYSTEM                  |");
                Console.WriteLine("|────────────────────────────────────────────────|");
                Console.WriteLine("|              Account Statement                 |");
                Console.WriteLine("|                                                |");
                Console.WriteLine("|     Account No. :                              |");
                Console.WriteLine("|     Balance     : $                            |");
                Console.WriteLine("|     First Name  :                              |");
                Console.WriteLine("|     Last Name   :                              |");
                Console.WriteLine("|     Address     :                              |");
                Console.WriteLine("|     Phone No.   :                              |");
                Console.WriteLine("|     Email       :                              |");
                Console.WriteLine("|────────────────────────────────────────────────|");
                GlobalMethods.SetCursorPosition(8, 22);
                Console.WriteLine(accNo);
                GlobalMethods.SetCursorPosition(0, 22);
                Console.WriteLine(balance);
                GlobalMethods.SetCursorPosition(0, 22);
                Console.WriteLine(details[0]);
                GlobalMethods.SetCursorPosition(0, 22);
                Console.WriteLine(details[1]);
                GlobalMethods.SetCursorPosition(0, 22);
                Console.WriteLine(details[2]);
                GlobalMethods.SetCursorPosition(0, 22);
                Console.WriteLine(details[3]);
                GlobalMethods.SetCursorPosition(0, 22);
                Console.WriteLine(details[4]);
                Console.WriteLine("");
                var transactions = obj.GetLastFiveTransactions(accNo);

                //construct the email content
                var emailContent =  "                BANKING SYSTEM                  " + Environment.NewLine +
                                    "────────────────────────────────────────────────" + Environment.NewLine +
                                    "              Account Statement                 " + Environment.NewLine +
                                    "                                                " + Environment.NewLine +
                                    " Account No. : " + accNo + Environment.NewLine +
                                    " Balance     : " + balance + Environment.NewLine +
                                    " First Name  : " + details[0] + Environment.NewLine +
                                    " Last Name   : " + details[1] + Environment.NewLine +
                                    " Address     : " + details[2] + Environment.NewLine +
                                    " Phone No.   : " + details[3] + Environment.NewLine +
                                    " Email       : " + details[4] + Environment.NewLine +
                                    "────────────────────────────────────────────────" +Environment.NewLine+
                                    " Last 5 transactions.."+Environment.NewLine+
                                     transactions + Environment.NewLine;

                //send email
                obj.SendEmail(details[4], emailContent);
                Console.WriteLine("");
                Console.WriteLine("     Enter any key to continue... ");
                Console.ReadLine();

            }
            else
            {
                Console.WriteLine("|                                                |");
                Console.WriteLine("|         ACCOUNT NOT FOUND!!                    |");
                Console.WriteLine("|                                                |");
                Console.WriteLine("|────────────────────────────────────────────────|");
                Console.WriteLine("|     Search Again (Y/N) ?  :                    |");
                GlobalMethods.SetCursorPosition(1, 30);
                var res = Console.ReadLine();
                if (res == "y" || res == "Y")
                {
                    AcccountStatement();
                }

            }

        }

        void DeleteAccount()
        {
            Console.Clear();
            Console.WriteLine("┌────────────────────────────────────────────────┐");
            Console.WriteLine("|              DELETE ACCOUNT                    |");
            Console.WriteLine("|────────────────────────────────────────────────|");
            Console.WriteLine("|    Enter the Account Number to be deleted      |");
            Console.WriteLine("|                                                |");
            Console.WriteLine("|              Acc No.  :                        |");
            Console.WriteLine("|────────────────────────────────────────────────|");
            GlobalMethods.SetCursorPosition(2, 27);
            var accNo = Console.ReadLine();
            if (obj.CheckAccountExists(accNo))
            {
                Console.WriteLine("|                                                |");
                Console.WriteLine("|  Are you sure ?? (Y/N) :                       |");
                Console.WriteLine("|                                                |");
                GlobalMethods.SetCursorPosition(2, 27);
                var res = Console.ReadLine();
                if (res == "y" || res == "Y")
                {
                    bool delete = obj.DeleteAccount(accNo);
                    if (delete)
                    {
                        Console.WriteLine("|                                                |");
                        Console.WriteLine("|         ACCOUNT DELETED SUCCESSFULLY!          |");
                        Console.WriteLine("|────────────────────────────────────────────────|");

                        Console.WriteLine("");
                        Console.WriteLine("     Enter any key to continue... ");
                        Console.ReadLine();

                    }


                }
            }
            else
            {
                Console.WriteLine("|                                                |");
                Console.WriteLine("|              ACCOUNT NOT FOUND!!!              |");
                Console.WriteLine("|────────────────────────────────────────────────|");
                Console.WriteLine("     Enter any key to continue... ");
                Console.ReadLine();

            }
        }

        void Exit()
        {
            Console.WriteLine("┌────────────────────────────────────────────────┐");
            Console.WriteLine("|              EXIT SYSTEM                       |");
            Console.WriteLine("|────────────────────────────────────────────────|");
            Console.WriteLine("|         You have exited the system             |");
            Console.WriteLine("|                                                |");
            Console.WriteLine("|        Press any key to continue...            |");
            Console.WriteLine("|────────────────────────────────────────────────|");
            Console.ReadLine();
        }
    }
}
