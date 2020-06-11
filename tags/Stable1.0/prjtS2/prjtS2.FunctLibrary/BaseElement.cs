using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace prjtS2.FunctLibrary
{
    /// <summary>
    /// Base Element containing value such as a name and a description and a set of images
    /// </summary>
    public abstract class BaseElement : INotifyPropertyChanged
    {
        private string _Nom;
        /// <summary>
        /// Name of the Element
        /// </summary>
        public string Nom
        {
            get => _Nom;
            set
            {
                if(value is null || value == "") { throw new ArgumentException("The name can't be null!"); }
                if(value.Length > 40)
                {
                    throw new ArgumentException("The given name is too long (Max 35Char)");
                }
                _Nom = value;
                OnPropertyChanged(nameof(Nom));
            }
        }


        private string desc;
        /// <summary>
        /// Description of the product
        /// </summary>
        public string Description
        {
            get => desc;
            set
            {
                if(value is null || value == "") { throw new ArgumentException("The description can't be null!"); }
                desc = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        /// <summary>
        /// All the links to the differents Images
        /// </summary>
        public List<string> Images { get; set; } = new List<string>();

        /// <summary>
        /// Default constructor for all Product instance
        /// </summary>
        /// <param name="nom">Name</param>
        /// <param name="description">Quick description</param>
        public BaseElement(string nom, string description)
        {
            this.Description = description;
            this.Nom = nom;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override bool Equals(object obj)
        {
            return obj is BaseElement element && Nom.ToLower() == element.Nom.ToLower();
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Nom);
        }
    }
}
