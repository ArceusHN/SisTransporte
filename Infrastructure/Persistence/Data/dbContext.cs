﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Domain.Entities;

#nullable disable

namespace Infrastructure.Data
{
    public partial class dbContext : DbContext
    {
        public dbContext()
        {
        }

        public dbContext(DbContextOptions<dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<tbComponentes> tbComponentes { get; set; }
        public virtual DbSet<tbDepartamentos> tbDepartamentos { get; set; }
        public virtual DbSet<tbEmpleadoSucursales> tbEmpleadoSucursales { get; set; }
        public virtual DbSet<tbEmpleados> tbEmpleados { get; set; }
        public virtual DbSet<tbModulos> tbModulos { get; set; }
        public virtual DbSet<tbMunicipios> tbMunicipios { get; set; }
        public virtual DbSet<tbPantallas> tbPantallas { get; set; }
        public virtual DbSet<tbPersonas> tbPersonas { get; set; }
        public virtual DbSet<tbRolPantallas> tbRolPantallas { get; set; }
        public virtual DbSet<tbRoles> tbRoles { get; set; }
        public virtual DbSet<tbSucursales> tbSucursales { get; set; }
        public virtual DbSet<tbTransportistas> tbTransportistas { get; set; }
        public virtual DbSet<tbUsuarios> tbUsuarios { get; set; }
        public virtual DbSet<tbViajeEmpleadoSucursales> tbViajeEmpleadoSucursales { get; set; }
        public virtual DbSet<tbViajes> tbViajes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<tbComponentes>(entity =>
            {
                entity.HasKey(e => e.comp_Id)
                    .HasName("PK_Acce_tbComponentes_comp_Id");

                entity.ToTable("tbComponentes", "Acce");

                entity.Property(e => e.comp_Descripcion)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<tbDepartamentos>(entity =>
            {
                entity.HasKey(e => e.depto_Id)
                    .HasName("PK_Gral_tbDepartamentos_depto_Id");

                entity.ToTable("tbDepartamentos", "Gral");

                entity.HasIndex(e => e.depto_Descripcion, "UQ_Gral_tbDepartamentos_depto_Descripcion")
                    .IsUnique();

                entity.Property(e => e.depto_Codigo)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.depto_Descripcion)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.depto_EsEliminado).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<tbEmpleadoSucursales>(entity =>
            {
                entity.HasKey(e => e.empSuc_Id)
                    .HasName("FK_tbEmpleadoSucursales_empSuc_Id");

                entity.ToTable("tbEmpleadoSucursales", "Gral");

                entity.HasOne(d => d.emp)
                    .WithMany(p => p.tbEmpleadoSucursales)
                    .HasForeignKey(d => d.emp_Id);

                entity.HasOne(d => d.suc)
                    .WithMany(p => p.tbEmpleadoSucursales)
                    .HasForeignKey(d => d.suc_Id);
            });

            modelBuilder.Entity<tbEmpleados>(entity =>
            {
                entity.HasKey(e => e.emp_Id)
                    .HasName("PK_Admin_tbEmpleados_emp_Id");

                entity.ToTable("tbEmpleados", "Gral");

                entity.Property(e => e.emp_Estado)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.emp_Fecha).HasColumnType("date");

                entity.HasOne(d => d.pers)
                    .WithMany(p => p.tbEmpleados)
                    .HasForeignKey(d => d.pers_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Admin_tbPersonas_tbEmpleados_pers_Id");
            });

            modelBuilder.Entity<tbModulos>(entity =>
            {
                entity.HasKey(e => e.mod_Id)
                    .HasName("PK_Acce_tbModulos_mod_Id");

                entity.ToTable("tbModulos", "Acce");

                entity.Property(e => e.mod_Descripcion)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.comp)
                    .WithMany(p => p.tbModulos)
                    .HasForeignKey(d => d.comp_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Acce_tbComponentes_tbModulos_comp_Id");
            });

            modelBuilder.Entity<tbMunicipios>(entity =>
            {
                entity.HasKey(e => e.mpio_Id)
                    .HasName("PK_Gral_tbMunicipios_mpio_Id");

                entity.ToTable("tbMunicipios", "Gral");

                entity.Property(e => e.mpio_Codigo)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.mpio_Descripcion)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.mpio_EsEliminado).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.depto)
                    .WithMany(p => p.tbMunicipios)
                    .HasForeignKey(d => d.depto_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gral_tbMunicipios_tbDepartamentos_depto_Id");
            });

            modelBuilder.Entity<tbPantallas>(entity =>
            {
                entity.HasKey(e => e.pant_Id)
                    .HasName("PK_Acce_tbPantallas_modpt_Id");

                entity.ToTable("tbPantallas", "Acce");

                entity.Property(e => e.pant_Descripcion)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.mod)
                    .WithMany(p => p.tbPantallas)
                    .HasForeignKey(d => d.mod_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Acce_tbModulos_tbPantallas_mod_Id");
            });

            modelBuilder.Entity<tbPersonas>(entity =>
            {
                entity.HasKey(e => e.per_Id)
                    .HasName("PK_Gral_tbPersonas_pers_Id");

                entity.ToTable("tbPersonas", "Gral");

                entity.HasIndex(e => e.per_Identidad, "UQ_Gral_tbPersonas_pers_Identidad")
                    .IsUnique();

                entity.Property(e => e.per_Correo)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.per_Direccion)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.per_EsEliminado).HasDefaultValueSql("((0))");

                entity.Property(e => e.per_Esciv)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.per_FechaNac).HasColumnType("date");

                entity.Property(e => e.per_Identidad)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.per_PrimerApellido)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.per_PrimerNombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.per_SegundoApellido).HasMaxLength(50);

                entity.Property(e => e.per_SegundoNombre).HasMaxLength(50);

                entity.Property(e => e.per_Sexo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.per_Telefono)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.HasOne(d => d.depto)
                    .WithMany(p => p.tbPersonas)
                    .HasForeignKey(d => d.depto_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gral_tbDepartamentos_tbPersonas_depto_Id");

                entity.HasOne(d => d.mpio)
                    .WithMany(p => p.tbPersonas)
                    .HasForeignKey(d => d.mpio_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gral_tbMunicipios_tbPersonas_mpio_Id");
            });

            modelBuilder.Entity<tbRolPantallas>(entity =>
            {
                entity.HasKey(e => e.rolpt_Id)
                    .HasName("PK_Acce_tbRolPantallas_rolpt_Id");

                entity.ToTable("tbRolPantallas", "Acce");

                entity.HasOne(d => d.pant)
                    .WithMany(p => p.tbRolPantallas)
                    .HasForeignKey(d => d.pant_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Acce_tbRolPantallas_tbPantallas_pant_Id");

                entity.HasOne(d => d.rol)
                    .WithMany(p => p.tbRolPantallas)
                    .HasForeignKey(d => d.rol_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Acce_tbRolPantallas_tbRoles_rol_Id");
            });

            modelBuilder.Entity<tbRoles>(entity =>
            {
                entity.HasKey(e => e.rol_Id)
                    .HasName("PK_Acce_tbRoles_rol_Id");

                entity.ToTable("tbRoles", "Acce");

                entity.HasIndex(e => e.rol_Descripcion, "UQ_Acce_tbRoles_rol_Descripcion")
                    .IsUnique();

                entity.Property(e => e.rol_Descripcion)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.rol_Estado)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<tbSucursales>(entity =>
            {
                entity.HasKey(e => e.suc_Id)
                    .HasName("PK_Clte_tbSucursales_suc_Id");

                entity.ToTable("tbSucursales", "Gral");

                entity.Property(e => e.suc_Correo)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.suc_Direccion)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.suc_EsEliminado).HasDefaultValueSql("((0))");

                entity.Property(e => e.suc_Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.suc_Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.suc_Telefono)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.depto)
                    .WithMany(p => p.tbSucursales)
                    .HasForeignKey(d => d.depto_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clte_tbDepartamentos_tbSucursales_depto_Id");

                entity.HasOne(d => d.mpio)
                    .WithMany(p => p.tbSucursales)
                    .HasForeignKey(d => d.mpio_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clte_tbMunicipios_tbSucursales_mpio_Id");
            });

            modelBuilder.Entity<tbTransportistas>(entity =>
            {
                entity.HasKey(e => e.trans_Id)
                    .HasName("PK_tbTransportistas_trans_Id");

                entity.ToTable("tbTransportistas", "Gral");

                entity.HasOne(d => d.per)
                    .WithMany(p => p.tbTransportistas)
                    .HasForeignKey(d => d.per_Id);
            });

            modelBuilder.Entity<tbUsuarios>(entity =>
            {
                entity.HasKey(e => e.usu_Id)
                    .HasName("PK_Acce_tbUsuarios_usu_Id");

                entity.ToTable("tbUsuarios", "Acce");

                entity.HasIndex(e => e.usu_NombreUsuario, "UQ_Acce_tbUsuarios_usu_NombreUsuario")
                    .IsUnique();

                entity.Property(e => e.usu_Contraseña)
                    .IsRequired()
                    .HasMaxLength(8000);

                entity.Property(e => e.usu_Estado)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.usu_NombreUsuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.per)
                    .WithMany(p => p.tbUsuarios)
                    .HasForeignKey(d => d.per_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Acce_tbUsuarios_tbPersonas_pers_Id");

                entity.HasOne(d => d.rol)
                    .WithMany(p => p.tbUsuarios)
                    .HasForeignKey(d => d.rol_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Acce_tbUsuarios_tbRoles_rol_Id");
            });

            modelBuilder.Entity<tbViajeEmpleadoSucursales>(entity =>
            {
                entity.HasKey(e => e.viaEmpSuc_Id)
                    .HasName("PK_tbViajeEmpleadoSucursales_viaEmpSuc_Id");

                entity.ToTable("tbViajeEmpleadoSucursales", "Gral");

                entity.HasOne(d => d.empSuc)
                    .WithMany(p => p.tbViajeEmpleadoSucursales)
                    .HasForeignKey(d => d.empSuc_Id);

                entity.HasOne(d => d.via)
                    .WithMany(p => p.tbViajeEmpleadoSucursales)
                    .HasForeignKey(d => d.via_Id);
            });

            modelBuilder.Entity<tbViajes>(entity =>
            {
                entity.HasKey(e => e.via_Id)
                    .HasName("PK_tbViajes_via_Id");

                entity.ToTable("tbViajes", "Gral");

                entity.Property(e => e.via_FechaSalida).HasColumnType("datetime");

                entity.HasOne(d => d.trans)
                    .WithMany(p => p.tbViajes)
                    .HasForeignKey(d => d.trans_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}