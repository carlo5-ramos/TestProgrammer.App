using System;
using System.Collections.Generic;
using System.Text;
using TestProgrammer.App.ViewModels;

namespace TestProgrammer.App.Infrastructure
{
    public class InstanceLocator
    {
        #region Properties
        public MainViewModel Main { get; set; }
        #endregion

        #region Constructors
        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
        #endregion
    }
}
