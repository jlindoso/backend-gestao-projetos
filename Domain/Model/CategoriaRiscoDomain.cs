using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Model
{
    // Técnico, Gerencial, Comercial, Externo.
    public class CategoriaRiscoDomain: BaseModel
    {
        public string Nome { get; set; }
    }

    // Baixo, Médio, Alto)
    public class ProbabilidadeRiscoDomain: BaseModel
    {
        public string Nome { get; set; }
    }

    // Baixo, Médio, Alto
    public class ImpactoRiscoDomain: BaseModel
    {
        public string Nome { get; set; }
    }
}