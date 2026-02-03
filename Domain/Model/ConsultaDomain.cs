using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class ConsultaDomain: BaseModel
    {
        public Guid PacienteId { get; set; }
        public virtual PacienteDomain Paciente { get; set; }

        public Guid? AtendenteId { get; set; }

        public virtual UsuarioDomain Atendente { get; set; }

        public Guid? MedicoId { get; set; }
        public virtual MedicoDomain Medico { get; set; }

        public DateTime DataConsulta { get; set; }


        public Guid StatusId { get; set; }
        public virtual StatusConsultaDomain Status { get; set; }


        public bool IsProcedimento { get; set; } = false;

        public Guid TipoId { get; set; }
        public virtual TipoConsultaDomain Tipo { get; set; }


    }
}