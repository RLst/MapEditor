using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace MapEditor
{
    [Serializable]
	public class Tile : ISerializable
    {
		//Tileset and index
        //public Tileset Tileset { get; }			//The tileset this tile is referencing offk
		//public Point TilesetIDX { get; }		//Where the tile is on the tileset
		public Point MapIDX { get; set; }       //Where the tile is on the map
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

			///Derive [Image] from the other fields
			//Grab single tile image from tileset
			//int col = TilesetIDX.X;
			//int row = TilesetIDX.Y;
			//int tilewidth = Tileset.TileWidth;
			//int tileheight = Tileset.TileHeight;
			//Bitmap bitmap = new Bitmap(Tileset.Image);
			//Image = bitmap.Clone(new Rectangle(row * tilewidth, col * tileheight, tilewidth, tileheight),
			//System.Drawing.Imaging.PixelFormat.DontCare) as Image;
		}

		//Used to SAVE
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			///Serialize only the core components of the tile
			info.AddValue("mapIDX", MapIDX, typeof(Point));
			info.AddValue("image", Image, typeof(Image));
			//Don't need tileset or tilsetIDX as they would've been discarded by now
		}
	}
}