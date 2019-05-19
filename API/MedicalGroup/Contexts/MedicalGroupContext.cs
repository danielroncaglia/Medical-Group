using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MedicalGroup.Domains
{
    public partial class MedicalGroupContext : DbContext
    {
        public MedicalGroupContext()
        {
        }

        public MedicalGroupContext(DbContextOptions<MedicalGroupContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clinica> Clinica { get; set; }
        public virtual DbSet<Consultas> Consultas { get; set; }
        public virtual DbSet<Especialidades> Especialidades { get; set; }
        public virtual DbSet<Medicos> Medicos { get; set; }
        public virtual DbSet<Pacientes> Pacientes { get; set; }
        public virtual DbSet<TipoUsuarios> TipoUsuarios { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-C2G6OVOK;Initial Catalog=SPMEDICAL_GROUP;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Clinica>(entity =>
            {
                entity.HasKey(e => e.IdClinica)
                    .HasName("PK__CLINICA__F5EAAE32B7070C5B");

                entity.ToTable("CLINICA");

                entity.Property(e => e.IdClinica).HasColumnName("ID_CLINICA");

                entity.Property(e => e.CnpjClinica)
                    .IsRequired()
                    .HasColumnName("CNPJ_CLINICA")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.EnderecoClinica)
                    .IsRequired()
                    .HasColumnName("ENDERECO_CLINICA")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NomeClinica)
                    .IsRequired()
                    .HasColumnName("NOME_CLINICA")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasColumnName("RAZAO_SOCIAL")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Consultas>(entity =>
            {
                entity.HasKey(e => e.IdConsulta)
                    .HasName("PK__CONSULTA__6E821E5AE2E79B2D");

                entity.ToTable("CONSULTAS");

                entity.Property(e => e.IdConsulta).HasColumnName("ID_CONSULTA");

                entity.Property(e => e.DataHorario)
                    .HasColumnName("DATA_HORARIO")
                    .HasColumnType("datetime");

                entity.Property(e => e.DescricaoConsulta)
                    .HasColumnName("DESCRICAO_CONSULTA")
                    .HasColumnType("text");

                entity.Property(e => e.IdMedico).HasColumnName("ID_MEDICO");

                entity.Property(e => e.IdPaciente).HasColumnName("ID_PACIENTE");

                entity.Property(e => e.SituacaoConsulta)
                    .IsRequired()
                    .HasColumnName("SITUACAO_CONSULTA")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdMedicoNavigation)
                    .WithMany(p => p.Consultas)
                    .HasForeignKey(d => d.IdMedico)
                    .HasConstraintName("FK__CONSULTAS__ID_ME__534D60F1");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.Consultas)
                    .HasForeignKey(d => d.IdPaciente)
                    .HasConstraintName("FK__CONSULTAS__ID_PA__52593CB8");
            });

            modelBuilder.Entity<Especialidades>(entity =>
            {
                entity.HasKey(e => e.IdEspecialidade)
                    .HasName("PK__ESPECIAL__2840B279362637AC");

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
                entity.HasKey(e => e.IdMedico)
                    .HasName("PK__MEDICOS__1DBF7DAD4F3E0907");

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
                    .HasConstraintName("FK__MEDICOS__ID_CLIN__4F7CD00D");

                entity.HasOne(d => d.IdEspecialidadeNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdEspecialidade)
                    .HasConstraintName("FK__MEDICOS__ID_ESPE__4E88ABD4");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__MEDICOS__ID_USUA__4D94879B");
            });

            modelBuilder.Entity<Pacientes>(entity =>
            {
                entity.HasKey(e => e.IdPaciente)
                    .HasName("PK__PACIENTE__62CD58D752E088E7");

                entity.ToTable("PACIENTES");

                entity.Property(e => e.IdPaciente).HasColumnName("ID_PACIENTE");

                entity.Property(e => e.CpfPaciente)
                    .IsRequired()
                    .HasColumnName("CPF_PACIENTE")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.EnderecoPaciente)
                    .IsRequired()
                    .HasColumnName("ENDERECO_PACIENTE")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.Property(e => e.InformacoesPaciente)
                    .HasColumnName("INFORMACOES_PACIENTE")
                    .HasColumnType("text");

                entity.Property(e => e.NascimentoPaciente)
                    .HasColumnName("NASCIMENTO_PACIENTE")
                    .HasColumnType("date");

                entity.Property(e => e.NomePaciente)
                    .IsRequired()
                    .HasColumnName("NOME_PACIENTE")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RgPaciente)
                    .IsRequired()
                    .HasColumnName("RG_PACIENTE")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonePaciente)
                    .IsRequired()
                    .HasColumnName("TELEFONE_PACIENTE")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__PACIENTES__ID_US__3E52440B");
            });

            modelBuilder.Entity<TipoUsuarios>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TIPO_USU__85A05968E1426BB0");

                entity.ToTable("TIPO_USUARIOS");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("ID_TIPO_USUARIO");

                entity.Property(e => e.TipoUsuario)
                    .IsRequired()
                    .HasColumnName("TIPO_USUARIO")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__USUARIOS__91136B90878B11E5");

                entity.ToTable("USUARIOS");

                entity.HasIndex(e => e.EmailUsuario)
                    .HasName("UQ__USUARIOS__A3C14D493077CA81")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.Property(e => e.EmailUsuario)
                    .IsRequired()
                    .HasColumnName("EMAIL_USUARIO")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IdTipoUsuario).HasColumnName("ID_TIPO_USUARIO");

                entity.Property(e => e.SenhaUsuario)
                    .IsRequired()
                    .HasColumnName("SENHA_USUARIO")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(rand()*(10))");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__USUARIOS__ID_TIP__3A81B327");
            });
        }
    }
}
