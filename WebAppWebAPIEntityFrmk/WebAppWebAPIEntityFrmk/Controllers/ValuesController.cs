using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAppWebAPIEntityFrmk.Models;

namespace WebAppWebAPIEntityFrmk.Controllers
{
    public class ValuesController : ApiController
    {
        // This Api for insert one student object into db
        [HttpGet]
        //It is attribute routing method
        [Route("values/Addstudent")]
        public IHttpActionResult AddStudent([FromUri] Student s)
        {
            using (StudentDB dbContext = new StudentDB())
            {
                dbContext.students.Add(s);
                dbContext.SaveChanges();
                return Ok("Student Information Added Successfully !!");
            }
        } 

        // This Api for get all Student list
        [HttpGet]
        [Route("values/getAllStudent")]
        public IHttpActionResult GetAllStudent([FromUri] Student s)
        {
            using (StudentDB dbContext = new StudentDB())
            {
               

               var a= dbContext.students.ToList();
                dbContext.SaveChanges();
                return Ok(a);
            }
        }

        // This Api for get particular Student Information
        [HttpGet]
        [Route("values/getStudent")]
        public IHttpActionResult GetStudent(int id)
        {
            using (StudentDB dbContext = new StudentDB())
            {
               
             //This is the linq query which will check fetch data from student table if given id is matched.
             // we use lambda expression for checking id is match or not
             //FirstOrDefault is used bcoz if it fail(mean id is not their then it return null instead of exception
             //If we use only First then it give error if it fails

                var student= dbContext.students.Where(obj => obj.id == id).FirstOrDefault();
             
                dbContext.SaveChanges();
                return Ok(student);
            }
        }

        // This Api for get all Student list
        [HttpGet]
        [Route("values/UpdateStudent")]
        public IHttpActionResult UpdateStudent(int id, String first_name)
        {
            using (StudentDB dbContext = new StudentDB())
            {
               
                //This is the linq query which will check fetch data from student table if given id is matched.
                // we use lambda expression for checking id is match or not
                //FirstOrDefault is used bcoz if it fail(mean id is not their then it return null instead of exception
                //If we use only First then it give error if it fails

                var studentRecord = dbContext.students.Where(obj => obj.id == id).FirstOrDefault();
                studentRecord.first_name = first_name;
              
                dbContext.SaveChanges();
                return Ok("Student record updated successfully !!");
            }
        }

        //This api is For Deleting student info with using its Id
        [HttpGet]
        [Route("values/Removestudent")]
        public IHttpActionResult RemoveStudent([FromUri] Student s)
        {
         
            using (StudentDB dbContext = new StudentDB())
            {
                // 1st way to delete data using LINQ query
                var student = dbContext.students
                   .Where(a => a.id == s.id)
                   .FirstOrDefault();

                // 2nd way to assign id to var type variable
                //var student = new Student { id = s.id };

                dbContext.Entry(student).State = EntityState.Deleted;

                dbContext.SaveChanges();
                return Ok("Student Removed Successfully");
            }

        }


    }
}
