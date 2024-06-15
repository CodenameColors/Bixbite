using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}
