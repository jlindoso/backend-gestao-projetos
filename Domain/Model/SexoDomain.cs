using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class SexoDomain: BaseModel
    {
        public string Nome { get; set; }
        public bool Biologico { get; set; }
    }

    public static class SexoIds
    {
        // Sexo biológico
        public static readonly Guid MasculinoBiologico = Guid.Parse("10101010-1010-1010-1010-101010101010");
        public static readonly Guid FemininoBiologico  = Guid.Parse("20202020-2020-2020-2020-202020202020");
        public static readonly Guid Intersexo          = Guid.Parse("30303030-3030-3030-3030-303030303030");

        // Gênero / Identidade
        public static readonly Guid Homem              = Guid.Parse("40404040-4040-4040-4040-404040404040");
        public static readonly Guid Mulher             = Guid.Parse("50505050-5050-5050-5050-505050505050");
        public static readonly Guid NaoBinario         = Guid.Parse("60606060-6060-6060-6060-606060606060");
        public static readonly Guid Outro              = Guid.Parse("70707070-7070-7070-7070-707070707070");
        public static readonly Guid PrefereNaoInformar = Guid.Parse("80808080-8080-8080-8080-808080808080");
    }
}