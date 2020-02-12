using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using TestProgrammer.App.Models;
using TestProgrammer.App.Services;
using Xamarin.Forms;

namespace TestProgrammer.App.ViewModels
{
    public class EmployeesViewModel : BaseViewModel
    {
        #region Attributes
        private ApiService apiService;
        private bool isRefreshing;
        private ObservableCollection<Employees> employees;
        #endregion

        #region Properties
        public ObservableCollection<Employees> Employees
        {
            get { return this.employees; }
            set { this.SetValue(ref this.employees, value); }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { this.SetValue(ref this.isRefreshing, value); }
        }

        private double dividendo;

        public double Dividendo
        {
            get { return this.dividendo; }
            set
            {
                this.SetValue(ref this.dividendo, value);
                Division();
            }
        }

        private double divisor;

        public double Divisor
        {
            get { return this.divisor; }
            set
            {
                this.SetValue(ref this.divisor, value);
                Division();
            }
        }

        private double resultado;

        public double Resultado
        {
            get { return this.resultado; }
            set { this.SetValue(ref this.resultado, value); }
        }
        #endregion

        #region Constructors
        public EmployeesViewModel()
        {
            this.IsRefreshing = true;
            this.apiService = new ApiService();
            this.LoadEmployees();
            this.Dividendo = 0;
            this.Divisor = 0;
        }


        #endregion

        #region Commands
        //public ICommand CalcularCommand { get; set; }
        #endregion

        #region Methods
        private void Division()
        {
            if (Dividendo == 0 || Divisor == 0)
            {
                Resultado = 0;
            }
            Resultado = Dividendo / Divisor;
        }

        private async void LoadEmployees()
        {
            var connection = await this.apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Aceptar");
                return;
            }

            var response = await this.apiService.GetList<Employees>(
                "http://testunit-001-site1.ctempurl.com",
                "/api",
                "/API_Employees");
            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Aceptar");
                return;
            }

            var list = (List<Employees>)response.Result;
            this.Employees = new ObservableCollection<Employees>(list);
            this.IsRefreshing = false;
        }
        #endregion

        
    }
}
