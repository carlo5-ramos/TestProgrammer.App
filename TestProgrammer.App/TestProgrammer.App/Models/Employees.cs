using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProgrammer.App.Models
{
    public class Employees
    {
        public int EmployeeID { get; set; }
        
        public string EmployeeName { get; set; }
        
        public int PositionID { get; set; }
        
        public int ProfileID { get; set; }

        //Relaciones
        [JsonIgnore]
        public virtual Positions Positions { get; set; }

        [JsonIgnore]
        public virtual Profiles Profiles { get; set; }
    }
}
