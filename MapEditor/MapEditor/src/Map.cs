using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor
{
    class Map
    {
		//private int rows;
		//public int Rows
		//{
		//	get
		//	{
		//		return rows;
		//	}
		//	set
		//	{
		//		rows = value;
		//	}
		//}
		//private int cols;
		//public int Cols
		//{
		//	get
		//	{
		//		return cols;
		//	}
		//	set
		//	{
		//		cols = value;
		//	}
		//}

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

		public int Rows { get; set; }
		public int Cols { get; set; }

		public int TileWidth { get; set; }
		public int TileHeight { get; set; }

		private int Width   //Return the total width of the map
		{
			get
			{
				return Cols * TileWidth;
			}
		}
		private int Height	//Return the total height of the map
		{
			get
			{
				return Rows * TileHeight;
			}

		}

		public Map(int rows, int cols, int tileWidth, int tileHeight)
		{
			//tiles = new List<Tile>(rows * cols);
			Rows = rows;
			Cols = cols;
			TileWidth = tileWidth;
			TileHeight = tileHeight;

			tiles = new Tile[Rows, Cols];

			//Init tiles
			//InitTiles();

			//Set all tiles to null
			Clear();
		}

		private void InitTiles()
		{
			for (int row = 0; row < Rows; row++)
			{
				for (int col = 0; col < Cols; col++)
				{
					tiles[row, col] = new Tile(null);	//Add in a bunch of blank tiles
				}
			}
		}

		//Nulls all elements
		public void Clear()
		{
			for (int row = 0; row < Rows; row++)
			{
				for (int col = 0; col < Cols; col++)
				{
					tiles[row, col] = null;
				}
			}
		}

		//Sets size of map and nullifies all elements
		public void Clear(int rows, int cols)
		{
			//Not finished
			for (int row = 0; row < rows; row++)
			{
				for (int col = 0; col < cols; col++)
				{
					tiles[row, col] = null;
				}
			}
		}

		//Find Tile from index
		public Tile FindTile(int row, int col)
		{
			//Return tile 
			if (tiles[row, col] != null)
			{
				return tiles[row, col];
			}

			//Go through all tiles and return tile with matching indexes
			//foreach (var t in tiles)
			//{
			//	if (t.MapIDX.X == row && t.MapIDX.Y == col)
			//	{
			//		return t;
			//	}
			//}

			//Return null if out of bounds or none found
			return null;
		}

		//Find Tile from coords
		public Tile FindTile(Point mapPos)
		{
			//Convert from map pos into map index
			var row = (mapPos.X / Width);
			var col = (mapPos.Y / Height);

			//Run through FindTile from index
			return FindTile(row, col);
		}
	}
}
