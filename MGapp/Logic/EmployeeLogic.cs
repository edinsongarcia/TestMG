using MGapp.DataManager;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MGapp.Logic
{
	public class EmployeeLogic
    {
        public List<EmployeeDTO> GetEmployees()
        {
			try
			{
				EmployeeManager manager = new EmployeeManager();

				string data = manager.GetDataEmployees();

				if (data == "Error")
				{
					return new List<EmployeeDTO>();
				}
				List<EmployeeDTO> infoEmployees = JsonConvert.DeserializeObject<List<EmployeeDTO>>(data);


				foreach (var item in infoEmployees)
				{
					if (item.ContractTypeName == "MonthlySalaryEmployee")
					{
						item.AnnualSalary = item.MonthlySalary * 12;
					}
					else
					{
						item.AnnualSalary = 120 * item.HourlySalary * 12;
					}
				}

				return infoEmployees;
			}
			catch (Exception e)
			{
				var err = e;
				throw;
			}
        }
    }
}
