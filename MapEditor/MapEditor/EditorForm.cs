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
		static private List<Tileset> tilesets;          //Can hold many tilesets OR...
		static private List<Tile> availableTiles;       //All the tiles in the list box 
		static private ImageList tileSwatches;

		private string currentDocumentPath = null;
		private bool currentDocumentNotPreviouslySaved = true;

		private int childFormNumber = 0;

        public EditorForm()
        {
            InitializeComponent();

			//Setup tilePalette listview
			availableTiles = new List<Tile>();
			tileSwatches = new ImageList();
			tilePalette.LargeImageList = tileSwatches;
			tilePalette.LargeImageList.ImageSize = new Size(48, 48);
			tilePalette.LargeImageList.ColorDepth = ColorDepth.Depth24Bit;
        }

		/// <summary>
		/// NEW
		/// </summary>
        private void ShowNewDialog(object sender, EventArgs e)
        {
			//Get  
			NewMapDialog newMapDialog = new NewMapDialog();
			//Show the new map dialog and check if OK clicked
			if (newMapDialog.ShowDialog(this) == DialogResult.OK)
			{
				//Clear/reset current document
				
			}

			//If a current document is open, prompt user to save first

			//Otherwise clear Program.map and create a new map

			/*
			Form childForm = new TilesetLoaderForm();
            //Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
			*/
		}

		/// <summary>
		/// OPEN
		/// </summary>
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
		/// SAVE
		/// ////////////////////
		/// pkr Map Editor Project files:
		/// - Saved as .mep files (map editor project)
		///		Which includes the current map data
		///		Any tilesets/tiles in the tile palette
		///		Other settings
		/// - Export to .map files
		///		These are the actual files that will be used by the game app
		/// </summary>
		private void Save()
		{
			if (currentDocumentNotPreviouslySaved)
			{
				SaveAs();
			}
			//Add Save logic here
			Console.WriteLine("Saving...");
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

		/// <summary>
		/// Handle Menu Items and Buttons
		/// </summary>
		//New
		private void newMapToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var NewMapDialog = new NewMapDialog();

			NewMapDialog.ShowDialog();



		}

		private void newToolStripButton_Click(object sender, EventArgs e)
		{
			//Open create new map dialog
			ShowNewDialog(sender, e);

			//var newMapDlg = new NewMapDialog();
			//newMapDlg.ShowDialog();
		}


		//Save
		private void SaveToolStripButton_Click(object sender, EventArgs e)
		{
			//Calls THE save function
			Save();
		}
		private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//Calls THE save function
			Save();
		}
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
			SaveAs();
        }

		//Cut copy and paste
        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

		//Other
		private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
		{
			//If there are changes then ask to save changes (utilise dirty flag pattern)
			if (currentDocumentNotPreviouslySaved)
			{
				Save();
			}
			Close();
		}
		private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //foreach (Form childForm in MdiChildren)
            //{
            //    childForm.Close();
            //}
        }

		private void AddTilesButton_Click(object sender, EventArgs e)
		{
			TilesetLoaderForm tileSetLoadForm = new TilesetLoaderForm();
			tileSetLoadForm.ShowDialog(this);
			tileSetLoadForm.Dispose();

			//Deactivate this form so the user can't interact with it...
			//NOPE... just use ShowDialog() instead of Show()
		}
		private void RemoveTilesButton_Click(object sender, EventArgs e)
		{

		}
		private void ClearTilesButton_Click(object sender, EventArgs e)
		{

		}


		private void helpToolStripButton_Click(object sender, EventArgs e)
		{
			//Open user manual
		}

		private void userManualToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//Open user manual
		}
		
		private void UpdateTilePaletteItems()
		{
			//Go through all tiles and update the list items
			//int i = 0;
			for (int i = 0; i < availableTiles.Count; i++)
			{
				tileSwatches.Images.Add(availableTiles[i].Image);
				var item = new ListViewItem();
				item.ImageIndex = i;
				tilePalette.Items.Add(item);
			}
			//tilePalette.LargeImageList = tileSwatches;	//This was already done in the constructor
		}

		private void tilePalette_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

	}
}
