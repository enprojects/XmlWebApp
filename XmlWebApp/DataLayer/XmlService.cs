using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace XmlWebApp.DataLayer
{
   
    public class XmlService  
    {

        const string Path = @"c:\XmlDataSource.xml";
        public static void WriteXml <T> (T entity)
        { 
            using (FileStream stream = new FileStream(@"c:\ZZ_Source\xml-data-source.xml", FileMode.Create))
            {
                
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(stream, entity);
            }
        }


 


        public static T ReadXml<T>()
        {
           using (FileStream  stream = new FileStream(@"c:\ZZ_Source\xml-data-source.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));               
                try
                {
                   return (T)serializer.Deserialize(stream);
                }
                catch (Exception ex)
                {
                    return default(T);                  
                }
                
            } 
           
        }



    }
}