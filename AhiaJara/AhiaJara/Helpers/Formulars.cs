using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace AhiaJara.Helpers
{
    public class Formulars
    {
        String input;
       
        public decimal ConvertToDecimal(string totalPrice)
        {
            input = totalPrice;
            Decimal newTotalPrice = 0m;

            if (string.IsNullOrEmpty(input) == false)
            {
                if (input.Contains(",") == false &&input.Contains(".") == false)
                {
                    String price = input + "00";
                    newTotalPrice = decimal.Parse(price);

                }
                // check if input has , and . for thousands separator and decimal place
                if (input.Contains(",") && input.Contains("."))
                {
                    // find the decimal separator, might be , or .
                    int decimalpos = input.LastIndexOf(',') > input.LastIndexOf('.') ? input.LastIndexOf(',') : input.LastIndexOf('.');
                    // uses | as a temporary decimal separator
                    input = input.Substring(0, decimalpos) + "|" + input.Substring(decimalpos + 1);
                    // formats the output removing the , and . and replacing the temporary | with .
                    input = input.Replace(".", "").Replace(",", "").Replace("|", ".");
                }
                // replaces , with .
                if (input.Contains(","))
                {
                    input = input.Replace(',', '.');
                }
                // checks if the input number has thousands separator and no decimal places
                if (input.Count(item => item == '.') > 1)
                {
                    input = input.Replace(".", "");
                }
                // tries to convert input to double
                //if (decimal.TryParse(input, out newTotalPrice) == true)
                //{
                //    //decimal d = decimal.Parse("1200.00");
                //    newTotalPrice = decimal.Parse(input, NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, CultureInfo.InvariantCulture);
                //}
                
            }
            return newTotalPrice;
        }
    }
}
