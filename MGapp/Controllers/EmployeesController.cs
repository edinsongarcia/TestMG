using MGapp.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MGapp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        [HttpGet]
        public ActionResult GetEmployees()
        {
            try
            {
                EmployeeLogic logic = new EmployeeLogic();

                var employees = logic.GetEmployees();
                if (employees.Count == 0)
                {
                    return NotFound(new { message = "No existen empleados registrados" });
                }

                return Ok(employees);
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpGet("{id}")]
        public ActionResult GetEmployee(int ? id)
        {
            try
            {
                EmployeeLogic logic = new EmployeeLogic();

                List<EmployeeDTO> employees = logic.GetEmployees();

                return Ok(employees.Where(x => x.Id == id).ToList());
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
