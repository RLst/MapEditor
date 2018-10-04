using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace MapEditor
{
    [Serializable]
	public class Map : ISerializable
    {
		//Map stores its own tiles including the tile's texture
		public Tile[,] Tiles { get; set; }

		//This class can be created with nothing in it
		//private Tile[,] tiles;
		//public Tile[,] Tiles		
		//{
		//	get
		//	{
		//		return tiles;
		//	}
		//	set
		//	{
		//		tiles = value;
		//	}
		//}

		public Bitmap Bitmap { get; set; }		//the full bitmap of the entire map used by DrawCanvas()

		//Map's specs
		public int Cols { get; set; }			
		public int Rows { get; set; }
		public int TileWidth { get; set; }
		public int TileHeight { get; set; }
		public int Width   //Total width of the map
		{
			get
			{
				return Cols * TileWidth;
			}
		}
		public int Height	//Total height of the map
		{
			get
			{
				return Rows * TileHeight;
			}

		}

		//Default constructor
		public Map(int cols, int rows, int tileWidth, int tileHeight)
		{
			NewMap(cols, rows, tileWidth, tileHeight);
		}

		//Serial constructor (USED TO LOAD)
		public Map(SerializationInfo info, StreamingContext context)
		{
			Cols = (int)info.GetValue("cols", typeof(int));
			Rows = (int)info.GetValue("rows", typeof(int));
			TileWidth = (int)info.GetValue("tilewidth", typeof(int));
			TileHeight = (int)info.GetValue("tileheight", typeof(int));

			//Create the actual map
			NewMap(Cols, Rows, TileWidth, TileHeight);
			Tiles = new Tile[Cols, Rows];
			for (int col = 0; col < Cols; col++)
			{
				for (int row = 0; row < Rows; row++)
				{
					Tiles[col, row] = (Tile)info.GetValue("tile:" + col + "," + row, typeof(Tile));
				}
			}
		}

		//USED TO SAVE
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			//Use the addvalue method to specify serialized values
			info.AddValue("cols", Cols, typeof(int));
			info.AddValue("rows", Rows, typeof(int));
			info.AddValue("tilewidth", TileWidth, typeof(int));
			info.AddValue("tileheight", TileHeight, typeof(int));
			for (int col = 0; col < Cols; col++)
			{
				for (int row = 0; row < Rows; row++)
				{
					info.AddValue("tile:" + col + "," + row, Tiles[col, row], typeof(Tile));
				}
			}
		}

		public void NewMap(int cols, int rows, int tileWidth, int tileHeight)
		{
			//Set new properties
			Cols = cols;
			Rows = rows;
			TileWidth = tileWidth;
			TileHeight = tileHeight;

			//Set new cleared array
			Tiles = new Tile[Cols, Rows];
		}

		//Nulls all elements
		public void Clear()
		{
			Tiles = new Tile[Cols, Rows];
		}

		//Find Tile from map coords
		public Tile FindTile(Point mapPos)
		{
			//Convert from map pos into map index
			var col = (mapPos.X / TileWidth);
			var row = (mapPos.Y / TileHeight);

			//If out of bounds return null
			if (col >= 0 && col < Tiles.GetLength(0))
			{
				if (row >= 0 && row < Tiles.GetLength(1))
				{
					return Tiles[col, row];
				}
			}
			return null;
		}

		//Canvas position to Map Index
		public Point PosToIndex(int mapPosX, int mapPosY)
		{
			return new Point(mapPosX / TileWidth, mapPosY / TileHeight);
		}

	}
}
