using prjtS2.FunctLibrary.Ressources;

namespace prjtS2.FunctLibrary.Produit
{
    /// <summary>
    /// Basic Brasserie Interface
    /// Also need to herit from Product
    /// </summary>
    public interface IBrasserie
    {
        Localisation Loc { get; }

        void AddNewBeer(Biere biere);
    }
}