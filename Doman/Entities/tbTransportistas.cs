// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class tbTransportistas
    {
        public tbTransportistas()
        {
            tbViajes = new HashSet<tbViajes>();
        }

        public int trans_Id { get; set; }
        public int? per_Id { get; set; }
        public double? tarifaPorKilometro { get; set; }

        public virtual tbPersonas per { get; set; }
        public virtual ICollection<tbViajes> tbViajes { get; set; }
    }
}