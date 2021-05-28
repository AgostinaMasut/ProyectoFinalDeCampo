using LolaApp.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolaApp.DataAccess
{
    public class LolaAppContext : DbContext
    {

        public LolaAppContext() : base("CS")
        {

        }
        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {
            dbModelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
<<<<<<< Updated upstream
        public DbSet<Sexo> Sexo { get; set; }
        public DbSet<TipoDeUsario> TipoDeUsario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
=======
        public virtual DbSet<AntencedentesPrevios> AntencedentesPrevios { get; set; }
        public virtual DbSet<Asistencia> Asistencia { get; set; }
        public virtual DbSet<Camilla> Camilla { get; set; }
        public virtual DbSet<ComentarioCRM> ComentarioCRM { get; set; }
        public virtual DbSet<Consentimiento> Consentimiento { get; set; }
        public virtual DbSet<ConsentimientoCirugia> ConsentimientoCirugia { get; set; }
        public virtual DbSet<CRM> CRM { get; set; }
        public virtual DbSet<DiponibilidadDeMaquinas> DiponibilidadDeMaquinas { get; set; }
        public virtual DbSet<DisponibilidadCamilla> DisponibilidadCamilla { get; set; }
        public virtual DbSet<DisponibilidadCirugia> DisponibilidadCirugia { get; set; }
        public virtual DbSet<DisponibilidadProfesional> DisponibilidadProfesional { get; set; }
        public virtual DbSet<Frecuencia> Frecuencia { get; set; }
        public virtual DbSet<HistoriaClinicaMedicina> HistoriaClinicaMedicina { get; set; }
        public virtual DbSet<HistorialDisponibilidadProfesional> HistorialDisponibilidadProfesional { get; set; }
        public virtual DbSet<HistorialMedidasCorporales> HistorialMedidasCorporales { get; set; }
        public virtual DbSet<ListaDePrecios> ListaDePrecios { get; set; }
        public virtual DbSet<Maquina> Maquina { get; set; }
        public virtual DbSet<Paciente_PosiblePaciente> Paciente_PosiblePaciente { get; set; }
        public virtual DbSet<PatologiasEsteticas> PatologiasEsteticas { get; set; }
        public virtual DbSet<Protocolo> Protocolo { get; set; }
        public virtual DbSet<ProtocoloCirugia> ProtocoloCirugia { get; set; }
        public virtual DbSet<RiesgoEstetica> RiesgoEstetica { get; set; }
        public virtual DbSet<RiesgosCirugia> RiesgosCirugia { get; set; }
        public virtual DbSet<SeguimientoDeTratamientos> SeguimientoDeTratamientos { get; set; }
        public virtual DbSet<Sexo> Sexo { get; set; }
        public virtual DbSet<Sucursal> Sucursal { get; set; }
        public virtual DbSet<TipoCirugías> TipoCirugías { get; set; }
        public virtual DbSet<TipoDeAntecedentes> TipoDeAntecedentes { get; set; }
        public virtual DbSet<TipoDeAsistencia> TipoDeAsistencia { get; set; }
        public virtual DbSet<TipoDeConsulta> TipoDeConsulta { get; set; }
        public virtual DbSet<TipoDeConsultor> TipoDeConsultor { get; set; }
        public virtual DbSet<TipoDeMaquina> TipoDeMaquina { get; set; }
        public virtual DbSet<TipoDeMedio> TipoDeMedio { get; set; }
        public virtual DbSet<TipoDeTratamiento> TipoDeTratamiento { get; set; }
        public virtual DbSet<TipoDeUsuario> TipoDeUsuario { get; set; }
        public virtual DbSet<TipoMedidas> TipoMedidas { get; set; }
        public virtual DbSet<Tratamiento> Tratamiento { get; set; }
        public virtual DbSet<Turno> Turno { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<ZonaDelCuerpo> ZonaDelCuerpo { get; set; }
>>>>>>> Stashed changes
    }
}
