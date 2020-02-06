using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProgrammer.App.Models
{
    public class Positions
    {
        public int PositionID { get; set; }

        public string PositionName { get; set; }

        //Relaciones
        [JsonIgnore]
        public virtual ICollection<Employees> Employees { get; set; }
    }
}
