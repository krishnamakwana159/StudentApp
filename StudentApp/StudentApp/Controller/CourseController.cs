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
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private CourseDomain courseDomain { get; set; }
        public CourseController()
        {
            this.courseDomain = new CourseDomain();
        }
        [HttpGet]
        public IActionResult Get()
        {
            var courses = this.courseDomain.GetCourse();
            return Ok(courses);
        }

        [HttpPost]
        public IActionResult Post(Course course)
        {
            this.courseDomain.CourseAdd(course);
            return Ok();
        }
    }
}