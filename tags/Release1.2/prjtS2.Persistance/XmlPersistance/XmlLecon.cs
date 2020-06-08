using prjtS2.FunctLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace prjtS2.Persistance.XmlPersistance
{
    /// <summary>
    /// Xml Save of Lesson, For docs,refer to IGestion
    /// </summary>
    public class XmlLecon : XmlGestionBaseElement<Lecon>
    {

        public override Dictionary<string, Lecon> Lib  => Library.LECON; 

        public override string eltName => "lecon";

        public override void GetDicoAllFromFile()
        {
            var leconFichier = LoadFile();
            Lib.Clear();

            foreach (XElement el in leconFichier.Descendants("lecon"))
            {
                    new Lecon(el.Element("nom").Value, el.Element("description").Value, el.Element("image").Value);
            }

        }

    }
}
