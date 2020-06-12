namespace WebAppWebAPIEntityFrmk
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using WebAppWebAPIEntityFrmk.Models;

    public class StudentDB : DbContext
    {
        
        public StudentDB()
            : base("name=StudentDB")
        {
        }

        public virtual DbSet<Student> students { get; set; }
    }

}