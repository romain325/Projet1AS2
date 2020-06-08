using System;
using System.Collections.Generic;
using System.Text;

namespace prjtS2.FunctLibrary
{
    /// <summary>
    /// Class used to Instantiate a lesson, contains a name, description and an image
    /// </summary>
    public class Lecon : BaseElement
    {
        /// <summary>
        /// Default COnstructor taking Name, Description(who's the content) and an Image
        /// </summary>
        /// <param name="nom">Name of the lesson</param>
        /// <param name="description">Content of the lesson</param>
        /// <param name="Image">Image of the lesson</param>
        public Lecon(string nom, string description, string Image) : base(nom, description)
        {
            if(Image is null || Image == "") { Image = "data/logo.png"; }
            Images.Add(Image);
            Library.LECON.Add(nom.ToLower(), this);            
        }

    }
}
