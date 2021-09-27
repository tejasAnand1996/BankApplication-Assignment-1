using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BankingApp_Assignment_1
{
    public class Login
    {
        public void LoginPage() 
        {
            //alt 218, alt 196, alt 191 for the character ┌,┐
            Console.WriteLine("┌────────────────────────────────────────────────┐");
            Console.WriteLine("|          WELCOME TO BANKING SYSTEM             |");
            Console.WriteLine("|────────────────────────────────────────────────|");
            Console.WriteLine("|          Enter Login Credentials               |");
            Console.WriteLine("|                                                |");
            Console.WriteLine("|          UserName :                            |");
            Console.WriteLine("|          Password :                            |");
            Console.WriteLine("|                                                |");
            Console.WriteLine("|                                                |");
            Console.WriteLine(" ────────────────────────────────────────────────");


            GlobalMethods.SetCursorPosition(5);
            var userName = Console.ReadLine();
            GlobalMethods.SetCursorPosition(0);
            var password = ReadPassword();
            //successsful login
            if (VerifyLogin(userName, password))
            {
                var mainMenu = new MainMenu();
                mainMenu.MainPage();                
            }
            //unsuccessful login
            else 
            {
                Console.Clear();
                Console.WriteLine("┌────────────────────────────────────────────────┐");
                Console.WriteLine("|      INVALID CREDENTIALS!  TRY AGAIN.          |");
                Console.WriteLine("|────────────────────────────────────────────────|"); 
                LoginPage();
            }
        }

        //read password and display "*"
        private static string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key != ConsoleKey.Backspace)
                {
                    Console.Write("*");
                    password += info.KeyChar;
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(password))
                    {
                        // remove one character from the list of password characters
                        password = password.Substring(0, password.Length - 1);
                        // get the location of the cursor
                        int pos = Console.CursorLeft;
                        // move the cursor to the left by one character
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                        // replace it with space
                        Console.Write(" ");
                        // move the cursor to the left by one character again
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                    }
                }
                info = Console.ReadKey(true);
            }

            // add a new line because user pressed enter at the end of their password
            Console.WriteLine();
            return password;
        }
        private bool VerifyLogin(string userName, string password) 
        {
            //read file
            try
            {
                var obj = new GlobalFunctions();
                string text;
                var filePath = obj.GetFilePath()+"login.txt";
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(filePath);
                //Read the first line of text
                text = sr.ReadLine();
                //check until to reach eof
                while (text != null)
                {
                    //compare userName and password
                    var temp = text.Split("|");
                    if (temp[0] == userName && temp[1] == password) 
                    {
                        return true;
                    }

                    //Read the next line
                    text = sr.ReadLine();
                }
                //close the file
                sr.Close();
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                Console.ReadLine();
                return false;

            }
        }
    }
   
}
