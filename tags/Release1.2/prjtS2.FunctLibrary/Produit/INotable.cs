using System;
using System.Collections.Generic;
using System.Text;

namespace prjtS2.FunctLibrary
{
    /// <summary>
    /// Interfaces defining values needed to Implement a Notation system
    /// </summary>
    public interface INotable
    {
        /// <summary>
        /// Keep in track the number of notes that have been submitted
        /// </summary>
        int NbNotes { get; set; }
        
        /// <summary>
        /// A total of all the notes given
        /// </summary>
        long NoteTotal { get; set; }

        /// <summary>
        /// Return the calculate value of the average mark
        /// Add a new mark  to the total and add 1 to the total number
        /// </summary>
        public int Note { get; set; }

    }
}
