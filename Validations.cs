using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BankingApp_Assignment_1
{
    //Validation methods
    public class Validations
    {
        //check whether the input is an integer
        public bool IntegerValidation(string input) 
        {
            int temp = 0;
            bool validInput = Int32.TryParse(input, out temp);
            return validInput;
        }

        //check whether the input is a decimal
        public bool DecimalValidation(string input)
        {
            decimal temp = 0;
            bool validInput = decimal.TryParse(input, out temp);
            return validInput;
        }

        //check whether the input is not null
        public bool RequiredValidation(string input) 
        {
            if (input.Length <= 0) 
            {
                return false;
            }
            return true;
        }

        //check whether the input has exceeded the max length
        public bool MaxLength(string input, int maxLength) 
        {
            if (input.Length > maxLength)
            {
                return false;
            }
            return true;

        }

        //check whether the email is valid
        public bool EmailValidation(string email) 
        {
            //regular expression to check email validation
            bool isvalid = Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            return isvalid;
        }
    }
}
