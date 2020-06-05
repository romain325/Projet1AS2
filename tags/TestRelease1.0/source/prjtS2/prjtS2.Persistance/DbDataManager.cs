using prjtS2.FunctLibrary.Compte;
using prjtS2.FunctLibrary.Ressources;
using prjtS2.Persistance.JsonPersistance.Profil;
using System;
using System.Collections.Generic;
using System.Text;

namespace prjtS2.Persistance
{
    /// <summary>
    /// DbDataManager letting us choose or Strategy
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
