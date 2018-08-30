using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor
{
    class Tile
    {
        private Tileset tileset;            //The tileset this tile is using
        private Point tilesetIDX;           //The tileset index/coord this tile is referring to
        private Image texture;              //The actual texture of the tile
        private Point mapIDX;				//Which map index/coord of the tile
		

		public Tile(Image texture)
		{
			this.texture = texture;
		}
		public Tile(Image texture, Point mapIDX)
		{
			this.texture = texture;
			this.mapIDX = mapIDX;
		}
		public Tile(Image texture, Point mapIDX, Point tilesetIDX)
		{
			this.texture = texture;
			this.mapIDX = mapIDX;
			this.tilesetIDX = tilesetIDX;
		}

		public Image Texture
		{
			get
			{
				//Make sure tileset is not null
				if (tileset != null) 
				{
					//??? Gets the tile from the tileset using the index

					//Return the image
					return texture;
				}
				//Otherwise return null
				return null;
			}
			set
			{
				//Should be set during startup when tileset and index are passed in?

				//Otherwise, derive a texture from passed in tileset and index/coord 
			}
		}

		public Point MapIDX 
		{
			get {
				return mapIDX;
			}
			set {
				mapIDX = value;
			}
		}



    }
}