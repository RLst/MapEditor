using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace MapEditor
{
	[Serializable]
	public class Tileset /*: ISerializable*/
		//A tileset is only used to create tiles and then discarded from memory ie:
		//1. User opens tileset loader dialog
		//2. Loads in a tileset image
		//3. Sets the tile width/height settings etc
		//4. Presses ok, the tileset's image is then used to create tiles
		//5. Tileset is essentially discarded at this point
    {
		public Image Image { get; private set; } = null;
		public string FilePath { get; }
		public int Cols { get; set; }
		public int Rows { get; set; }
		public int TileWidth { get; set; }
		public int TileHeight { get; set; }

		//Loads tileset from image and sets rows/cols
		public Tileset(string filePath, int columns = 10, int rows = 10)
		{
			FilePath = filePath;
			Image = Image.FromFile(filePath);
			Cols = columns;
			Rows = rows;
		}
		//Serial constructor(Used to LOAD)
		public Tileset(SerializationInfo info, StreamingContext context)
		{
			FilePath = (string)info.GetValue("filepath", typeof(string));
			//LoadImage(FilePath);
			Cols = (int)info.GetValue("cols", typeof(int));
			Rows = (int)info.GetValue("rows", typeof(int));
			TileWidth = (int)info.GetValue("tilewidth", typeof(int));
			TileHeight = (int)info.GetValue("tileheight", typeof(int));
		}

		//Used to SAVE
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("filepath", FilePath, typeof(string));
			//Not required to save this.Image as it is derived from FilePath
			info.AddValue("cols", Cols, typeof(int));
			info.AddValue("rows", Rows, typeof(int));
			info.AddValue("tilewidth", TileWidth, typeof(int));
			info.AddValue("tileheight", TileHeight, typeof(int));
		}
	}
}
