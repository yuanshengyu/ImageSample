using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SampleMaker.Util
{

    public static class XmlHelper
    {

        /// <summary>
        /// XML序列化某一类型到指定的文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        public static void SerializeToXml<T>(string filePath, T obj)
        {
            try
            {
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath))
                {
                    //Create our own namespaces for the output
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    //Add an empty namespace and empty value
                    ns.Add("", "");

                    System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(T));
                    //Serialize the object with our own namespaces (notice the overload)
                    xs.Serialize(writer, obj, ns);
                }
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// XML序列化某一类型 并转byte[]
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        public static byte[] SerializeToByte<T>(T obj)
        {
            try
            {
                using (MemoryStream Stream = new MemoryStream())
                {
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
                    XmlSerializer xs = new XmlSerializer(typeof(T));
                    xs.Serialize(Stream, obj, ns);

                    Stream.Position = 0;
                    StreamReader sr = new StreamReader(Stream);
                    string str = sr.ReadToEnd();
                    return System.Text.Encoding.UTF8.GetBytes(str);//与大数据协商UTF8
                }
            }
            catch (Exception ex)
            {
                return new byte[0];
            }
        }

        /// <summary>
        /// XML序列化某一类型 并转string
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        public static string SerializeToString<T>(T obj)
        {
            try
            {
                using (MemoryStream Stream = new MemoryStream())
                {
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
                    XmlSerializer xs = new XmlSerializer(typeof(T));
                    xs.Serialize(Stream, obj, ns);

                    Stream.Position = 0;
                    StreamReader sr = new StreamReader(Stream);
                    return sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        /// <summary>
        /// 从某一XML文件反序列化到某一类型
        /// </summary>
        /// <param name="filePath">待反序列化的XML文件名称</param>
        /// <param name="type">反序列化出的</param>
        /// <returns></returns>
        public static T DeserializeFromXmlFile<T>(string filePath)
        {
            try
            {
                if (!System.IO.File.Exists(filePath))
                    throw new ArgumentNullException(filePath + " not Exists");

                using (System.IO.StreamReader reader = new System.IO.StreamReader(filePath))
                {
                    System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(T));
                    T ret = (T)xs.Deserialize(reader);
                    return ret;
                }
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }
        public static T DeserializeFromXmlStr<T>(string strXML)
        {
            try
            {
                if (strXML == null || strXML.Trim() == "") return default(T);
                using (StringReader reader = new StringReader(strXML))
                {
                    System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(T));
                    T ret = (T)xs.Deserialize(reader);
                    return ret;
                }
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

    }
}
