using System.Drawing;
using System.Runtime.Serialization;

namespace MapEditor
{
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
		//S
		public 

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			throw new System.NotImplementedException();
		}

		public void Load()
		{
			Image = Image.FromFile(FilePath);
		}
	}
}
