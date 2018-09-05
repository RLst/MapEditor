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
		//Map
		static private Map map = null;                  //Holds the actual map using actual tiles
		//pbCanvas displays the map

		//Tile palette
		static private Tile selectedTile = null;
		static private ImageList tileSwatches;			//Thumbnails for lvTilePalette (List View)
		static public List<Tile> tilePalette;			//The actual tiles in the tile palette
		//static private List<Tileset> tilesets;		//Can hold many tilesets OR...
		//static private Camera camera;

		//Mouse related editing
		bool onPaint = false;       //If the mouse has been pressed 
		bool onPan = false;
		Point dragStart;

		//Saving
		private bool currentDocumentNotPreviouslySaved = true;
		private string currentDocumentPath = null;
		//private int childFormNumber = 0;

        public EditorForm()
        {
            InitializeComponent();

			//Setup core structures
			tilePalette = new List<Tile>();
			tileSwatches = new ImageList();

			//Setup a blank map and draw the canvas (First ever run)
			map = new Map(10, 10, 64, 64)	//Some basic default values
			{
				Bitmap = new Bitmap(pbCanvas.Width, pbCanvas.Height)
			};
			DrawCanvas();

			//Setup tilePalette listview
			lvTilePalette.LargeImageList = tileSwatches;
			lvTilePalette.LargeImageList.ImageSize = new Size(48, 48);
			lvTilePalette.LargeImageList.ColorDepth = ColorDepth.Depth24Bit;
        }

		/// <summary>
		/// Shows dialog to create a new map
		/// </summary>
        private void ShowNewDialog(object sender, EventArgs e)
        {
			//Get  
			NewMapDialog newMapDialog = new NewMapDialog();
			//Show the new map dialog and check if OK clicked
			if (newMapDialog.ShowDialog(this) == DialogResult.OK)
			{
				//Clear/reset current document
				//newMapDialog.
				
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
		/// Shows dialog to open a new map
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
		/// Shows dialog to save current map
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
			tileSetLoadForm.Dispose();

			//Deactivate this form so the user can't interact with it...
			//NOPE... just use ShowDialog() instead of Show()
		}
		private void RemoveTilesButton_Click(object sender, EventArgs e)
		{
			//Removes the selected tile
			var selectedIndex = lvTilePalette.SelectedIndices[0];
			lvTilePalette.Items.Remove(lvTilePalette.SelectedItems[0]);     //...from the listview image list
			tilePalette.RemoveAt(selectedIndex);						//...and the actual tile from availableTiles

				//Maybe later add ability to remove multiple selected tiles?
		}
		private void ClearTilesButton_Click(object sender, EventArgs e)
		{
			//Removes all tiles
			lvTilePalette.Items.Clear();
			tilePalette.Clear();
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
			for (int i = 0; i < tilePalette.Count; i++)
			{
				tileSwatches.Images.Add(tilePalette[i].Image);
				var item = new ListViewItem();
				item.ImageIndex = i;
				lvTilePalette.Items.Add(item);
			}
			//tilePalette.LargeImageList = tileSwatches;	//This was already done in the constructor
		}

		//private void Canvas_Click(object sender, EventArgs e)
		//{
		//	var mouse = e as MouseEventArgs;

		//	//Pan camera
		//	//If middle clicked...
		//	if (mouse.Button == MouseButtons.Middle)
		//	{
		//		//Get drag start pos
		//		//var dragStart = new Point(mouse.X, mouse.Y);

		//		//Update grid based on the difference of the drag
	
		//	}

		//}

		private void Canvas_MouseDown(object sender, MouseEventArgs e)
		{
			////Paint
			if (e.Button == MouseButtons.Left)
			{
				onPaint = true;
			}

			////Pan
			if (e.Button == MouseButtons.Middle)
			{
				//Get starting point of drag
				onPan = true;
				dragStart = new Point(e.X, e.Y);
			}
		}

		private void Canvas_MouseMove(object sender, MouseEventArgs e)
		{
			////Paint
			if (onPaint)
			{
				//Get selected tile
				//int selectedIndex;
				selectedTile = GetSelectedTile(out int selectedIndex);

				//If selected tile is available
				if (selectedTile != null)
				{
					Point mapIndex = new Point(e.X, e.Y);
					var tileUnderMouse = map.FindTile(mapIndex);

					statusStrip.Items[0].Text = "Tile Under Mouse";     //DEBUG

					//Overwrite if tile is different in map
					if (tileUnderMouse != selectedTile)
					{
						//map.

						//availableTiles[selectedIndex] = selectedTile;		//Actual tiles
								//Canvas
					}

					DrawCanvas();
					return;     //Only one thing at a time?
				}
			}

			////Camera Pan
			if (onPan)
			{
				//"Move" camera


			}

		}

		private void Canvas_MouseUp(object sender, MouseEventArgs e)
		{
			//Clear all mouse states
			onPaint = false;
			onPan = false;
		}

		private Tile GetSelectedTile(out int selectedIndex)
		{
			//If there are tiles AND something is selected...
			if (lvTilePalette.Items.Count > 0)
			{
				if (lvTilePalette.SelectedIndices.Count > 0)
				{
					selectedIndex = lvTilePalette.SelectedIndices[0];
					return tilePalette[selectedIndex];
				}
			}
			//Otherwise return null
			selectedIndex = -1;
			return null;
		}

		private void DrawCanvas()
		{
			//Update the canvas
			pbCanvas.DrawToBitmap(map.Bitmap, pbCanvas.Bounds);

			Graphics g;
			g = Graphics.FromImage(map.Bitmap);
			g.Clear(Color.LightSlateGray);

			//// if Image available ////
			//if (map.Bi != null)
			//{
			//	g.DrawImage(tileset.Image, 0, 0);
			//	width = tileset.Image.Width;
			//	height = tileset.Image.Height;
			//}
			//else
			//{   //image not avaiable, draw blank bitmap
			//	width = display.Width;
			//	height = display.Height;
			//}

			//// Map Grid ////
			Pen pen = new Pen(Brushes.DarkGray);
			//Verticals
			for (int y = 0; y < pbCanvas.Height; y += map.TileHeight)
			{
				g.DrawLine(pen, 0, y, pbCanvas.Width, y);
			}
			//Horizontals
			for (int x = 0; x < pbCanvas.Width; x += map.TileWidth)
			{
				g.DrawLine(pen, x, 0, x, pbCanvas.Height);
			}

			//// Draw the tiles ////
			//Go through the map
			for (int row = 0; row < map.Tiles.GetLength(0); row++)
			{
				for (int col = 0; col < map.Tiles.GetLength(1); col++)
				{
					//Draw tile if available
					if (map.Tiles[row, col] != null)
					{
						//pbCanvas.
					}
				}
			}			

			//Finished drawing
			g.Dispose();

			//Update the display box
			pbCanvas.Image = map.Bitmap;
		}

		private void TilePalette_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lvTilePalette.Items.Count > 0)
			{
				if (lvTilePalette.SelectedIndices.Count > 0)
				{
					//Set the selected tile as the 
					selectedTile = GetSelectedTile(out int selectedIndex);
				}
			}
			selectedTile = null;
		}
	}
}
