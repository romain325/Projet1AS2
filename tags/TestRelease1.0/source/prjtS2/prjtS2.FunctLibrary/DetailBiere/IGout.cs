using prjtS2.FunctLibrary.Ressources;
using System.Collections.Generic;

namespace prjtS2.FunctLibrary.DetailBiere
{
    /// <summary>
    /// Basic Interfaces needed to create a Gout
    /// </summary>
    public interface IGout
    {
        List<Arome> Aromes { get; }
        List<Cereale> Cereales { get; }
        List<Specificite> Specificites { get; }
        List<TypeBiere> Types { get; }
    }
}