﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class tbEmpleados
    {
        public tbEmpleados()
        {
            tbEmpleadoSucursales = new HashSet<tbEmpleadoSucursales>();
        }

        public int emp_Id { get; set; }
        public int pers_Id { get; set; }
        public DateTime emp_Fecha { get; set; }
        public bool? emp_Estado { get; set; }
        public bool emp_EsEliminado { get; set; }

        public virtual tbPersonas pers { get; set; }
        public virtual ICollection<tbEmpleadoSucursales> tbEmpleadoSucursales { get; set; }
    }
}