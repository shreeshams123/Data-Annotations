using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace Data_Annotations
{
    public class User
    {
        [Required(ErrorMessage ="Invalid Id")]
        
        public int? Id { get; set; }
        [Required]
        [StringLength(10,MinimumLength =5)]
        public string Name { get; set; }
        [Range(19,99)]
        public int Age {  get; set; }
        [EmailAddress(ErrorMessage ="Invalid email id")]
        public string Email { get; set; }
        [Required]

        [CustomValidation(typeof(User),nameof(ValidatePassword))]
        public string Password { get; set; }
        
        [Required]
        [Compare("Password")]
        public string ConfirmPassword {  get; set; }
        [Phone]
        public string Phno {  get; set; }
        [Url]
        public string LinkedIn {  get; set; }


        public User(int? id, string name,int age,string email,string password,string conpass,string phno,string linkedIn)
        {
            Id = id;
            Name = name;
            Age = age;
            Email = email;
            Password = password;
            ConfirmPassword = conpass;
            Phno = phno;
            LinkedIn = linkedIn;
        }
        public static ValidationResult ValidatePassword(string Password, ValidationContext context)
        {
            string pattern = @"(?=.*[A-Z])(?=.*[a-z])(?=.*[1-9])";

            if (Regex.IsMatch(Password, pattern)){
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Invalid Password");
            }
        }
    }
}

