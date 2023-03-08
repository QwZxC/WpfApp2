﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }


        public static void CreateAdmin()
        {
            using (var db = new DBContext())
            {
                //db.Database.Create();
                var user = new User { Login = "Admin", PasswordHash = "Admin" };
                db.Users.Add(user);
                db.SaveChanges();
            }
        }
        public static User LogIn(string login, string password)
        {
            using(var db = new DBContext())
            {
                try
                {
                    return db.Users.Where(u => u.Login == login && u.PasswordHash == password).First();
                }
                catch
                {
                    return null;
                }
            }
            
        }
    }
}
