using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BLL.ErrorManager;

namespace BLL
{
    internal class ErrorManager
    {

        public class ErrorManager
        {
            public static string CheckUser(string username)
            {
                if (string.IsNullOrEmpty(username))
                {
                    return "שם משתמש לא יכול להיות ריק";
                }

                //... אתה ממשיך להוסיף בדיקות נוספות לשם משתמש כאן ...

                return null;
            }

            public static string CheckPassword(string password)
            {
                if (string.IsNullOrEmpty(password))
                {
                    return "סיסמה לא יכולה להיות ריקה";
                }

                //... אתה ממשיך להוסיף בדיקות נוספות לסיסמה כאן ...

                return null;
            }
        }
        שלב 2: בלוגיקה שלך, תזמין את מתודות מנהל השגיאות

public class BusinessLogic
        {
            public void Login(string username, string password)
            {
                var errorMessage = ErrorManager.CheckUser(username);
                if (errorMessage != null)
                {
                    throw new Exception(errorMessage);
                }

                errorMessage = ErrorManager.CheckPassword(password);
                if (errorMessage != null)
                {
                    throw new Exception(errorMessage);
                }

                //... אתה ממשיך עם החלק שאחרי הבדיקות ...
            }
        }
        שלב 3: ב-Controller שלך, כלול את השגיאות של מנהל השגיאות

        [HttpPost("login")]
public IActionResult Login(string username, string password)
        {
            try
            {
                _businessLogic.Login(username, password);
                // המשתמש התחבר בהצלחה, תכניס קוד להחזרת אימות מצליח כאן ...
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
