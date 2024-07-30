using DAL.Interfaces;
using DAL.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.functions
{
    public class LibrarianPermissionsDal:ILibrarianPermissions
    {
        LiberiansDbContext LiberiansDbContext;
        public LibrarianPermissionsDal(LiberiansDbContext LiberiansDbContext)
        {
            this.LiberiansDbContext = LiberiansDbContext;
        }

        public LibrarianPermission UpdatePermissions(int userId, string[] p)
        {
            LibrarianPermission userPermissions = LiberiansDbContext.LibrarianPermissions.FirstOrDefault(up => up.UserId == userId);

            if (userPermissions == null)
            {
                // אפשר להחזיר שגיאה או לזרוק חריגה
                throw new Exception("User not found");
            }

            // הקצאת מערך חדש בגודל מתאים
            userPermissions.Permissions = new string[p.Length];

            // הוספת ההרשאות החדשות
            for (int i = 0; i < p.Length; i++)
            {
                userPermissions.Permissions[i] = p[i];
            }


            LiberiansDbContext.SaveChangesAsync();
            var a = LiberiansDbContext.LibrarianPermissions.FirstOrDefault(lp => lp.UserId == userId);

            return a;
            }
        }
    }

