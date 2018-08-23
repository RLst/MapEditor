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
        //private Image texture;              //The actual texture of the tile
        private Point mapIDX;				//Which map index/coord of the tile
		
        public Image Texture
		{
			get
			{
				//Make sure tileset is not null
					
					//Gets the tile from the tileset using the index

				//Otherwise return null
				return null;
			}
			set
			{
				//Should be set during startup when tileset and index are passed in?

				//Otherwise, derive a texture from passed in tileset and index/coord 
			}
		}
		public Point MapIDX { get; set; }



    }
}
