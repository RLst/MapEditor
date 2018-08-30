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
    public partial class EditorForm : Form
    {
		//This is the meat of the current document:
		static private Map map;							//The one and only map
		static public List<Tile> availableTiles;        //All the tiles in the list box 
		static public ImageList tileSwatches;			//"Swatches" of the tiles used for painting, but not the actual tiles themselves	
		//static public List<Tileset> tilesets;			//Can hold many tilesets OR...

        public EditorForm()
        {
            InitializeComponent();
			availableTiles = new List<Tile>();
			tileSwatches = new ImageList();
			//Set the image list for the tile palette
			tilePalette.LargeImageList = tileSwatches;
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            //If a current document is open, prompt user to save first

			//Otherwise clear Program.map and create a new map
			
			//Form childForm = new TilesetLoaderForm();
            ////Form childForm = new Form();
            //childForm.MdiParent = this;
            //childForm.Text = "Window " + childFormNumber++;
            //childForm.Show();
        }

		/// <summary>
		/// OPEN related methods
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

		/// <summary>
		/// SAVE related methods
		/// ////////////////////
		/// pkr Map Editor Project files:
		/// - Saved as .mep files (map editor project)
		///		Which includes the current map data
		///		Any tilesets/tiles in the tile palette
		///		Other settings
		/// - Export to .map files
		///		These are the actual files that will be used by the game app 
		///		
		/// </summary>
		private void Save()
		{
			//If a document has previously been saved then save as normal
			if (false);

			//Otherwise call SaveAs()
			else
				SaveAs();
		}
		private void SaveAs()
		{
			//Calls the save dialog and prompts user for a new save file            
			SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
		}
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

			SaveAs();
        }
		private void SaveToolStripButton_Click(object sender, EventArgs e)
		{
			//Calls THE save function
		}
		private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//Calls THE save function
		}

		private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
			//If there are changes then ask to save changes (utilise dirty flag pattern)

            Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }
        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }


		/// <summary>
		/// ListView Box
		/// </summary>
		private void AddTilesButton_Click(object sender, EventArgs e)
		{
			TilesetLoaderForm tileSetLoadForm = new TilesetLoaderForm();

			if (tileSetLoadForm.ShowDialog(this) == DialogResult.OK) 
			{
				//If there are new tiles then load in new tiles
				UpdateTilePaletteItems();
			}

			//Deactivate this form so the user can't interact with it...
			//NOPE... just use ShowDialog() instead of Show()
		}
		private void RemoveTilesButton_Click(object sender, EventArgs e)
		{

		}
		private void ClearTilesButton_Click(object sender, EventArgs e)
		{

		}

		private void HelpToolStripButton_Click(object sender, EventArgs e)
		{
			//Open user manual
		}
		private void UserManualToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//Open user manual
		}
		
		private void UpdateTilePaletteItems()
		{
			//Go through all tiles and update the list items
			int i = 0;
			foreach (var tile in availableTiles)
			{
				tileSwatches.Images.Add(tile.Texture);
				++i;

			}
		}

		private void tilePalette_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
	}
}
