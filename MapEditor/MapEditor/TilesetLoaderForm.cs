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
		int cols;
		int rows;
		int tileWidth = 32;			
		int tileHeight = 32;

		public TilesetLoaderForm()	
        {
            InitializeComponent();      //This literally loads all the components up and sets and positions them etc

			//Allocate the display
			display = new Bitmap(pbDisplay.Width, pbDisplay.Height);
			DrawDisplay();
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
					//Make a new tileset
					tileset = new Tileset(openDlg.FileName);

					//also set the initial tile width/heights
					textBoxTileWidth.Text = tileWidth.ToString();
					textBoxTileHeight.Text = tileHeight.ToString();

					DrawDisplay();
				}
			}
			openDlg.Dispose();
		}

		private void OKButton_Click(object sender, EventArgs e)
		{
			//If an image for the tileset has been loaded... (And the rows/cols/width/height settings are good)
			if (tileset != null) 
			{
				//Confirm and set tileset properties
				tileset.Cols = cols;
				tileset.Rows = rows;
				tileset.TileWidth = tileWidth;
				tileset.TileHeight = tileHeight;

				//Seperate tileset into individual tiles and insert into editor.tilepalette
				for (int col = 0; col < cols; col++)
				{
					for (int row = 0; row < rows; row++)
					{
						//Make a new tile by passing in a tileset and a tileset index
						var newTile = new Tile(tileset, new Point(col, row));

						//Add to the Editor's tilepalette
						EditorForm.TilePalette.Add(newTile);
					}
				}

				//Return OK
				DialogResult = DialogResult.OK;
				Close();
				return;
			}
			//Return Cancel
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			//Close this form
			///DialogResult = DialogResult.Cancel;
			Close();
		}
		

		private void TextBoxRows_TextChanged(object sender, EventArgs e)
		{
			if (tileset != null)
			{
				//Update rows and tileHeight accordingly
				if (int.TryParse(textBoxRows.Text, out rows) == true)
				{
					tileHeight = tileset.Image.Height / rows;
					textBoxTileHeight.Text = tileHeight.ToString();
					DrawDisplay();
				}
			}
		}
		private void TextBoxColumns_TextChanged(object sender, EventArgs e)
		{
			if (tileset != null)
			{
				//Update cols and tileWidth accordingly
				if (int.TryParse(textBoxColumns.Text, out cols) == true)
				{
					tileWidth = tileset.Image.Width / cols;
					textBoxTileWidth.Text = tileWidth.ToString();
					DrawDisplay();
				}
			}
		}
		private void TextBoxTileWidth_TextChanged(object sender, EventArgs e)
		{
			if (tileset != null)
			{
				//Update tileWidth and cols accordingly
				if (int.TryParse(textBoxTileWidth.Text, out tileWidth) == true)
				{
					cols = tileset.Image.Width / tileWidth;
					textBoxColumns.Text = cols.ToString();
					DrawDisplay();
				}
			}
		}
		private void TextBoxTileHeight_TextChanged(object sender, EventArgs e)
		{
			if (tileset != null)
			{
				//Update tileHeight and rows accordingly
				if (int.TryParse(textBoxTileHeight.Text, out tileHeight) == true)
				{
					rows = tileset.Image.Height / tileHeight;
					textBoxRows.Text = rows.ToString();
					DrawDisplay();
				}
			}
		}

		private void DrawDisplay()
		{
			int width = 0;
			int height = 0;

            //Update the display box
			pbDisplay.DrawToBitmap(display, pbDisplay.Bounds);
			
			Graphics g;
			g = Graphics.FromImage(display);
			g.Clear(Color.LightSlateGray);
			
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
			g.DrawLine(pen, 0, height, width, height);

			//Horizontals
			for (int x = 0; x < width; x += tileWidth)
			{
				g.DrawLine(pen, x, 0, x, height);
			}
			g.DrawLine(pen, width, 0, width, height);

			g.Dispose();

			//Update the display box
			pbDisplay.Image = display;
		}
	}
}
