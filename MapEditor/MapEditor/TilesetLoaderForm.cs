﻿using System;
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
		//These are just for this form only
		Tileset tileset = null;
		Bitmap display;
		static int rows;
		static int cols;
		static int tileWidth = 10;			
		static int tileHeight = 10;

		public TilesetLoaderForm()	
        {
            InitializeComponent();      //This literally loads all the components up and sets and positions them etc

			//Set the parent
			//var parentForm = ???

			//Allocate the display
			display = new Bitmap(DisplayBox.Width, DisplayBox.Height);

			//
			textBoxTileWidth.Text = tileWidth.ToString();
			textBoxTileHeight.Text = tileHeight.ToString();
        }

		private void TilesetLoaderForm_Load(object sender, EventArgs e)
		{
			//What does load do?
			//First function that runs when this form is created?
		}

		private void LoadButton_Click(object sender, EventArgs e)
		{
			OpenFileDialog openDlg = new OpenFileDialog();

			if (openDlg.ShowDialog() == DialogResult.OK)
			{
				if (openDlg.CheckFileExists == true) {
					tileset = new Tileset(openDlg.FileName);
					DrawDisplay();
				}

				//Also set the tileset's tile sizes?
				//tileset.TileWidth = gridWidth;
				//tileset.TileHeight = gridHeight;
			}
			openDlg.Dispose();
		}

		private void OKButton_Click(object sender, EventArgs e)
		{
			//If an image for the tileset has been loaded... (And the rows/cols/width/height settings are good)
			if (tileset != null) 
			{
				//Split the tileset into individual tiles according to width and height settings
				var tilesForEditor = new List<Tile>();

				for (int row = 0; row < rows; ++row) {
					for (int col = 0; col < cols; ++col) {
						//Get section of bitmap
						var bmpTile = display.Clone(new Rectangle(col * tileWidth, row * tileHeight, tileWidth, tileHeight), System.Drawing.Imaging.PixelFormat.DontCare);

						//Make a new tile
						var newTile = new Tile(bmpTile);
						//newTile.Texture = imgTile;

						//Add to EditorForm::Tiles

					}
				}

				//Push them into editorform::tiles ?
				var parentForm = sender.GetType();

				//Close the form

			}
			//Otherwise just close the form
			//Set focus back to editor form
			this.Close();
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			//Close this form
			Close();

			//Set focus back to EditorForm...
			//Nope just use ShowDialog() instead of Show() and the focus issues will take care of itself
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
			if (int.TryParse(textBoxTileWidth.Text, out tileWidth) == true) {
				DrawDisplay();
			}
			textBoxColumns.Text = tileWidth.ToString();
		}

		private void TextBoxTileHeight_TextChanged(object sender, EventArgs e)
		{
			//Update tileHeight and gridHeight accordingly
			if (int.TryParse(textBoxTileHeight.Text, out tileHeight) == true) {
				DrawDisplay();
			}
			textBoxRows.Text = tileHeight.ToString();
		}

		private void DrawDisplay()
		{
			int width = 0;
			int height = 0;

            //Update the display box
			DisplayBox.DrawToBitmap(display, DisplayBox.Bounds);
			
			Graphics g;		//?
			g = Graphics.FromImage(display);

			g.Clear(Color.White);	//?


			//// if Image available ////
			if (tileset != null)
			{
				g.DrawImage(tileset.Image, 0, 0);
				width = tileset.Image.Width;
				height = tileset.Image.Height;
			}
			else {	//image not avaiable, draw blank bitmap
				width = display.Width;
				height = display.Height;
			}

			//// Draw the grid ////
			Pen pen = new Pen(Brushes.Black);

			//Verticals
			for (int y = 0; y < height; y += tileHeight)
			{
				g.DrawLine(pen, 0, y, width, y);
			}

			//Horizontals
			for (int x = 0; x < width; x += tileWidth)
			{
				g.DrawLine(pen, x, 0, x, height);
			}

			g.Dispose();

			//Update the display box
			DisplayBox.Image = display;
		}
	}
}
