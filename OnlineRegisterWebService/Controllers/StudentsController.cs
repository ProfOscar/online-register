using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineRegisterClassLibrary;
using OnlineRegisterClassLibrary.Models;

namespace OnlineRegisterWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // GET: api/Students
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            DbTools dBTools = new DbTools();
            var data = dBTools.GetDataTable(@"SELECT * FROM Student s, Class c WHERE s.IdClass = c.Id;");
            List<Student> students = new List<Student>();
            foreach (DataRow item in data.Rows)
            {
                students.Add(ParseToStudent(item));
            }
            return students;
        }

        // GET: api/Students/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Student> Get(int id)
        {
            DbTools dBTools = new DbTools();
            var data = dBTools.GetDataTable(@"SELECT * FROM Student s, Class c WHERE s.IdClass = c.Id AND s.Id = "+id);
            if (data.Rows.Count > 0)
                return ParseToStudent(data.Rows[0]);
            else
                return NotFound();
        }

        private Student ParseToStudent(DataRow item)
        {
            Student s = new Student();
            s.Id = Convert.ToInt32(item[0]);
            s.FirstName = item["FirstName"].ToString();
            s.LastName = item["LastName"].ToString();
            Classroom c = new Classroom();
            c.Id = Convert.ToInt32(item["IdClass"]);
            c.Year = Convert.ToInt32(item["Year"]);
            c.Section = item["Section"].ToString();
            c.Specialization = item["Specialization"].ToString();
            s.Classroom = c;
            return s;
        }



        // POST: api/Students
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Students/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
