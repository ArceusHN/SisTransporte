﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class tbRoles
    {
        public tbRoles()
        {
            tbRolPantallas = new HashSet<tbRolPantallas>();
            tbUsuarios = new HashSet<tbUsuarios>();
        }

        public int rol_Id { get; set; }
        public string rol_Descripcion { get; set; }
        public bool? rol_Estado { get; set; }
        public bool rol_EsEliminado { get; set; }

        public virtual ICollection<tbRolPantallas> tbRolPantallas { get; set; }
        public virtual ICollection<tbUsuarios> tbUsuarios { get; set; }
    }
}