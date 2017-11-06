using HW5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HW5.DAL
{
    public class FormContext : DbContext
    {
        public FormContext() : base("name=OurDBContext")
        { }

        public virtual DbSet<Form> Forms { get; set; }
    }
}
