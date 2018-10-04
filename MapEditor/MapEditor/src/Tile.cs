using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace MapEditor
{
    [Serializable]
	public class Tile : ISerializable
    {
		//Tileset and index
		public Point MapIDX { get; set; }       //Where the tile is on the map (so far used for drag drop)
		public Image Image { get; }				//The actual texture of the tile

		public Tile(Tileset tileset, Point tilesetIDX)
		//Constructs a Tile that has no coord on any map
		{
			//MapIDX left unset
			
			//Grab the tile's texture from full tileset texture
			int col = tilesetIDX.X;
			int row = tilesetIDX.Y;
			int tilewidth = tileset.TileWidth;
			int tileheight = tileset.TileHeight;
			Bitmap bitmap = new Bitmap(tileset.Image);      //Convert image to bitmap so that it can be cropped

			Image = bitmap.Clone(
				new Rectangle(col * tilewidth, row * tileheight, tilewidth, tileheight),
				System.Drawing.Imaging.PixelFormat.DontCare) as Image;
		}

		//Serial constructor (Used to LOAD)
		public Tile(SerializationInfo info, StreamingContext context)
		{
			MapIDX = (Point)info.GetValue("mapIDX", typeof(Point));
			Image = (Image)info.GetValue("image", typeof(Image));
		}

		//Used to SAVE
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			///Serialize only the core components of the tile
			info.AddValue("mapIDX", MapIDX, typeof(Point));
			info.AddValue("image", Image, typeof(Image));
		}
	}
}