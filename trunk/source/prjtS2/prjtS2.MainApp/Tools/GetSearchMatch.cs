using prjtS2.FunctLibrary;
using prjtS2.FunctLibrary.Produit;
using prjtS2.FunctLibrary.Ressources;
using prjtS2.FunctLibrary.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;

namespace prjtS2.MainApp.Tools
{
    /// <summary>
    /// Class used to get Match values on search
    /// </summary>
    public class GetSearchMatch : INotifyPropertyChanged
    {
        /// <summary>
        /// Manager Instance
        /// </summary>
        Managing.Manager Mng => Managing.Manager.Instance;

        public GetSearchMatch()
        {
            Mng.EventHub.BeerDicChanged += UpdateBeerDic;
            Mng.EventHub.BreweryDicChanged += UpdateBrewDic;
        }

        private Dictionary<string, FunctLibrary.Produit.Brasserie> LibBrass => Library.DICO_BRASSERIES;
        private Dictionary<string, FunctLibrary.Produit.Biere> LibBiere => Library.DICO_BIERES;


        /// <summary>
        /// Return Beer Search Result taking in count parameter gived
        /// </summary>
        /// <param name="search">Value searhed</param>
        /// <returns>Observable String Key Collection of Matching Brewery</returns>
        public ObservableCollection<string> GetBrasserieSearchResult(string search)
        {
            var RegEx = new Regex(@"\w*" + search?.ToLower() + @"\w*");

            return new ObservableCollection<string>( LibBrass.Keys.Where(f => RegEx.IsMatch(f)).ToList().OrderBy(f => f).ToList() );
        }

        /// <summary>
        /// Return Beer Search Result taking in count all parameters and User parameter if he is connected
        /// </summary>
        /// <param name="search">Search value</param>
        /// <param name="country">origin of the beer</param>
        /// <param name="couleur">color</param>
        /// <param name="arome">taste</param>
        /// <param name="spec">specificities</param>
        /// <param name="cereale">cereals</param>
        /// <param name="typeB">Type of beer</param>
        /// <param name="brasserie">brewery</param>
        /// <param name="degree">degrees</param>
        /// <param name="prix">Average Price</param>
        /// <param name="OrderBy">Type of OrderBy</param>
        /// <returns>Observable String collection containing all the matching key</returns>
        public ObservableCollection<string> GetBiereSearchResult(string search, object country, object couleur, object arome, object spec, object cereale, object typeB, object brasserie, byte degree, byte prix, OrderType OrderBy = OrderType.Nom)
        {
            var RegEx = new Regex(@"\w*" + search?.ToLower() + @"\w*");
            var dic = LibBiere.Where(f => RegEx.IsMatch(f.Key));

            if (Mng.CoHandl.IsConnected && !Mng.CoHandl.User.HasNone)
            {
                dic = dic.Where(f => f.Value.HasAlcool == !Mng.CoHandl.User.HasAlcool &&
                                     f.Value.HasGluten == !Mng.CoHandl.User.HasGluten &&
                                     f.Value.HasLevure == !Mng.CoHandl.User.HasLevure);
            }

            dic = dic.ToList();

            if((string)country != "Non Indiqué") { dic = dic.Where(f => f.Value.Loc.Value == (string)country); }

            if ((string)couleur != "Aucune Préference") { dic = dic.Where(f => f.Value.Apparence.couleur.Value == (string)couleur); }

            if ((string)arome != "Aucune Préference") { dic = dic.Where(f => FindItem<Arome>.ContainsValue((string)arome, f.Value.Gout.Aromes));  }

            if ((string)spec != "Aucune Préference") { dic = dic.Where(f => FindItem<Specificite>.ContainsValue((string)spec, f.Value.Gout.Specificites)); }

            if ((string)cereale != "Aucune Préference") { dic = dic.Where(f => FindItem<Cereale>.ContainsValue((string)arome, f.Value.Gout.Cereales)); }

            if ((string)typeB != "Aucune Préference") { dic = dic.Where(f => FindItem<TypeBiere>.ContainsValue((string)typeB, f.Value.Gout.Types)); }

            //MessageBox.Show(brasserie.ToString() ?? "testFailed");
            /*
            if(brasserie != null || (string)brasserie != "" || !(brasserie.ToString() is null)) 
            {
                dic = dic.Where(f => f.Value.Brasserie.Nom.ToLower() == brasserie.ToString());
            }
            */

            switch (prix)
            {
                case 0:
                    break;
                case 1:
                    dic = dic.Where(f => f.Value.PrixMoyen <= 2);
                    break;
                case 2:
                    dic = dic.Where(f => f.Value.PrixMoyen > 2 && f.Value.PrixMoyen <= 5);
                    break;
                case 3:
                    dic = dic.Where(f => f.Value.PrixMoyen > 5 && f.Value.PrixMoyen <= 10);
                    break;
                case 4:
                    dic = dic.Where(f => f.Value.PrixMoyen >= 10);
                    break;
            }


            switch (degree)
            {
                case 0:
                    break;
                case 1:
                    dic = dic.Where(f => f.Value.Degrees >= -0.5 && f.Value.Degrees <= 0.5);
                    break;
                case 2:
                    dic = dic.Where(f => f.Value.Degrees > 0 && f.Value.Degrees <= 4);
                    break;
                case 3:
                    dic = dic.Where(f => f.Value.Degrees >= 4 && f.Value.Degrees <= 8);
                    break;
                case 4:
                    dic = dic.Where(f => f.Value.Degrees >= 8);
                    break;
            }

            dic = OrderBy switch
            {
                OrderType.Nom => dic.OrderBy(f => f.Value.Nom),
                OrderType.DegréesPlus => dic.OrderByDescending(f => f.Value.Degrees),
                OrderType.DegréesMoins => dic.OrderBy(f => f.Value.Degrees),
                OrderType.PrixPlus => dic.OrderByDescending(f => f.Value.PrixMoyen),
                OrderType.PrixMoins => dic.OrderBy(f => f.Value.PrixMoyen),
                OrderType.NotePlus => dic.OrderByDescending(f => f.Value.Note),
                OrderType.NoteMoins => dic.OrderBy(f => f.Value.Note),
                OrderType.NbNotes => dic.OrderBy(f => f.Value.NbNotes),
                _ => dic.OrderBy(f => f.Value.Nom),
            };

            ObservableCollection<string> result = new ObservableCollection<string>();
            foreach (var f in dic)
            {
                result.Add(f.Key);
            }
            return result;
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Keep track of Brewery list updates
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateBrewDic(object sender, EventArgs e)
        {
            OnPropertyChanged(nameof(LibBrass));
        }

        /// <summary>
        /// Keep track of Beer list updates
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateBeerDic(object sender, EventArgs e)
        {
            OnPropertyChanged(nameof(LibBiere));
        }
    }

    /// <summary>
    /// all the different type of order allowed, as to have a Description added in way to have a clean display
    /// </summary>
    public enum OrderType
    {
        [Description("Ordre Alphabétique")]
        Nom,
        [Description("Trié par Degrées (+ vers -)")]
        DegréesPlus,
        [Description("Trié par Degrées (- vers +)")]
        DegréesMoins,
        [Description("Trié par Prix (+ vers -)")]
        PrixPlus,
        [Description("Trié par Prix (- vers +)")]
        PrixMoins,
        [Description("Les Mieux Notés")]
        NotePlus,
        [Description("Les Pires Notes")]
        NoteMoins,
        [Description("Les plus notés")]
        NbNotes
    }
}
