using System;
using System.Collections.Generic;
using System.Text;

namespace TestProgrammer.App.ViewModels
{
    public class MainViewModel
    {
        #region Properties
        public EmployeesViewModel Employees { get; set; }

        public EmployeesViewModel Split { get; set; }
        #endregion

        #region Constructors
        public MainViewModel()
        {
            this.Employees = new EmployeesViewModel();
            this.Split = new EmployeesViewModel();
        }
        #endregion
    }
}
