using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor
{
    class Tileset
    {

		//Properties
		private string filePath;
		public string FilePath
		{
			get {
				return filePath;
			}
			set {
				filePath = value;
			}
		}

        private Image image = null;
		public Image Image
		{
			get {
				return image;
			}
			set {
				//Validity check?
				image = value;
			}
		}
		
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
					Columns = image.Size.Width / TileWidth;
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
					Rows = image.Size.Height / TileHeight;
				}
			}
		}
		public int Columns
        {
            get {
				//Columns = int(imagewidth / tilewidth)
				//Returns the number of columns based on the current tile width
				if (image != null)
					return Convert.ToUInt16(image.Size.Width / TileWidth);
				else
					return 0;
            }
            set {
                //Must be positive
                if (value > 0)
                {
                    //Must be greater or equal to the image width
                    if (value >= image.Size.Width)
                    {
                        Columns = value;
                        //Auto adjust the tile width based on what the user sets
                        TileWidth = image.Size.Width / Columns;
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
					return Convert.ToUInt16(image.Size.Height / TileHeight);
				else
					return 0;
            }
            set
            {
                if (value > 0)
                {
                    if (value >= image.Size.Height)
                    {
                        Rows = value;
                        TileHeight = image.Size.Height / Rows;
                    }
                }
                //Otherwise error or do nothing?
				
            }
        }


		public Tileset(string filePath, int rows = 10, int columns = 10)
		//Loads tileset from image and sets rows/cols
		{
			this.filePath = filePath;
			Load();
			Columns = columns;
			Rows = rows;
		}

		public void Load()
		{
			image = Image.FromFile(filePath);
		}

    }
}
