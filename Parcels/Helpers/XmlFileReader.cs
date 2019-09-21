using Parcels.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Xml;

namespace Parcels.Helpers
{
    public static class XmlFileReader
    {
        public static List<Parcel> LoadXml()
        {
            try
            {
                var localFile = Path.Combine(
                Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), @"XmlFiles\Container_68465468.xml");
                XmlDocument doc = new XmlDocument();
                doc.Load(localFile);
                List<Parcel> listParcel = new List<Parcel>();

                foreach (XmlNode node in doc.DocumentElement)
                {
                    if (node.Name == "parcels")
                    {
                        foreach (XmlNode child in node.ChildNodes)
                        {
                            var parcel = new Parcel();

                            if (child.ChildNodes[2].Name == "Weight")
                                parcel.Weight = Convert.ToDecimal(child.ChildNodes[2].InnerText, new CultureInfo("en-US"));
                            if (child.ChildNodes[3].Name == "Value")
                                parcel.Value = Convert.ToDecimal(child.ChildNodes[3].InnerText, new CultureInfo("en-US"));

                            listParcel.Add(parcel);
                        }
                    }
                }
                return listParcel;
            }
            catch (Exception ex)
            {
                throw new Exception("Error on read XML file. " + ex.Message);
            }
        }
    }
}
