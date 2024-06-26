using AutoMapper;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static BLL.ErrorManager;

namespace BLL
{
    public class ErrorManager
    {
        Iuser user;
        IMapper _mapper;
       

        public ErrorManager(Iuser user, IMapper m)
        {

            this.user = user;
            _mapper = m;

        }

        public string sighnin(string username, string password)
        {
            // בדיקה אם שם המשתמש או הסיסמה ריקים
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return "שם משתמש או סיסמה לא יכולים להיות ריקים";
            }

            // בדיקה אם שם המשתמש קיים
            if (!user.UserExists(username))
            {
                return "שם משתמש זה לא קיים";
            }
            //בדיקה אם הסיסמה תואמת לשם המשתמש
            if (!user.PasswordMatches(username, password))
            {
                return "סיסמה שגויה";
            }
            return null;

        }

        public bool IsValidId(string id)
        {
            if (id.Length != 9)
            {
                return false;
            }

            int sum = 0;
            for (int i = 0; i < 8; i++)
            {
                var digit = int.Parse(id[i].ToString()) * ((i % 2) + 1);
                if (digit > 9)
                {
                    digit = digit / 10 + digit % 10;
                }

                sum += digit;
            }

            var checkDigit = (10 - (sum % 10)) % 10;
            return checkDigit == int.Parse(id[8].ToString());
             }
        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper, RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    var idn = new IdnMapping();

                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }


        public string sighnup(string username, string password, string confirmPassword
            , string id, string? email,string? role)
        {
            // בדיקה אם שם המשתמש או הסיסמה ריקים
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return "שם משתמש או סיסמה לא יכולים להיות ריקים";
            }
            // בדיקה אם שם המשתמש כבר קיים
            if (user.UserExists(username))
            {
                return "שם משתמש זה כבר קיים";
            }
            // בדיקה אם הסיסמאות תואמות
            if (password != confirmPassword)
            {
                return "הסיסמאות לא תואמות";
            }
            // בדיקה אם מספר הזהות תקין
            if (!IsValidId(id))
            {
                return "מספר הזהות לא חוקי";
            }
            // בדיקה אם הדוא"ל הוא חוקי  
            if (!IsValidEmail(email))

                return "הדואל אינו חוקי" ;
           return null;
            

        }


    } }

