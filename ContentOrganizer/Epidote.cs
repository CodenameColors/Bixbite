using BixBite.Rendering.Animation;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
		public enum EContentType
		{
			NONE = 0,
			Texture2D = 1,
		}

		public struct ContentData
		{

			public EContentType contentType;
			public object ContentObject;

			public ContentData(EContentType contentType, object contentObject)
			{
				this.contentType = contentType;
				this.ContentObject = contentObject;	
			}

		}

		private Dictionary<String, ContentData> CachedContent = new Dictionary<string, ContentData>();
		private ContentManager _contentManager { get; set; }
		private GraphicsDevice GraphicsDevice { get; set; }


		public static Epidote Instance(ContentManager content, GraphicsDevice graphicsDevice)
		{
			if (_instance == null)
			{
				lock (_locker)
				{
					if (_instance == null) // Double-checked locking.
					{
						_instance = new Epidote(content, graphicsDevice);
					}
				}
			}

			return _instance;
		}

		private static Epidote _instance;
		private static readonly object _locker = new object();


		/// <summary>
		/// This constructs the singleton, and allows the class to use the graphics device, and content 
		/// to load and unload data to and from memory.
		/// </summary>
		/// <param name="content"></param>
		/// <param name="graphicsDevice"></param>
		public Epidote(ContentManager content, GraphicsDevice graphicsDevice)
		{
			this._contentManager = content;
			this.GraphicsDevice = graphicsDevice;
		}

		public void LoadMonoGameObjectContent(object monogameObject)
		{
			// Check to make sure the object is valid
			switch(monogameObject)
			{
				case AnimationStateMachine:
					LoadAnimationStateMachine((AnimationStateMachine)monogameObject);
					break;
				default:
					throw new NotImplementedException();
					break;
			}
		}

		private void LoadAnimationStateMachine(AnimationStateMachine animStateMachine)
		{
			if(animStateMachine != null)
			{
				// An animations statemachine has a lot of content to it.
				// It has many different animation states.
				// Each animation state has at least 1 layer.
				// Each layer has at least 1 Frame.
				// Each frame has at least one Texture2D image.
				
				foreach(KeyValuePair<String, AnimationState> animState in animStateMachine.States)
				{
					foreach(AnimationLayer animLayer in animState.Value.AnimationLayers)
					{
						foreach(SpriteSheet sheet in animLayer.ReferenceSpriteSheets)
						{
							// Now that we have found the spritesheet used to render frames, we need to load this
							// into Content memory. using the paths. Make sure to remove the "content" and ".xnb"
							String contentPath = sheet.SpriteSheetPath.Replace("Content\\\\", "");
							contentPath = contentPath.Replace(".xnb", "");

							Texture2D textureData = this._contentManager.Load<Texture2D>(contentPath);
							sheet.LoadSpritesheetTexture2D(textureData);
							if(!CachedContent.ContainsKey(sheet.SpriteSheetPath))
							{
								CachedContent.Add(sheet.SpriteSheetPath, new ContentData(EContentType.Texture2D, textureData));
							}
						}
					}
				}
			}
		}

		public void UnloadMonoGameObjectContent(object monogameObject)
		{

		}

	}
}
