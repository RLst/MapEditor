using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapEditor
{
    public partial class TilesetLoaderForm : Form
    {
		Tileset tileset = null;
		Bitmap display;

		//These are just for this form only
		static int gridWidth = 10;			
		static int gridHeight = 10;

		public TilesetLoaderForm()	
        {
            InitializeComponent();      //This literally loads all the components up and sets and positions them etc

			//Allocate the display
			display = new Bitmap(DisplayBox.Width, DisplayBox.Height);

			textBoxTileWidth.Text = gridWidth.ToString();
			textBoxTileHeight.Text = gridHeight.ToString();
        }

		private void LoadButton_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				tileset = new Tileset(dlg.FileName);

				//Also set the tileset's tile sizes?
				//tileset.TileWidth = gridWidth;
				//tileset.TileHeight = gridHeight;

				DrawDisplay();
			}
		}

		private void OKButton_Click(object sender, EventArgs e)
		{
			//If an image for the tileset has been loaded... (And the rows/cols/width/height settings are good)

				//Split the tileset into individual tiles

				//Push them into Program::tiles ?

				//Close the form

			//Otherwise just close the form
			//Set focus back to editor form
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			//Close this form
			Close();

			//Set focus back to EditorForm...
			//Nope just use ShowDialog() instead of Show() and the focus issues will take care of itself
		}


		private void TilesetLoaderForm_Load(object sender, EventArgs e)
		{
			//What does load do?
				//First function that runs when this form is created?
		}

		private void TextBoxRows_TextChanged(object sender, EventArgs e)
		{
            //Update this.gridWidth
            //Update tileset.TileWidth accordingly
		}
		private void TextBoxColumns_TextChanged(object sender, EventArgs e)
		{
            //Update this.gridHeight
            //Update tileset.TileHeight accordingly
        }

        private void TextBoxTileWidth_TextChanged(object sender, EventArgs e)
		{
            //Update tileWidth and gridWidth accordinly
			if (int.TryParse(textBoxTileWidth.Text, out gridWidth) == true)
			{
				DrawDisplay();
			}
			textBoxColumns.Text = gridWidth.ToString();
		}

		private void TextBoxTileHeight_TextChanged(object sender, EventArgs e)
		{
            //Update tileHeight and gridHeight accordingly
			if (int.TryParse(textBoxTileHeight.Text, out gridHeight) == true)
			{
				DrawDisplay();
			}
			textBoxRows.Text = gridHeight.ToString();
		}

		private void DrawDisplay()
		{
            //Update the display box
			DisplayBox.DrawToBitmap(display, DisplayBox.Bounds);
			
			Graphics g;		//?
			g = Graphics.FromImage(display);

			g.Clear(Color.White);	//?

			//Only draw if an image is available
			if (tileset != null)
			{
				g.DrawImage(tileset.Image, 0, 0);
			}

			//// Draw the grid ////
			Pen pen = new Pen(Brushes.Black);

			int height = display.Height;
			int width = display.Width;

			//Verticals
			for (int y = 0; y < height; y += gridHeight)
			{
				g.DrawLine(pen, 0, y, width, y);
			}

			//Horizontals
			for (int x = 0; x < width; x += gridWidth)
			{
				g.DrawLine(pen, x, 0, x, height);
			}

			g.Dispose();

			//Update the display box
			DisplayBox.Image = display;
		}
    }
}
