using prjtS2.Persistance.JsonPersistance.Profil;

namespace prjtS2.Persistance
{
    /// <summary>
    /// DbDataManager letting us choose or Strategy
    /// F:\Prog\prjtS2\trunk\source\prjtS2\prjtS2.Persistance\DataManager\DbDataManager.cs
    /// </summary>
    public class DbDataManager
    {
        public DbDataManager()
        {
        }

        ///=========================================JSON============================================///
        public RessourceDataManager RessourceDataMng { get; } = new RessourceDataManager();
        public ProduitDataManager ProduitDataMng { get; } = new ProduitDataManager();
        public JsonProfil ProfilData { get; } = new JsonProfil();
        
        



        ///=========================================XML============================================///
        public XmlPersistance.XmlLecon LeconData { get; } = new XmlPersistance.XmlLecon();

    }
}
