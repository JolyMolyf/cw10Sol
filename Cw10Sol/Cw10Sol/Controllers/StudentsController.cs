using System;
using Cw10Sol.Models;
using Cw10Sol.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cw10Sol.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private IDbService dbService;

        public StudentsController(IDbService dbService)
        {
            this.dbService = dbService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            Console.Write("get");
            return Ok(dbService.retrieveStudents());
        }

        [HttpPost]
        [Route("modify")]
        public IActionResult ModifyStudent([FromBody] Student student)
        {
            Console.WriteLine("modified");
            dbService.changeStd(student);
            return Ok(200);
        }

        [HttpDelete]
        [Route("delete/{indexNumber}")]
        public IActionResult DeleteStudent([FromRoute] string indexNumber)
        {
            Console.WriteLine("Deleted");
            dbService.deleteStd(indexNumber);
            return Ok(200);
        }
    }
}