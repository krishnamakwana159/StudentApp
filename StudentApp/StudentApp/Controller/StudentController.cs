using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentApp.Domain;
using StudentApp.Models;

namespace StudentApp.Controller
{
    [ApiController]
    [Route("api/[controller]")]    
    public class StudentController : ControllerBase
    {
        private StudentDomain studentDomain { get; set; }

        public StudentController()
        {
            this.studentDomain = new StudentDomain();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var students = this.studentDomain.GetStudent();
            return Ok(students);
        }

        [HttpPost]
        public IActionResult Post(Student student)
        {
            this.studentDomain.StudentAdd(student);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Student student)
        {
            this.studentDomain.StudentUpdate(student);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            this.studentDomain.StudentDelete(id);
            return Ok();
        }
    }
}