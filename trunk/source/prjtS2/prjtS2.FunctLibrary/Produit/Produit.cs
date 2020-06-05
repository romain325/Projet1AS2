using prjtS2.FunctLibrary.Ressources;
using System;
using System.Collections.Generic;
using System.Text;

namespace prjtS2.FunctLibrary.Produit
{
    /// <summary>
    /// Abstract class used to implement a Notation system, Derived from BaseElement
    /// </summary>
    public abstract class Produit : BaseElement, INotable
    {
        /// <summary>
        /// Default constructor Same as BaseElement adding Notation system with default values
        /// </summary>
        /// <param name="nom">Name</param>
        /// <param name="description">Description</param>
        /// <param name="nbNotes">Numbers of notes</param>
        /// <param name="noteTotal">Total of Notes SUm</param>
        public Produit(string nom, string description, int nbNotes = 1, long noteTotal = 50 ) : base(nom, description)
        {
            NbNotes = nbNotes;
            NoteTotal = noteTotal;
        }

        /// <summary>
        /// Refer to Interface
        /// </summary>
        public int NbNotes { get; set; }

        /// <summary>
        /// Refer to Interface
        /// </summary>
        public long NoteTotal { get; set; }

        /// <summary>
        /// Refer to Interface
        /// </summary>
        public int Note
        {
            get => (int)(NoteTotal / (long)NbNotes);
            set
            {
                if(value < 100 && value > 0)
                {
                    NbNotes++;
                    NoteTotal += value;
                    OnPropertyChanged();
                }
                else
                {
                    throw new ArgumentException("La valeur doit être entre 0 et 100 !");
                }
            }
        }
    }
}
