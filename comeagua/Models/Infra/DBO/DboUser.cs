﻿using comeagua.Infra.Tables;
using comeagua.Models;
using comeagua.Models.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;

namespace comeagua.Infra.DBO
{
    public static class DboUser
    {
        public static string AddUser(User user)
        {
            var db = new ApplicationDbContext();
            db.Start();
            //User user = new User { Name = firstname, LastName = lastname, Birthday = birthday, Email = email, Password = password};
            var Query = (from Log in db.Users where Log.Email == user.Email select Log);

            if (Query is null)
            {
                db.Users.Add(user);

                db.SaveChanges();
                return "Usuario criado com sucesso!";
            }
            return "E-mail já cadastrado, tente novamente com outro e-mail.";
        }

        //public static void DeleteUser(int id)
        //{
        //    var db = new Contexto();
        //    db.Start();
        //    var user = new User { ID = id };
        //    db.Users.Attach(user);
        //    db.Users.Remove(user);

        //    db.SaveChanges();

        //}

        //public static void UpdateUser(User user)
        //{
        //    var db = new Contexto();

        //    db.Start();
        //    db.Users.Attach(user);
        //    db.Entry(user).State = System.Data.Entity.EntityState.Modified;
        //    db.SaveChanges();
        //}

        //public static string ExistUser(string email, string password)
        //{
        //    var db = new Contexto();
        //    var Query = (from Log in db.Users where Log.Email == email select Log);

        //    if (Query is null)
        //    {
        //        return "E-mail nao cadastrado.";
        //    }
        //    return ""; 
        //}
    }
}