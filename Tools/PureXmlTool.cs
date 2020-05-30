using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace PureGame
{
    public class PureXmlTool
    {
        /// <summary>
        /// aaaaaaaaaaaa
        /// </summary>
        public static string Serializer<T>(T val) {
            StringWriter sw = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(sw, val);
            sw.Close();
            return sw.ToString() ;
        }
        public static T Deserializer<T>(string val)
        {
            StringReader reader = new StringReader(val);
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            T target = (T)serializer.Deserialize(reader);
            return target;
        }
    }
}
