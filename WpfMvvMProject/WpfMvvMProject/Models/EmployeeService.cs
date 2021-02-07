using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMvvMProject.Models
{
    public class EmployeeService
    {
        private static List<Employee> ObjEmployeeList;

        public EmployeeService()
        {
            ObjEmployeeList = new List<Employee>()
            {
                new Employee{Id=101, Name="Hakan", Age=22 },
                new Employee{Id=102, Name="mehmeet", Age=23 }
            };
        }

        public List<Employee> GetAll()
        {
            return ObjEmployeeList;
        }
        public bool Add(Employee objNewEmployee)
        {
            ObjEmployeeList.Add(objNewEmployee);
            return true;
        }

        public bool Update(Employee objEmployeeToUpdate)
        {
            bool IsUpdated = false;
            for(int i=0;i<ObjEmployeeList.Count;i++ )
            {
                if(ObjEmployeeList[i].Id==objEmployeeToUpdate.Id)
                {
                    ObjEmployeeList[i].Name = objEmployeeToUpdate.Name;
                    ObjEmployeeList[i].Id = objEmployeeToUpdate.Id;
                    ObjEmployeeList[i].Age = objEmployeeToUpdate.Age;
                    IsUpdated = true;
                    break;
                }
            }
            return IsUpdated;
        }
        public bool Delete(int id)
        {
            bool IsDeleted = false;
            for(int i=0;i<ObjEmployeeList.Count;i++ )
            {
                if(ObjEmployeeList[i].Id==id)
                {
                    ObjEmployeeList.RemoveAt(i);
                    IsDeleted = true;
                    break;
                }
            }
            return IsDeleted;
        }
        public Employee Search(int id)
        {
            return ObjEmployeeList.FirstOrDefault(e=>e.Id==id);
        }
    }
}
