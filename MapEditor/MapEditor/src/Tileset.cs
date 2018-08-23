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
        public float TileWidth { get; set; }
        public float TileHeight { get; set; }
        public int Columns
        {
            get
            {
                //Columns = int(imagewidth / tilewidth)
                //Returns the number of columns based on the current tile width
                return Convert.ToUInt16(image.Size.Width / TileWidth);
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
                return Convert.ToUInt16(image.Size.Height / TileHeight);
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
