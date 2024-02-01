using System;
using System.Globalization;

internal class Program
{
    public static void Main(string[] args)
    {
        //// Calling functions to execute Exceptions:

        Input();
        //Factorial();
        //SqRoot();
        //DateTimeFormat();
        //Division();
        //Checknegativeint();

        //// if return type is there:
        
        //string output = Input();
        //Console.WriteLine(output);
    }

    #region 1) NullReferenceException
    public static void Input()
    {
        try
        {
            Console.Write("Enter a string: ");
            string input = Console.ReadLine().ToUpper();
            Console.WriteLine(input);

            if (input == "")
            {
               throw new NullReferenceException("Error");
               //OR
               throw new NullReferenceException();      
               //OR
               //input = null;
            }
            //return input;
        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine(ex.Message);
            //OR
            Console.WriteLine("Error");

            //return string.Empty;
            //return ex.Message;
        }
        finally
        {
            // here, we clear the garbage, etc.
            Console.WriteLine("Finally block executed.");
        }
    }

    #endregion

    #region 2) OverflowException

    public static void Factorial()
    {
        try
        {
            Console.Write("Enter a no: ");
            int input = int.Parse(Console.ReadLine());

            int f = 1;              // 5 * 4 * 3 * 2 * 1
            for (int i = 1; i <= input; i++)        // for (int i = input; i > 0; i--)  
            {
                f = f * i;
            }

            if (f <= 0)     // For Int32, max + value is 2147483647, and the min - value is -2147483648. If the f of the multiplication becomes negative, it indicates an overflow, as a positive integer cannot become negative due to multiplication. An overflow in this context means that the result exceeds the maximum representable value for a 32 - bit signed integer.
            {
                throw new OverflowException("Error: Result exceeds the Int32 maximum value.");
            }

            Console.WriteLine(f);
        }
        catch (OverflowException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    #endregion

    #region 3) Exception negative input
    public static void SqRoot()
    {
        try
        {
            Console.Write("Enter a no: ");
            double input = Convert.ToDouble(Console.ReadLine());

            if (input < 0)
            {
                throw new Exception("Error: Square root cannot be calculated for negative numbers");
            }

            double num = Math.Sqrt(input);
            Console.WriteLine(num);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    #endregion
    
    #region 4) Exception datetime format

    public static void DateTimeFormat()
    {
        //try       // incorrect format?? (20/03/20 -> it runs but sud throw exception)
        //{
        //    Console.Write("Enter DateTime: ");
        //    string input = Console.ReadLine();
        //    DateTime obj = Convert.ToDateTime(input);
        //    Console.WriteLine(obj);
        //}
        //catch (FormatException ex)
        //{
        //    Console.WriteLine(ex.Message);
        //    //OR
        //    Console.WriteLine("Error: DateTime input format is invalid.");
        //}

        //OR 

        try
        {
            Console.Write("Enter DateTime (dd/MM/yyyy): ");
            string input = Console.ReadLine();
            DateTime obj;

            // It ensures that the date and time parsing is done using the standard formats, regardless of the culture settings of the system. If we want, system setting, use "null"
            //if (DateTime.TryParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out obj))
                // OR
            
            if (DateTime.TryParseExact(input, "dd/MM/yyyy", null, DateTimeStyles.None, out obj))            // Here, null is valid bcs format in qstn matches format in system settings
            {
                Console.WriteLine("DateTime: " + obj.ToString("dd/MM/yyyy"));
            }
            else
            {
                throw new FormatException("Error: DateTime input format is invalid.");
            }
        }
        catch (FormatException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    #endregion

    #region 5) DivideByZeroException
    public static void Division()
    {
        try
        {
            Console.Write("Enter a numerator: ");
            double n1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter a denominator: ");
            double n2 = Convert.ToDouble(Console.ReadLine());

            double n = n1 / n2;

            if (n2 == 0)
            {
                throw new DivideByZeroException("Error: Denominator cannot be 0.");
            }
            Console.WriteLine("Numerator (n1) / Denominator (n2): " + n);
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    #endregion

    #region 5) DivideByZeroException
    public static void Checknegativeint()
    {
        Console.Write("Enter an integer no. ");
        int num = int.Parse(Console.ReadLine());
        try
        {
            if (num < 0)
            {
                throw new Exception("Error: Negative number.");
            }
            else
            {
                Console.WriteLine("The no. entered is: " + num);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    #endregion
}