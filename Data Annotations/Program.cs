using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data_Annotations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            User p = new User( 6, "Alexa",19,"abc@gmailcom","Ashr@2", "Ashr@2", "9591099202","https://123xyz.com");
            var validationresult=new List<ValidationResult>();
            var validationcontext = new ValidationContext(p);
            bool isvalid=Validator.TryValidateObject(p,validationcontext,validationresult,true);
            if (isvalid)
            {
                Console.WriteLine("Validation successful");
            }
            else
            {
                foreach (var item in validationresult)
                {
                    Console.WriteLine(item.ErrorMessage);
                }
            }

        }
    }
}
