using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace MapEditor
{
    [Serializable]
	public class Tileset : ISerializable
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
			Load();
			Cols = columns;
			Rows = rows;
		}
        //Serial constructor (Used to LOAD)
        public Tileset(SerializationInfo info, StreamingContext context)
        {
            FilePath = (string)info.GetValue("filepath", typeof(string));
            Cols = (int)info.GetValue("cols", typeof(int));
            Rows = (int)info.GetValue("rows", typeof(int));
            TileWidth = (int)info.GetValue("tilewidth", typeof(int));
            TileHeight = (int)info.GetValue("tileheight", typeof(int));
        }

        //Used to SAVE
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
            info.AddValue("filepath", FilePath, typeof(string));
            info.AddValue("cols", Cols, typeof(int));
            info.AddValue("rows", Rows, typeof(int));
            info.AddValue("tilewidth", TileWidth, typeof(int));
			info.AddValue("tileheight", TileHeight, typeof(int));
		}

		public void Load()
		{
			Image = Image.FromFile(FilePath);
		}
	}
}
