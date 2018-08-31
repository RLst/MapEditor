using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor
{
    public class Tile
    {
        private Tileset tileset;            //The tileset this tile is using
        private Point tilesetIDX;           //The tileset index/coord this tile is referring to
        private Image image;              //The actual texture of the tile
        private Point mapIDX;				//Which map index/coord of the tile
		

		public Tile(Image texture)
		{
			this.image = texture;
		}
		public Tile(Image texture, Point mapIDX)
		{
			this.image = texture;
			this.mapIDX = mapIDX;
		}
		public Tile(Image texture, Point mapIDX, Point tilesetIDX)
		{
			this.image = texture;
			this.mapIDX = mapIDX;
			this.tilesetIDX = tilesetIDX;
		}

		public Image Image
		{
			get
			{
				return image;
				////Make sure tileset is not null
				//if (tileset != null) 
				//{
				//	//??? Gets the tile from the tileset using the index
				//	//Return the image
				//	return image;
				//}
				////Otherwise return null
				//return null;
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