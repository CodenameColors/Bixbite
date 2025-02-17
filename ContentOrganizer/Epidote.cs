using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BixBite.ContentOrganizer
{
    /// <summary>
    /// This class is used to load, and deload Monogame Content into and out of the game. 
    /// The goal would be to just call this class method and pass it the object from the game scene.
    /// From there we would go through and figure out what we sent, and how to add or remove the 
    /// Content into memory.
    /// </summary>
    public class Epidote
    {
        private ContentManager _contentManager {  get; set; }
        private GraphicsDevice GraphicsDevice { get; set; }
        public Epidote(ContentManager content, GraphicsDevice graphicsDevice)
        {
            this._contentManager = content;
            this.GraphicsDevice = graphicsDevice;
        }

        /// <summary>
        /// Takes in a monogame object and scans it's data to find out what files we need to load into memory.
        /// </summary>
        /// <param name="monogameObject"></param>
        public void LoadObjectIntoContentMemory(object monogameObject)
        {
            // What are all the higher level objects that we use to load to scrren.
            // Example AnimationStateMachine, has a Spritesheet, and multiple layers, all these need to be loaded
            // in memory for later. So we would need to scan through the class structure and load the content for us.
            // So we can use it later for copies etc 
            // So long story short we need to do this for all the possible hgher monogmame classes.
        }

        public void UnloadObjectFromContentMemory(object monogameObject) 
        {

        }
    }
}
