using prjtS2.FunctLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace prjtS2.Persistance.XmlPersistance
{
    /// <summary>
    /// Class using the Xml Saving Method, For Doc --> refer to IGestion interface
    /// </summary>
    /// <typeparam name="T">class to save</typeparam>
    public abstract class XmlGestion<T> : IXmlGestion<T> where T : class
    {
        public XmlGestion()
        {
            this.GetDicoAllFromFile();
        }

        public string FileName => "data/xml/" + this.GetType().Name + ".xml";

        public abstract void AddAllToFile();

        public abstract void AddOneToFile(T NewEntity);

        public abstract void GetDicoAllFromFile();

        public XDocument LoadFile()
        {
            return XDocument.Load(FileName);
        }

        public abstract void RemoveOneFromFile(string entity);
        public void SaveAllData(XDocument document)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            using (TextWriter tw = File.CreateText(FileName))
            {
                using (XmlWriter writer = XmlWriter.Create(tw, settings))
                {
                    document.Save(writer);
                }
            }
        }

        public abstract void UpdateOneFromFile(string OldEntity, T NewEntity);
    }
}
