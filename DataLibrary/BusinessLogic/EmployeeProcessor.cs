using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class EmployeeProcessor
    {
        public static int CreateEmployee(int employeeId, string firstName, string lastName, string emailAddress)
        {
            var data = new EmployeeModel 
            { 
                EmployeeId = employeeId,
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = emailAddress
            };

            string sql = @"INSERT INTO TBL_DATAACCESS (EMPLOYEE_ID, FIRST_NAME, LAST_NAME, EMAIL_ADDRESS) 
                            VALUES (:EmployeeId, :FirstName, :LastName, :EmailAddress)";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<EmployeeModel> LoadEmployees()
        {
            string sql = @"SELECT ID Id, EMPLOYEE_ID EmployeeId, FIRST_NAME FirstName, LAST_NAME LastName, EMAIL_ADDRESS EmailAddress 
                            FROM TBL_DATAACCESS";
            return SqlDataAccess.LoadData<EmployeeModel>(sql);
        }
    }
}
