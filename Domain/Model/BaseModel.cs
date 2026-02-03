using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Model
{
    public abstract class BaseModel
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public bool Deleted { get; set; } = false;
        
    }
}