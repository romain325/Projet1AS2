using System;
using System.Collections.Generic;
using System.Text;

namespace prjtS2.MainApp.Managing
{
    /// <summary>
    /// Class used as a container of EventHandler for the whole application
    /// Every pages can adivse the other of a modficiation and/or listen to them
    /// </summary>
    public class EventHub
    {
        public EventHub()
        {
        }

        /// <summary>
        /// Beer Dicitonary Change event
        /// </summary>
        public EventHandler<EventArgs> BeerDicChanged;
        /// <summary>
        /// Beer Dicitonary Change event trigger
        /// </summary>
        public virtual void OnBeerDicChanged(object sender)
        {
            BeerDicChanged?.Invoke(sender, EventArgs.Empty);
        }


        /// <summary>
        /// Brewery Dicitonary Change event 
        /// </summary>
        public EventHandler<EventArgs> BreweryDicChanged;
        /// <summary>
        /// Brewery Dicitonary Change event trigger
        /// </summary>
        public virtual void OnBreweryDicChanged(object sender)
        {
            BreweryDicChanged?.Invoke(sender, EventArgs.Empty);
        }


        /// <summary>
        /// Lesoon Dicitonary Change event 
        /// </summary>
        public EventHandler<EventArgs> LessonDicChanged;
        /// <summary>
        /// lesson Dicitonary Change event trigger
        /// </summary>
        public virtual void OnLessonDicChanged(object sender)
        {
            LessonDicChanged?.Invoke(sender, EventArgs.Empty);
        }

        /// <summary>
        /// Ressource Dicitonary Change event 
        /// </summary>
        public EventHandler<EventArgs> RessourceDicsChanged;
        /// <summary>
        /// Ressource Dicitonary Change event trigger
        /// </summary>
        public virtual void OnRessourceDicsChanged(object sender)
        {
            RessourceDicsChanged?.Invoke(sender, EventArgs.Empty);
        }

        /// <summary>
        /// Beer Propistion Dicitonary Change event
        /// </summary>
        public EventHandler<EventArgs> PropBeerDicChanged;
        /// <summary>
        /// Beer Propistion Dicitonary Change event trigger
        /// </summary>
        public virtual void OnPropBeerDicChanged(object sender)
        {
            PropBeerDicChanged?.Invoke(sender, EventArgs.Empty);
        }


        /// <summary>
        /// Brewery Propostion Dicitonary Change event
        /// </summary>
        public EventHandler<EventArgs> PropBrewDicChanged;
        /// <summary>
        /// Brewery Propostion Dicitonary Change event trigger
        /// </summary>
        public virtual void OnPropBrewDicChanged(object sender)
        {
            PropBrewDicChanged?.Invoke(sender, EventArgs.Empty);
        }



        /// <summary>
        /// Brewery Propostion Dicitonary Change event
        /// </summary>
        public EventHandler<EventArgs> UpdateDecouverteProp;
        /// <summary>
        /// Brewery Propostion Dicitonary Change event trigger
        /// </summary>
        public virtual void OnUpdateDecouverteProp(object sender)
        {
            UpdateDecouverteProp?.Invoke(sender, EventArgs.Empty);
        }
    }
}
