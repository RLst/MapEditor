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
        private Image image = null;

        private string filePath;

		//Properties
        public int TileWidth
		{
			get
			{
				return TileWidth;
			}
			set
			{
				//Also set the num of columns accordingly
				TileWidth = value;
				if (image != null)
				{
					Columns = image.Size.Width / TileWidth;
				}
			}
		}
        public int TileHeight
		{
			get
			{
				return TileHeight;
			}
			set
			{
				TileHeight = value;
				if (image != null)
				{
					Rows = image.Size.Height / TileHeight;
				}
			}
		}
		public int Columns
        {
            get
            {
				//Columns = int(imagewidth / tilewidth)
				//Returns the number of columns based on the current tile width
				if (image != null)
					return Convert.ToUInt16(image.Size.Width / TileWidth);
				else
					return 0;
            }
            set
            {
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
		public Image Image { get; }

		public Tileset(string filePath, int rows = 10, int columns = 10)
		//Loads tileset from image and sets rows/cols
		{
			Rows = rows;
			Columns = columns;
			this.filePath = filePath;
			Load();
		}

		public void Load()
		{
			image = Image.FromFile(filePath);
		}

    }
}
