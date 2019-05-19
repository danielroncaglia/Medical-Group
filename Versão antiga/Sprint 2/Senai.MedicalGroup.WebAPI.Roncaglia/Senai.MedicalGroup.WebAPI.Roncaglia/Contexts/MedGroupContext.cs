using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.MedicalGroup.WebAPI.Roncaglia.Domains
{
    public partial class MedGroupContext : DbContext
    {
        public MedGroupContext()
        {
        }

        public MedGroupContext(DbContextOptions<MedGroupContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clinica> Clinica { get; set; }
        public virtual DbSet<Consultas> Consultas { get; set; }
        public virtual DbSet<Especialidades> Especialidades { get; set; }
        public virtual DbSet<Medicos> Medicos { get; set; }
        public virtual DbSet<Pacientes> Pacientes { get; set; }
        public virtual DbSet<Tipo> Tipo { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress; Initial Catalog= SENAI_MEDICAL_GROUP_2TT; User ID = sa; Password = 132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clinica>(entity =>
            {
                entity.HasKey(e => e.IdClinica);

                entity.ToTable("CLINICA");

                entity.Property(e => e.IdClinica).HasColumnName("ID_CLINICA");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasColumnName("CNPJ")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasColumnName("ENDERECO")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NomeClinica)
                    .IsRequired()
                    .HasColumnName("NOME_CLINICA")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Razao)
                    .IsRequired()
                    .HasColumnName("RAZAO")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Consultas>(entity =>
            {
                entity.HasKey(e => e.IdConsultas);

                entity.ToTable("CONSULTAS");

                entity.Property(e => e.IdConsultas).HasColumnName("ID_CONSULTAS");

                entity.Property(e => e.DataHorario)
                    .HasColumnName("DATA_HORARIO")
                    .HasColumnType("datetime");

                entity.Property(e => e.DescricaoConsulta)
                    .HasColumnName("DESCRICAO_CONSULTA")
                    .HasColumnType("text");

                entity.Property(e => e.IdMedico).HasColumnName("ID_MEDICO");

                entity.Property(e => e.IdPaciente).HasColumnName("ID_PACIENTE");

                entity.Property(e => e.Outros)
                    .HasColumnName("OUTROS")
                    .HasColumnType("text");

                entity.Property(e => e.SituacaoConsulta)
                    .IsRequired()
                    .HasColumnName("SITUACAO_CONSULTA")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdMedicoNavigation)
                    .WithMany(p => p.Consultas)
                    .HasForeignKey(d => d.IdMedico)
                    .HasConstraintName("FK__CONSULTAS__ID_ME__5CD6CB2B");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.Consultas)
                    .HasForeignKey(d => d.IdPaciente)
                    .HasConstraintName("FK__CONSULTAS__ID_PA__5BE2A6F2");
            });

            modelBuilder.Entity<Especialidades>(entity =>
            {
                entity.HasKey(e => e.IdEspecialidade);

                entity.ToTable("ESPECIALIDADES");

                entity.Property(e => e.IdEspecialidade).HasColumnName("ID_ESPECIALIDADE");

                entity.Property(e => e.EspecialidadeMedico)
                    .IsRequired()
                    .HasColumnName("ESPECIALIDADE_MEDICO")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Medicos>(entity =>
            {
                entity.HasKey(e => e.IdMedico);

                entity.ToTable("MEDICOS");

                entity.Property(e => e.IdMedico).HasColumnName("ID_MEDICO");

                entity.Property(e => e.CrmMedico)
                    .IsRequired()
                    .HasColumnName("CRM_MEDICO")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.IdClinica).HasColumnName("ID_CLINICA");

                entity.Property(e => e.IdEspecialidade).HasColumnName("ID_ESPECIALIDADE");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.Property(e => e.NomeMedico)
                    .IsRequired()
                    .HasColumnName("NOME_MEDICO")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClinicaNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdClinica)
                    .HasConstraintName("FK__MEDICOS__ID_CLIN__59FA5E80");

                entity.HasOne(d => d.IdEspecialidadeNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdEspecialidade)
                    .HasConstraintName("FK__MEDICOS__ID_ESPE__59063A47");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__MEDICOS__ID_USUA__5812160E");
            });

            modelBuilder.Entity<Pacientes>(entity =>
            {
                entity.HasKey(e => e.IdPaciente);

                entity.ToTable("PACIENTES");

                entity.Property(e => e.IdPaciente).HasColumnName("ID_PACIENTE");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("CPF")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasColumnName("ENDERECO")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.Property(e => e.Idade).HasColumnName("IDADE");

                entity.Property(e => e.InformacoesPaciente)
                    .HasColumnName("INFORMACOES_PACIENTE")
                    .HasColumnType("text");

                entity.Property(e => e.Nascimento)
                    .HasColumnName("NASCIMENTO")
                    .HasColumnType("date");

                entity.Property(e => e.NomePaciente)
                    .IsRequired()
                    .HasColumnName("NOME_PACIENTE")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Rg)
                    .IsRequired()
                    .HasColumnName("RG")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasColumnName("TELEFONE")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__PACIENTES__ID_US__5535A963");
            });

            modelBuilder.Entity<Tipo>(entity =>
            {
                entity.HasKey(e => e.IdTipo);

                entity.ToTable("TIPO");

                entity.HasIndex(e => e.TipoUsuario)
                    .HasName("UQ__TIPO__D13E583BEFBF54FF")
                    .IsUnique();

                entity.Property(e => e.IdTipo).HasColumnName("ID_TIPO");

                entity.Property(e => e.TipoUsuario)
                    .IsRequired()
                    .HasColumnName("TIPO_USUARIO")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("USUARIOS");

                entity.HasIndex(e => e.EmailUsuario)
                    .HasName("UQ__USUARIOS__A3C14D4949CA2EA1")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.Property(e => e.EmailUsuario)
                    .IsRequired()
                    .HasColumnName("EMAIL_USUARIO")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IdTipo).HasColumnName("ID_TIPO");

                entity.Property(e => e.SenhaUsuario)
                    .IsRequired()
                    .HasColumnName("SENHA_USUARIO")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(rand()*(10))");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipo)
                    .HasConstraintName("FK__USUARIOS__ID_TIP__5165187F");
            });
        }
    }
}
