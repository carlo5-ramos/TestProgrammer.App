using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
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
        #endregion

        #region Constructors
        public EmployeesViewModel()
        {
            this.IsRefreshing = true;
            this.apiService = new ApiService();
            this.LoadEmployees();
        }


        #endregion

        #region Methods
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
