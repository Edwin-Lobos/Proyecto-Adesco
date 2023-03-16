using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Adesco
{
    internal class Control
    {
        //-------------------------------Control de registro-------------------------------------------
        public string ctrlRegistro(Usuarios usuario)
        {
            Modelo modelo = new Modelo();
            string respuesta = "";

            if (string.IsNullOrEmpty(usuario.Usuario) || string.IsNullOrEmpty(usuario.Password) || string.IsNullOrEmpty(usuario.Conpassword) || string.IsNullOrEmpty(usuario.Nombre))
            {
                respuesta = "Debe llenar todos los campos";
            } else
            {
                if (usuario.Password == usuario.Conpassword)
                {
                    if (modelo.existeuser(usuario.Usuario))
                    {
                        respuesta = "El usuario ya existe";
                    }
                    else
                    {
                        usuario.Password = generarSHA1(usuario.Password);
                        modelo.registro(usuario);
                    }
                }
                else
                {
                    respuesta = "Las contraseñas no coinciden";
                }
            }
            return respuesta;
        }
        //--------------------------------Control de login-------------------------------------------
        public string ctrlLogin(string usuario, string password)
        {
            Modelo modelo = new Modelo();
            string respuesta = "";
            Usuarios datosUsuarios = null;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                respuesta = "Debe llenar todos los campos";

            }
            else
            {
                datosUsuarios = modelo.user(usuario);
                if (datosUsuarios == null)
                {
                    respuesta = "El usuario no existe";
                }
                else
                {
                    if (datosUsuarios.Password != generarSHA1(password))
                    {
                        respuesta = "El usuario y/o contraseña no coninciden";
                    }
                    else
                    {

                        Session.id = datosUsuarios.Id;
                        Session.usuarios = usuario;
                        Session.nombre = datosUsuarios.Nombre;
                        Session.id_tipo = datosUsuarios.Id_tipo;
                    }
                }
            }
            return respuesta;
        }
        //--------------------------------------------------------------------------------------------
        //--------Generar clave incriptada------------------------------------------------------
        private string generarSHA1(string cadena)
        {
            UTF8Encoding enc = new UTF8Encoding();
            byte[] data = enc.GetBytes(cadena);
            byte[] result;

            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();
            result = sha.ComputeHash(data);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] < 16)
                {
                    sb.Append("0");

                }
                sb.Append(result[i].ToString("x"));
            }
            return sb.ToString();
        }
    

        //--------------------------------------------------------------------------------------------
        
    }
}

