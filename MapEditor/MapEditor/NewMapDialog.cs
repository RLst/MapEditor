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
	public partial class NewMapDialog : Form
	{
		static public int Rows { get; set; }
		static public int Cols { get; set; }
		static public int TileWidth { get; set; }
		static public int TileHeight { get; set; }


		public NewMapDialog(int rows = 10, int cols = 10, int tileWidth = 64, int tileHeight = 64)
		{
			InitializeComponent();
			Rows = rows;
			Cols = cols;
			TileWidth = tileWidth;
			TileHeight = tileHeight;
		}

		private void NewMapDialog_Load(object sender, EventArgs e)
		{
			//Init textboxes
			textBoxRows.Text = Rows.ToString();
			textBoxColumns.Text = Cols.ToString();
			textBoxTileWidth.Text = TileWidth.ToString();
			textBoxTileHeight.Text = TileHeight.ToString();
			UpdateLblMapSize();
		}

		private void textBoxRows_TextChanged(object sender, EventArgs e)
		{
			//Update properties and map size label
			Rows = Convert.ToInt32((textBoxRows.Text == "") ? "0" : textBoxRows.Text);
			UpdateLblMapSize();
		}
		private void textBoxColumns_TextChanged(object sender, EventArgs e)
		{
			Cols = Convert.ToInt32((textBoxColumns.Text == "") ? "0" : textBoxColumns.Text);
			UpdateLblMapSize();
		}
		private void textBoxTileWidth_TextChanged(object sender, EventArgs e)
		{
			TileWidth = Convert.ToInt32((textBoxTileWidth.Text == "") ? "0" : textBoxTileWidth.Text);
			UpdateLblMapSize();
		}
		private void textBoxTileHeight_TextChanged(object sender, EventArgs e)
		{
			TileHeight = Convert.ToInt32((textBoxTileHeight.Text == "") ? "0" : textBoxTileHeight.Text);
			UpdateLblMapSize();
		}


		private void OKButton_Click(object sender, EventArgs e)
		{
			//Flag OK
			DialogResult = DialogResult.OK;
			Close();
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void UpdateLblMapSize()
		{
			int mapWidth = Cols * TileWidth;
			int mapHeight = Rows * TileHeight;
			lblMapSize.Text = mapWidth.ToString() + " x " + mapHeight.ToString() + " pixels";
		}

	}
}
