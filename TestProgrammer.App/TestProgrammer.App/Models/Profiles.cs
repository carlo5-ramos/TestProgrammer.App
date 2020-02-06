using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProgrammer.App.Models
{
    public class Profiles
    {
        public int ProfileID { get; set; }

        public string ProfileName { get; set; }

        //Relaciones
        [JsonIgnore]
        public virtual ICollection<Employees> Employees { get; set; }
    }
}
