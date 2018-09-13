using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor
{
	[Serializable]
	public class Tile : ISerializable
    {
		//Tileset and index
        public Tileset Tileset { get; }
		public Point TilesetIDX { get; }
		public Point MapIDX { get; set; }       //The tile's map index
		public Image Image { get; }     //The actual texture of the tile

		public Tile(Tileset tileset, Point tilesetIDX)
		{
			//Set the tileset
			Tileset = tileset;

			//Grab tile from full tileset texture
			int col = tilesetIDX.X;
			int row = tilesetIDX.Y;
			int tilewidth = tileset.TileWidth;
			int tileheight = tileset.TileHeight;
			Bitmap bitmap = new Bitmap(tileset.Image);      //Convert image to bitmap so that it can be cropped
			Image = bitmap.Clone(
				new Rectangle(col * tilewidth, row * tileheight, tilewidth, tileheight),
				System.Drawing.Imaging.PixelFormat.DontCare) as Image;
		}
		//Use to load in from a file
		public Tile(SerializationInfo info, StreamingContext context)
		{
			Tileset = (Tileset)info.GetValue("tileset", typeof(Tileset));
			TilesetIDX = (Point)info.GetValue("tilesetIDX", typeof(Point));
			MapIDX = (Point)info.GetValue("mapIDX", typeof(Point));

			//Grab single tile from tileset
			int col = TilesetIDX.X;
			int row = TilesetIDX.Y;
			int tilewidth = Tileset.TileWidth;
			int tileheight = Tileset.TileHeight;
			Bitmap bitmap = new Bitmap(Tileset.Image);
			Image = bitmap.Clone(new Rectangle(row * tilewidth, col * tileheight, tilewidth, tileheight),
				System.Drawing.Imaging.PixelFormat.DontCare) as Image;
		}

		//Used to saved to a file
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("tileset", Tileset, typeof(Tileset));
			info.AddValue("tilesetIDX", TilesetIDX, typeof(Point));
			info.AddValue("mapIDX", MapIDX, typeof(Point));
			//info.AddValue("image", Image, typeof(Image));
		}
	}
}