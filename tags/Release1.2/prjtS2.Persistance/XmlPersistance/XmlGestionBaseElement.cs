using prjtS2.FunctLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace prjtS2.Persistance.XmlPersistance
{
    /// <summary>
    /// Xml GEstion of BaseElement, For Docs refer to IGestion
    /// </summary>
    /// <typeparam name="T">Derived class of BaseELement</typeparam>
    public abstract class XmlGestionBaseElement<T> : XmlGestion<T> where T : BaseElement
    {

        public abstract Dictionary<string, T> Lib { get; }
        public abstract string eltName { get; }

        public override void AddAllToFile()
        {
            XDocument Fichier = XDocument.Load("data/xml/DefaultXMLFile.xml");

            var Elts = Lib.Values.Select(elt => new XElement(eltName,
                                                    new XElement("nom", elt.Nom),
                                                    new XElement("description", elt.Description),
                                                    new XElement("image", elt.Images[0].ToString())
                                                    ));
            Fichier.Root.Add(Elts);
            SaveAllData(Fichier);

        }

        public override void AddOneToFile(T NewEntity)
        {
            var Fichier = LoadFile();

            Fichier.Root.Add(new XElement(eltName,
                                    new XElement("nom", NewEntity.Nom),
                                    new XElement("description", NewEntity.Description),
                                    new XElement("image", NewEntity.Images[0].ToString())
                                    ));

            SaveAllData(Fichier);
        }


        public override void RemoveOneFromFile(string entity)
        {
            var Fichier = LoadFile();

            var toDelete = from elt in Fichier.Descendants(eltName)
                           where elt.Element("nom").Value == entity
                           select elt;

            toDelete.ToList().ForEach(x => x.Remove());

            SaveAllData(Fichier);
        }

        public override void UpdateOneFromFile(string OldEntity, T NewEntity)
        {
            var Fichier = LoadFile();

            var items = from elt in Fichier.Descendants(eltName)
                        where elt.Element("nom").Value == OldEntity
                        select elt;

            foreach (var item in items)
            {
                Console.WriteLine(item.Element("nom"));
                item.Element("nom").Value = NewEntity.Nom;
                item.Element("description").Value = NewEntity.Description;
                item.Element("image").Value = NewEntity.Images[0].ToString();
            }

            SaveAllData(Fichier);
        }
    }
}
