using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor
{
    public class Tileset
    {
		public Image Image { get; private set; } = null;
		public string FilePath { get; }
		public int Rows { get; set; }
		public int Cols { get; set; }
		public int TileWidth { get; set; }
		public int TileHeight { get; set; }

		/*
        public int TileWidth
		{
			get {
				return TileWidth;
			}
			set {
				TileWidth = value;
				//Also set the num of columns accordingly
				if (image != null)
				{
					Cols = image.Width / TileWidth;
				}
			}
		}
        public int TileHeight
		{
			get	{
				return TileHeight;
			}
			set {
				TileHeight = value;
				if (image != null)
				{
					Rows = image.Height / TileHeight;
				}
			}
		}
		public int Cols
        {
            get {
				//Columns = int(imagewidth / tilewidth)
				//Returns the number of columns based on the current tile width
				if (image != null)
					return Convert.ToUInt16(image.Width / TileWidth);
				else
					return 0;
            }
            set {
                //Must be positive
                if (value > 0)
                {
                    //Must be greater or equal to the image width
                    if (value >= image.Width)
                    {
                        Cols = value;
                        //Auto adjust the tile width based on what the user sets
                        TileWidth = image.Width / Cols;
                    }
                }
                //Otherwise error or do nothing?
                
            }
        }
        public int Rows
        {
            get
            {
				if (image != null)
					return Convert.ToUInt16(image.Height / TileHeight);
				else
					return 0;
            }
            set
            {
                if (value > 0)
                {
                    if (value >= image.Height)
                    {
                        Rows = value;
                        TileHeight = image.Height / Rows;
                    }
                }
                //Otherwise error or do nothing?
				
            }
        }
		*/

		public Tileset(string filePath, int rows = 10, int columns = 10)
		//Loads tileset from image and sets rows/cols
		{
			this.FilePath = filePath;
			Load();
			Cols = columns;
			Rows = rows;
		}

		public void Load()
		{
			Image = Image.FromFile(FilePath);
		}

    }
}
