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
		/*static*/ int rows;
		/*static*/ int cols;
		/*static*/ int tileWidth = 64;			
		/*static*/ int tileHeight = 64;

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
				tileset.Rows = this.rows;
				tileset.Cols = this.cols;
				tileset.TileWidth = this.tileWidth;
				tileset.TileHeight = this.tileHeight;

				//Seperate tileset into individual tiles and insert into editor.tilepalette
				for (int row = 0; row < rows; row++)
				{
					for (int col = 0; col < cols; col++)
					{
						//Make a new tile by passing in a tileset and a tileset index
						var newTile = new Tile(tileset, new Point(row, col));

						//Add to the Editor's tilepalette
						EditorForm.TilePalette.Add(newTile);


						/*
						//Get a single tile
						//var singleTile = 
						//	display.Clone(
						//		new Rectangle(col * tileWidth, row * tileHeight, tileWidth, tileHeight), 
						//		System.Drawing.Imaging.PixelFormat.DontCare);

						////Add to EditorForm.Tiles
						//EditorForm.tilePalette.Add(new Tile(singleTile));
						////Update the editorform.tilepalette?
						////OR run procedures for the listview to update?
						*/
					}
				}

				//Return OK
				this.DialogResult = DialogResult.OK;
				this.Close();
				return;
			}
			//Return Cancel
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			//Close this form
			///DialogResult = DialogResult.Cancel;
			this.Close();
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
