using prjtS2.FunctLibrary.DetailBiere;
using prjtS2.FunctLibrary.Ressources;
using System.Collections.Generic;

namespace prjtS2.FunctLibrary.Produit
{    
    /// <summary>
     /// Basic Biere Interface
     /// Also need to herit from Product
     /// </summary>
    public interface IBiere
    {
        List<Allergene> Allergenes { get; }
        Apparence Apparence { get; }
        float Degrees { get; }
        Gout Gout { get; }
        bool HasAlcool { get; }
        bool HasAll { get; }
        bool HasGluten { get; }
        bool HasLevure { get; }
        Localisation Loc { get; }
        float PrixMoyen { get; }
    }
}