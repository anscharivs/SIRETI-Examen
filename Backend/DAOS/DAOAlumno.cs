﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Connections;
using Backend.Models;

namespace Backend.DAOS
{
    public class DAOAlumno
    {
        public INewConnection connection;

        public DAOAlumno(INewConnection connection)
        {
            this.connection = connection;
        }

        public void Insert(Alumno alumno)
        {
            var sqlCommand = "INSERT INTO alumnos (control_alumno, nombre_alumno, paterno_alumno, materno_alumno, correo_alumno, contra_alumno, carrera_alumno)" +
                "VALUES (@ControlAlumno, @NombreAlumno, @PaternoAlumno, @MaternoAlumno, @CorreoAlumno, @ContraAlumno, @CarreraAlumno)";
            var columns = new string[]
            {
                "control_alumno",
                "nombre_alumno",
                "paterno_alumno",
                "materno_alumno",
                "correo_alumno",
                "contra_alumno",
                "carrera_alumno"
            };
            var keys = new object[]
            {
                alumno.ControlAlumno,
                alumno.NombreAlumno,
                alumno.PaternoAlumno,
                alumno.MaternoAlumno,
                alumno.CorreoAlumno,
                alumno.ContraAlumno,
                alumno.CarreraAlumno
            };

            IConnection localConnection = connection.Create();
            localConnection.Execute(sqlCommand, columns, keys);
        }
    }
}