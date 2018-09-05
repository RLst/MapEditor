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
		//Locals just for this dialog
		static int rows = 15;
		static int cols = 15;
		static int tileWidth = 32;		//px
		static int tileHeight = 32;		//px

		public NewMapDialog()
		{
			InitializeComponent();
		}

		private void UpdateLblMapSize()
		{
			//Calculate the map width
			int mapWidth = cols * tileWidth;

			//Calculate the map height
			int mapHeight = rows * tileHeight;

			//Update
			lblMapSize.Text = mapWidth.ToString() + " x " + mapHeight.ToString() + " pixels";
		}

		private void NewMapDialog_Load(object sender, EventArgs e)
		{
			//Init textboxes
			textBoxRows.Text = rows.ToString();
			textBoxColumns.Text = cols.ToString();
			textBoxTileWidth.Text = tileWidth.ToString();
			textBoxTileHeight.Text = tileHeight.ToString();
			UpdateLblMapSize();
		}
		private void textBoxRows_TextChanged(object sender, EventArgs e)
		{
			//Update rows
			rows = Convert.ToInt32(textBoxRows.Text);
		}

		private void textBoxColumns_TextChanged(object sender, EventArgs e)
		{
			//Update columns
			cols = Convert.ToInt32(textBoxRows.Text);
		}

		private void OKButton_Click(object sender, EventArgs e)
		{
			//Make sure rows and column values are valid


			//Clear document
			//Reset Program.map
			//Clear tilesets/tiles

			//Create a blank new map of specified size and tile layout

			//Delete


			
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
