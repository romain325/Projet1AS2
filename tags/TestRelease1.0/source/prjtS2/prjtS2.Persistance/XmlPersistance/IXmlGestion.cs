using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Xml.Linq;

namespace prjtS2.Persistance.XmlPersistance
{
    /// <summary>
    /// Gestion Using the XML methode
    /// </summary>
    /// <typeparam name="T">class to save</typeparam>
    public interface IXmlGestion<T> : IGestion<T, XDocument> where T : class
    {
    }
}
