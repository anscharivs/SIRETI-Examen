﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Backend.DAOS;
using Backend.Connections;
using Backend.Models;
using Backend.Security;

namespace Frontend
{
    public partial class frmLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            serverError.Visible = false;
        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            /* Aquí falta una validación del lado del servidor */
            var email = txtCorreo.Text;
            var password = PasswordService.GetHash(txtContra.Text);
            Alumno alumno;
            Usuario usuario;
            alumno = new DAOAlumno(new NewConnection()).Login(email, password);

            if (alumno != null)
            {
                Session["tipo"] = alumno.TipoAlumno;
                Session["nombre"] = String.Format("{0} {1} {2}", alumno.NombreAlumno, alumno.PaternoAlumno, alumno.MaternoAlumno);
                Response.Redirect("FrmInicio.aspx");
            }
            else
            {
                usuario = new DAOUsuario(new NewConnection()).Login(email, password);

                if (usuario != null)
                {
                    Session["tipo"] = usuario.TipoUsuario;
                    Session["nombre"] = String.Format("{0} {1} {2}", usuario.NombreUsuario, usuario.PaternoUsuario, usuario.MaternoUsuario);
                    Response.Redirect("FrmInicio.aspx");
                }
                else
                {
                    serverError.Visible = true;
                }
            }
            //Alumno a = new DAOAlumno(new NewConnection()).Login("oscar@mail.com", "c8fd86a8122bd6134b4ad704080b2e9467f281af");
        }
    }
}