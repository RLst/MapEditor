using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor
{
	[Serializable]
	public class Map : ISerializable
    {
		//This class can be created with nothing in it
		//private List<Tile> tiles;
		private Tile[,] tiles;
		public Tile[,] Tiles
		{
			get
			{
				return tiles;
			}
			set
			{
				tiles = value;
			}
		}

		public Bitmap Bitmap { get; set; }

		public int Cols { get; set; }
		public int Rows { get; set; }

		public int TileWidth { get; set; }
		public int TileHeight { get; set; }

		public int Width   //Return the total width of the map
		{
			get
			{
				return Cols * TileWidth;
			}
		}
		public int Height	//Return the total height of the map
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

		//Serial constructor
		public Map(SerializationInfo info, StreamingContext context)
		{
			Cols = (int)info.GetValue("cols", typeof(int));
			Rows = (int)info.GetValue("rows", typeof(int));
			TileWidth = (int)info.GetValue("tilewidth", typeof(int));
			TileHeight = (int)info.GetValue("tileheight", typeof(int));

			//Create new tile rectangle array and load
			tiles = new Tile[Cols, Rows];
			for (int col = 0; col < Cols; col++)
			{
				for (int row = 0; row < Rows; row++)
				{
					tiles[col, row] = (Tile)info.GetValue("tile:" + col + "," + row, typeof(Tile));
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
			tiles = new Tile[Cols, Rows];
		}

		//Nulls all elements
		public void Clear()
		{
			tiles = new Tile[Cols, Rows];
		}

		//Find Tile from coords
		public Tile FindTile(Point mapPos)
		{
			//Convert from map pos into map index
			var col = (mapPos.X / TileWidth);
			var row = (mapPos.Y / TileHeight);

			return tiles[col, row];
			////Run through FindTile from index
			//return FindTile(row, col);
		}

		////Find Tile from index
		//public Tile FindTile(int row, int col)
		//{
		//	//Return tile 
		//	if (tiles[row, col] != null)
		//	{
		//		return tiles[row, col];
		//	}
		//	//Go through all tiles and return tile with matching indexes
		//	//foreach (var t in tiles)
		//	//{
		//	//	if (t.MapIDX.X == row && t.MapIDX.Y == col)
		//	//	{
		//	//		return t;
		//	//	}
		//	//}
		//	//Return null if out of bounds or none found
		//	return null;
		//}

		public Point PosToIndex(int mapPosX, int mapPosY)
		{
			return new Point(mapPosX / TileWidth, mapPosY / TileHeight);
		}

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
					info.AddValue("tile:" + col + "," + row, tiles[col, row], typeof(Tile));
				}
			}
		}
	}
}
