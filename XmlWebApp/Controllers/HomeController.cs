using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XmlWebApp.DataLayer;
using XmlWebApp.DataLayer.dto;

namespace XmlWebApp.Controllers
{

    public static class Helper
    {
        public static IEnumerable<TSource> OrderByMe<TSource, TKey>(
IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            var items = source.ToArray();
            var keys = items.Select(keySelector).ToArray();
            Array.Sort(keys, items);
            foreach (var item in items)
            {
                yield return item;
            }
        }
    }
    public class HomeController : Controller
    {
        private int pageSize = 2;

        // GET: Home
        public ActionResult Index()
        {
            #region MyRegion
            //var students = new List<Student>() {
            //    new Student() {  Id="1", LastName ="tetH", Name="NtetH"},
            //    new Student() {  Id="2", LastName ="tetsG", Name="ntetsG"},
            //     new Student() {  Id="3", LastName ="tetsF", Name="test222"},
            //      new Student() {  Id="4", LastName ="tetsE", Name="test222"},
            //       new Student() {  Id="5", LastName ="tetsD", Name="test222"},
            //        new Student() {  Id="6", LastName ="tetsC", Name="abcft"},
            //         new Student() {  Id="7", LastName ="tetsB", Name="test222"},
            //         new Student() {  Id="8", LastName ="tetsA", Name="tehh"},
            //};

            //var xmlSrv = new XmlService<List<Student>>();

            //xmlSrv.WriteXml(students);
            #endregion

            return View();
        }

        [HttpPost]
        public void Test(Student std)
        {

        }


        [HttpGet]
        public JsonResult GetAllStudent(string colunName = "Name", int pageNumber = 1)
        {

            Repository rp = new Repository();
            var students = rp.GetAll();

            var numbersOfRecord = students.Count();
            var numOfPage = (numbersOfRecord / pageSize) + (numbersOfRecord % pageSize == 0 ? 0 : 1);

            var result = students.Skip((pageNumber - 1) * pageSize)
                       .Take(pageSize)
                       .OrderBy(s => s.GetType()
                                      .GetProperty(colunName)
                                      .GetValue(s, null))
                                      .Select(s => s).ToList();



            return Json(new
            {
                students = result,
                numOfPage = numOfPage
            }, JsonRequestBehavior.AllowGet);
        }
    }
}