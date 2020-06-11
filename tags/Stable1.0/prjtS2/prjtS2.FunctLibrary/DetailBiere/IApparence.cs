using prjtS2.FunctLibrary.Ressources;
using System.Collections.Generic;

namespace prjtS2.FunctLibrary.DetailBiere
{
    /// <summary>
    /// Basic interfaces need to create an Apparence
    /// </summary>
    public interface IApparence
    {
        Couleur couleur { get; }
        List<Style> Styles { get; }
    }
}