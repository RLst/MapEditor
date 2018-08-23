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
		int gridWidth = 10;			
		int gridHeight = 10;

		public TilesetLoaderForm()	
        {
            InitializeComponent();      //This literally loads all the components up and sets and positions them etc

			//Allocate the display
			display = new Bitmap(tslDisplayBox.Width, tslDisplayBox.Height);
        }

		private void tslLoadButton_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				tileset = new Tileset(dlg.FileName);

				//Also set the tileset's tile sizes?
				tileset.TileWidth = gridWidth;
				tileset.TileHeight = gridHeight;

				DrawDisplay();
			}
		}

		private void tslOKButton_Click(object sender, EventArgs e)
		{
			//If an image for the tileset has been loaded... (And the rows/cols/width/height settings are good)

				//Split the tileset into individual tiles

				//Push them into Program::tiles ?

				//Close the form

			//Otherwise just close the form

		}

		private void tslCancelButton_Click(object sender, EventArgs e)
		{
			//Close this form
			Close();

			//Reactivate EditorForm 
		}



		private void TilesetLoaderForm_Load(object sender, EventArgs e)
		{

		}

		private void textBoxRows_TextChanged(object sender, EventArgs e)
		{

		}
		private void textBoxColumns_TextChanged(object sender, EventArgs e)
		{

		}

		private void textBoxTileWidth_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(textBoxTileWidth.Text, out gridWidth) == true)
			{
				DrawDisplay();
			}
			textBoxColumns.Text = gridWidth.ToString();
		}

		private void textBoxTileHeight_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(textBoxTileHeight.Text, out gridHeight) == true)
			{
				DrawDisplay();
			}
			textBoxRows.Text = gridHeight.ToString();
		}

		private void DrawDisplay()
		{
			tslDisplayBox.DrawToBitmap(display, tslDisplayBox.Bounds);

			//Create graphics from image?
			Graphics g;
			g = Graphics.FromImage(display);

			//
			g.Clear(Color.White);

			if (tileset != null)
			{
				g.DrawImage(tileset.Image, 0, 0);
			}

			//Draw the grid
			Pen pen = new Pen(Brushes.Black);

			int height = display.Height;
			int width = display.Width;

			//Draw vertical grid?
			for (int y = 0; y < height; y += gridHeight)
			{
				g.DrawLine(pen, 0, y, width, y);
			}


			g.Dispose();

			//Update the display box
			tslDisplayBox.Image = display;
		}


	}
}
