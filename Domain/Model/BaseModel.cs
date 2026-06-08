using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Model
{
    public abstract class BaseModel
    {
        public Guid Id { get; set; }
        [JsonIgnore]
        public DateTime Created { get; set; }
        
        [JsonIgnore]
        public bool Deleted { get; set; } = false;
        
    }
}