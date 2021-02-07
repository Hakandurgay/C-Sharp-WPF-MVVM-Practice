using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using WpfMvvMProject.Models;
using WpfMvvMProject.Commands;
using System.Collections.ObjectModel;
namespace WpfMvvMProject.ViewModels
{
    public class EmployeeViewModel
    {



        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged !=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

        }
        EmployeeService ObjEmployeeService;
        public EmployeeViewModel()
        {
            ObjEmployeeService = new EmployeeService();
            LoadData();

            CurrentEmployee = new Employee();
            saveCommand =new RelayCommand(Save);
            searchCommand = new RelayCommand(Search);
            updateCommand = new RelayCommand(Update);
            deleteCommand = new RelayCommand(Delete);
        }
        private ObservableCollection<Employee> employeesList;
        public ObservableCollection<Employee> EmployeesList { get { return employeesList; } set { employeesList = value;OnPropertyChanged("EmployeesList"); } }

        private void LoadData()
        {
            EmployeesList = new ObservableCollection<Employee>( ObjEmployeeService.GetAll());
        }

        private Employee currentEmployee;
        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }

        public Employee CurrentEmployee
        {
            get { return currentEmployee; }
            set { currentEmployee = value; OnPropertyChanged("CurrentEmployee"); }
        }
        private RelayCommand saveCommand;

        public RelayCommand SaveCommand
        {
            get { return saveCommand; }
  
        }
        public void Save()
        {
            try
            {
                var IsSaved = ObjEmployeeService.Add(CurrentEmployee);
                if (IsSaved)
                {
                    Message = "Employee Saved";

                LoadData();
                }
                else
                    Message = "Save operation failed";
            }
            catch(Exception ex)
            {
                Message = ex.Message;
            }
        }
        #region Search
        private RelayCommand searchCommand;
        public RelayCommand SearchCommand { get { return searchCommand; } }
        public void Search()
        {
            try
            {
                var ObjEmployee = ObjEmployeeService.Search(currentEmployee.Id);
                if(ObjEmployee!=null)
                {
                    CurrentEmployee.Name = ObjEmployee.Name; 
                    CurrentEmployee.Age = ObjEmployee.Age; 
                }
                else
                {
                    Message = "Employee Not Found";
                }
            }
            catch (Exception)
            {

             
            }
        }
        #endregion

        #region update 
        private RelayCommand updateCommand;

        public RelayCommand UpdateCommand
        {
            get { return updateCommand; }       
        }
        public void Update()
        {
            try
            {
                 var IsUpdated = ObjEmployeeService.Update(CurrentEmployee);
                if (IsUpdated)
                {
                    Message = "Employee updated";
                    LoadData();
                }
                else
                {
                    Message = "Update Failed";
                }

            }
            catch (Exception ex)
            {

                Message = ex.Message;
            }
        }
        #endregion

        #region delete
        private RelayCommand deleteCommand;

        public RelayCommand DeleteCommand
        {
            get { return deleteCommand; }

        }
        public void Delete()
        {
            try
            {
                var IsDeleted = ObjEmployeeService.Delete(CurrentEmployee.Id);
                if(IsDeleted)
                {
                    Message = "Employee Deleted";
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
               
            }
        }

        #endregion
    }
}
