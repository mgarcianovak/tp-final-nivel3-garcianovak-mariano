﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class UserController
    {
        readonly DataAccess dataAccess = new DataAccess();

        public User Login(string email, string password) 
        {
            User user;
            try
            {
                dataAccess.SetCommandText("SELECT Id, email, pass, nombre, apellido, urlImagenPerfil, admin FROM USERS WHERE email = @email AND pass = @password");
                dataAccess.SetParameter("@email", email);
                dataAccess.SetParameter("@password", password);
                dataAccess.ReadData();
                if (dataAccess.Reader.Read())
                {
                    user = new User
                    {
                        Id = (int)dataAccess.Reader["id"],
                        Email = email,
                        Password = password,
                        //Name = (string)dataAccess.Reader["nombre"],
                        //Surname = (string)dataAccess.Reader["apellido"],
                        //ImageUrl = (string)dataAccess.Reader["urlImagenPerfil"],
                        isAdmin = (bool)dataAccess.Reader["admin"]
                    };
                }
                else
                {
                    user = null;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                dataAccess.CloseConnection();
            }

            return user;
        }
    }
}