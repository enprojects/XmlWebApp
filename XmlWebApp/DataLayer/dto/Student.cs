using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace XmlWebApp.DataLayer.dto
{
 
    public class StudentsCollection
    {
       
        public Student [] Students { get; set; }
    }

 
    public class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}