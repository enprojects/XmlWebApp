using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XmlWebApp.DataLayer;
using XmlWebApp.DataLayer.dto;

namespace XmlWebApp.DataLayer
{
    public class Repository
    {

        private List<Student> students = null;
        public Repository()
        {
            students = XmlService.ReadXml<List<Student>>();
        }

        public IList<Student> GetAll()
        {
            return students;
        }

        public Student GetStudent(Func<Student, bool> func)
        {
            return students.Where(func).SingleOrDefault();
        }

        public void UpdateOrAddStudent(Student student)
        {
            int result = students.RemoveAll(x => x.Id == student.Id);
            students.Add(student);
            XmlService.WriteXml(students);

        }

        public void DeleteStudent(string id)
        {
            int result = students.RemoveAll(x => x.Id == id);
            if (result > 0)
            {
                XmlService.WriteXml(students);
            }
        }

    }
}