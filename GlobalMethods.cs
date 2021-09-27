using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace BankingApp_Assignment_1
{
    //GlobalMethods 1-> Global M 2-> Static Methods
    public class GlobalFunctions
    {
        //FILE Methods
        public bool CreateFile(string fileName, string content)
        {
            string path = GetFilePath() + fileName + ".txt";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(content);
                }
            }
            return true;
        }

        //get the file path
        public string GetFilePath()
        {
            //System.IO.Directory.GetCurrentDirectory();
            return "Files\\";
        }

        //generate account number
        public string GenerateAccountNumber()
        {
            //random function to generate unique random number
            Random random = new Random();
            int randomNumber = random.Next(10000000, 99999999);
            return randomNumber.ToString();
        }

        //check if account exists
        public bool CheckAccountExists(string accNo)
        {
            string filePath = GetFilePath() + accNo + ".txt"; ;
            if (File.Exists(filePath))
                return true;
            return false;
        }

        //get the currrent balance
        public decimal GetBalance(string accNo)
        {
            string filePath = GetFilePath() + accNo + ".txt";
            var balance = 0m;
            if (File.Exists(filePath))
            {
                // Read a text file line by line.  
                string[] lines = File.ReadAllLines(filePath);


                for (int i = 0; i < lines.Length; i++)
                {
                    var content = lines[i].Split("|");
                    if (content[0] == "Balance")
                    {
                        balance = decimal.Parse(content[1]);
                        break;
                    }
                }
                return balance;
            }
            return balance;
        }

        //get account details
        public string AccountDetails(string accNo)
        {
            string filePath = GetFilePath() + accNo + ".txt"; ;
            if (File.Exists(filePath))
            {
                //read all lines from the file
                string[] lines = File.ReadAllLines(filePath);
                string content = "";
                for (int i = 0; i < lines.Length; i++)
                {
                    if(!String.IsNullOrEmpty(lines[i]))
                    {
                        content += lines[i].Split("|")[1] + "|";
                    }
                }
                return content;
            }
            return "";
        }

        //get last five transaction statements
        public string GetLastFiveTransactions(string accNo)
        {
            string content = "";
            string filePath = GetFilePath() + accNo + ".txt"; ;
            if (File.Exists(filePath))
            {
                //read the all the lines of the file
                string[] lines = File.ReadAllLines(filePath);
                int count = 1;
                for (int i = lines.Length - 1 ; i> 0; i--)
                {
                    if (count < 5 && !String.IsNullOrEmpty(lines[i]))
                    {
                        var temp = lines[i].Split("|");
                        if (temp[1] == "Deposit") 
                        {
                            //construct content for mail
                            var checkCount = lines[i].Split("|");
                            count += checkCount.Length - 3;
                            var tempString = lines[i].ToString();
                            int index = tempString.IndexOf("|");
                            tempString = tempString.Remove(index, 1).Insert(index, " - ");
                            content += "Deposited - " + tempString + Environment.NewLine;
                           
                        } 
                        else if(temp[1] == "Withdraw") 
                        {
                            //construct content for mail
                            var checkCount = lines[i].Split("|");
                            count += checkCount.Length - 3;
                            var tempString = lines[i].ToString();
                            int index = tempString.IndexOf("|");
                            tempString = tempString.Remove(index, 1).Insert(index, " - ");
                            content += "Withdrawl - "+ tempString+Environment.NewLine;
                           
                        }
                    }
                }
                content=content.Replace("|", ",");
                content=content.Replace("Withdraw,", "");
                content=content.Replace("Deposit,", "");
                return content;
            }
            return "";
        }

        //deposit to account
        public bool DepositToAccount(string accNo, decimal amount)
        {
            string filePath = GetFilePath() + accNo + ".txt"; ;
            if (File.Exists(filePath))
            {
                var content = "";
                //read all lines of the file
                string[] lines = File.ReadAllLines(filePath);

                bool flag = false;
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i] != "")
                    {
                        var temp = lines[i].Split("|");
                        if (temp[1] == "Deposit")
                        {
                            //check if its of current date
                            if (temp[0] == DateTime.Now.ToString("yy/MM/dd"))
                            {
                                flag = true;
                                lines[i] = lines[i] + "|" + amount;
                            }
                        }
                        else if (temp[0] == "Balance")
                        {
                            var newBalance = decimal.Parse(temp[1]) + amount;
                            lines[i] = "Balance|" + newBalance;
                        }
                        // get the deposit line

                        content += lines[i] + Environment.NewLine;
                    }

                }

                //new line must be added
                if (!flag)
                {
                    //tempArray[0] = System.DateTime.Now.Date + "|Deposit|" + amount;
                    content += System.DateTime.Now.ToString("yy/MM/dd") + "|Deposit|" + amount;
                }
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    sw.WriteLine(content);
                }
                return true;
            }
            return false;
        }

        //withdraw from account
        public bool WithdrawAmount(string accNo, decimal amount)
        {
            string filePath = GetFilePath() + accNo + ".txt"; ;
            if (File.Exists(filePath))
            {
                var content = "";
                //read all lines of the file
                string[] lines = File.ReadAllLines(filePath);

                bool flag = false;
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i] != "")
                    {
                        var temp = lines[i].Split("|");
                        if (temp[1] == "Withdraw")
                        {
                            //check if its of current date
                            if (temp[0] == DateTime.Now.ToString("yy/MM/dd"))
                            {
                                flag = true;
                                lines[i] = lines[i] + "|" + amount;
                            }
                        }
                        else if (temp[0] == "Balance")
                        {
                            var newBalance = decimal.Parse(temp[1]) - amount;
                            lines[i] = "Balance|" + newBalance;
                        }
                        // get the deposit line

                        content += lines[i] + Environment.NewLine;
                    }
                }

                //new line must be added
                if (!flag)
                {
                    //tempArray[0] = System.DateTime.Now.Date + "|Deposit|" + amount;
                    content += System.DateTime.Now.ToString("yy/MM/dd") + "|Withdraw|" + amount;
                }
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    sw.WriteLine(content);
                }
                return true;
            }
            return false;
        }


        //delete an account
        public bool DeleteAccount(string accNo)
        {
            try
            {
                //get the file and delete it 
                string filePath = GetFilePath() + accNo + ".txt";
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    return true;
                }
                return false;

            }
            //exception handling
            catch (Exception e)
            {
                Console.WriteLine("Unable to delete account, try again !!!");
                Console.ReadLine();
                return false;
            }

        }

        //send email 
        public void SendEmail(string emailId, string content)
        {
            try
            {
                //construct  mail  properties
                MailAddress to = new MailAddress(emailId);
                MailAddress from = new MailAddress("dotnet.32998@gmail.com");
                MailMessage mail = new MailMessage(from, to);
                mail.Subject = "Welcome to Banking Application..";
                var textArray = content.Split("|");
                
                mail.Body = content;
                //using for disposable property
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    Console.WriteLine("Sending Email....");
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("dotnet.32998@gmail.com", "dotnetapp32998");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                    Console.WriteLine("Email Sent...");                    
                }
            }
            //exception handling
            catch (Exception e)
            {

                Console.WriteLine("Failed to send email !!!");
                Console.ReadLine();
            }


        }

    }

    //static methods
    public static class GlobalMethods
    {
        //set cursor position
        public static void SetCursorPosition(int top)
        {
            Console.SetCursorPosition(Console.CursorLeft + 22, Console.CursorTop - top);
        }
        //set cursor position overloading
        public static void SetCursorPosition(int top, int left)
        {
            Console.SetCursorPosition(Console.CursorLeft + left, Console.CursorTop - top);
        }
        //Console.Clear()
        public static void Clear()
        {
            Console.Clear();
        }

        //clear text at a ceratin location
        public static void ClearText(int top, int left)
        {
            int currentLineCursor = top;
            GlobalMethods.SetCursorPosition(1, left);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(left, currentLineCursor);
        }
    }

}
