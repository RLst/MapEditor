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
		//Old values
		int rows = 10; int cols = 10; int tilewidth = 64; int tileheight = 64;

		//Map
		public static Map map = null;        //Holds the actual map using actual tiles; pbCanvas displays the actual map

		//Tilesets - Concreate location for Tiles to reference off
		static public List<Tileset> tilesets;

		//Tile palette
		private Tile selectedTile = null;
		public static List<Tile> TilePalette { get; set; }
		private ImageList tileSwatches;						//Thumbnails for lvTilePalette (List View)
															//static private List<Tileset> tilesets;
		//Camera
		private static Camera cam;

		//Editing states
		bool onPaint = false;       //If the mouse has been pressed 
		bool onPan = false;
		Point dragStart;

		//Saving
		private bool currentDocumentPreviouslySaved;
		private string currentDocumentPath = null;


		public EditorForm()
        {
            InitializeComponent();

			//Setup core
			TilePalette = new List<Tile>();
			tileSwatches = new ImageList();
			cam = new Camera();
			currentDocumentPreviouslySaved = false;


			//Setup a blank map and draw the canvas (First ever run)
			////NEW MAP DIALOG GOES HERE!!! Always ask the user for map settings upon first launch

			map = new Map(10, 10, 64, 64)	//Default starting map
			{
				Bitmap = new Bitmap(pbCanvas.Width, pbCanvas.Height)
			};
			DrawCanvas();

			//Setup tilePalette listview
			lvTilePalette.LargeImageList = tileSwatches;
			lvTilePalette.LargeImageList.ImageSize = new Size(86, 86);
			lvTilePalette.LargeImageList.ColorDepth = ColorDepth.Depth24Bit;

			//DEBUG
			statusStrip.Items.Add("Item 2");
			statusStrip.Items.Add("Item 3");
		}

		/// <summary>
		/// Shows dialog to create a new map
		/// </summary>
        private void ShowNewDialog(object sender, EventArgs e)
        {
			NewMapDialog newMapDialog = new NewMapDialog(rows, cols, tilewidth, tileheight);

			//Show the new map dialog and check if OK clicked
			if (newMapDialog.ShowDialog(this) == DialogResult.OK)
			{
				//If current map not saved then provide option to user to save or cancel
				if (!currentDocumentPreviouslySaved)
				{
					//PromptDialog promptDialog = new PromptDialog();
					//int result = promptDialog.ShowDialog();

					//if (result == DialogResult.OK)
					//{
					//	//Save
					//	Save();
					//}
					//else if (result == DialogResult.Cancel)
					//{
					//	//Don't save or create new map
					//	return;
					//}
				}

				//Save map parameters for next time
				rows = NewMapDialog.Rows;
				cols = NewMapDialog.Cols;
				tilewidth = NewMapDialog.TileWidth;
				tileheight = NewMapDialog.TileHeight;
				//Go ahead with creating a new map
				map.NewMap(rows, cols, tilewidth, tileheight);
				DrawCanvas();
			}

		}

		private void PromptSave()
		{

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
			if (!currentDocumentPreviouslySaved)
			{
				SaveAs();

			}

			//Add Save logic here

			currentDocumentPreviouslySaved = true;	//Important to set saved flag
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

			currentDocumentPreviouslySaved = true;  //Important to set saved flag
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
			if (currentDocumentPreviouslySaved)
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
			tileSetLoadForm.Dispose();	//Is this required?
		}
		private void RemoveTilesButton_Click(object sender, EventArgs e)
		{
			//Removes the selected tile
			var selectedIndex = lvTilePalette.SelectedIndices[0];
			lvTilePalette.Items.Remove(lvTilePalette.SelectedItems[0]);     //...from the listview image list
			TilePalette.RemoveAt(selectedIndex);						//...and the actual tile from availableTiles

				//Maybe later add ability to remove multiple selected tiles?
		}
		private void ClearTilesButton_Click(object sender, EventArgs e)
		{
			//Removes all tiles
			lvTilePalette.Items.Clear();
			TilePalette.Clear();
		}

		private void HelpToolStripButton_Click(object sender, EventArgs e)
		{
			//Open user manual
		}
		private void UserManualToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//Open user manual
		}
		


		/// <summary>
		/// Canvas painting methods
		/// </summary>
		private void Canvas_MouseDown(object sender, MouseEventArgs e)
		{
			////Paint
			if (e.Button == MouseButtons.Left)
			{
				onPaint = true;
				PaintTile(e);
			}

			////Pan
			if (e.Button == MouseButtons.Middle)
			{
				//Get starting point of drag
				onPan = true;
				dragStart = new Point(e.X + cam.X, e.Y + cam.Y);

				///DEBUG
				statusStrip.Items[2].Text = "Drag start: " + dragStart;
			}
		}

		private void Canvas_MouseMove(object sender, MouseEventArgs e)
		{
			////Paint
			if (onPaint)
			{
				PaintTile(e);
			}

			////Camera Pan
			if (onPan)
			{
				//"Move" camera
				PanCamera(e);
			}

			///DEBUG
			statusStrip.Items[0].Text = "Map Coords: " + (e.X+cam.X) + ", " + (e.Y+cam.Y);
			statusStrip.Items[1].Text = "Map Tile Index: " + map.PosToIndex(e.X+cam.X, e.Y+cam.Y);
		}

		private void PanCamera(MouseEventArgs me)
		{
			//Set the new camera position
			cam.X = dragStart.X - me.X;
			cam.Y = dragStart.Y - me.Y;
			DrawCanvas();
		}
		
		private void Canvas_MouseUp(object sender, MouseEventArgs e)
		{
			//Clear all mouse states
			onPaint = false;
			onPan = false;
		}

		/// <summary>
		/// Paints currently selected tile (if available) at current mouse cursor (if within bounds of map)
		/// </summary>
		private void PaintTile(MouseEventArgs me)
		{
			selectedTile = GetSelectedTile(out int selectedIndex);

			var mouseMapIDX = map.PosToIndex(me.X+cam.X, me.Y+cam.Y);

			//Mouse has to be within bounds of map
			if (MouseWithinMapBounds(mouseMapIDX))
			{
				//If selected tile is available
				if (selectedTile != null)
				{
					var tileUnderMouse = map.Tiles[mouseMapIDX.X, mouseMapIDX.Y];

					//Overwrite if tile is different in map
					if (tileUnderMouse != selectedTile)
					{
						map.Tiles[mouseMapIDX.X, mouseMapIDX.Y] = selectedTile;   //Modify the actual tiles
						DrawCanvas();
					}
				}
			}
		}


		private Tile GetSelectedTile(out int selectedIndex)
		{
			//If there are tiles...
			if (lvTilePalette.Items.Count > 0)
			{
				//AND something is selected...
				if (lvTilePalette.SelectedIndices.Count > 0)
				{
					selectedIndex = lvTilePalette.SelectedIndices[0];
					return TilePalette[selectedIndex];
				}
			}
			//Otherwise return null
			selectedIndex = -1;
			return null;
		}

		private void TilePalette_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lvTilePalette.Items.Count > 0)
			{
				if (lvTilePalette.SelectedIndices.Count > 0)
				{
					//Set the current tile brush 
					selectedTile = GetSelectedTile(out int selectedIndex);

					///DEBUG
					statusStrip.Items[0].Text = "Selected Tile = " + selectedIndex;
					return;
				}
			}
			selectedTile = null;
		}


		/// <summary>
		/// Draws the canvas
		/// NOTE: Take notice of camera offsets!
		/// </summary>
		private void DrawCanvas()
		{
			////Update the canvas
			pbCanvas.DrawToBitmap(map.Bitmap, pbCanvas.Bounds);

			////Draw background
			Graphics g;
			g = Graphics.FromImage(map.Bitmap);
			g.Clear(Color.LightGray);

			//// Draw Grid ////
			Pen pen = new Pen(Brushes.Black);
			//Verticals
			for (int y = 0; y < map.Height; y += map.TileHeight)
			{
				g.DrawLine(pen, 0-cam.X, y-cam.Y, map.Width-cam.X, y-cam.Y);
			}
			g.DrawLine(pen, 0-cam.X, map.Height-cam.Y, map.Width-cam.X, map.Height-cam.Y);  //Grid border of map
																	//Horizontals
			for (int x = 0; x < map.Width; x += map.TileWidth)
			{
				g.DrawLine(pen, x-cam.X, 0-cam.Y, x-cam.X, map.Height-cam.Y);
			}
			g.DrawLine(pen, map.Width-cam.X, 0-cam.Y, map.Width-cam.X, map.Height-cam.Y);   //Grid border of map

			//// Draw the tiles ////
			//Go through the map
			for (int row = 0; row < map.Tiles.GetLength(0); row++)
			{
				for (int col = 0; col < map.Tiles.GetLength(1); col++)
				{
					//Draw tile if available
					if (map.Tiles[row, col] != null)
					{
						g.DrawImage(map.Tiles[row, col].Image, row * map.TileWidth-cam.X, col * map.TileHeight-cam.Y);
					}
				}
			}

			//Finished drawing
			g.Dispose();

			//Update the display box
			pbCanvas.Image = map.Bitmap;
		}

		/// <summary>
		/// Updates tile swatches in the tile palette
		/// </summary>
		private void UpdateTilePaletteItems()
		{
			//Go through all tiles and update the list items
			for (int i = 0; i < TilePalette.Count; i++)
			{
				tileSwatches.Images.Add(TilePalette[i].Image);
				var item = new ListViewItem();
				item.ImageIndex = i;
				lvTilePalette.Items.Add(item);
			}
		}


		/////////////////////////////////////
		//// Auxillary Helper functions ////
		///////////////////////////////////
		private bool MouseWithinMapBounds(Point mouseMapIDX)
		{
			return (Enumerable.Range(0, map.Tiles.GetLength(0)).Contains(mouseMapIDX.X) &&
				Enumerable.Range(0, map.Tiles.GetLength(1)).Contains(mouseMapIDX.Y));
		}

		private void EditorForm_Resize(object sender, EventArgs e)
		{
			//Resize pbCanvas. accordingly
			//pbCanvas 
			//	pbCanvas.Size;
		}
	}
}
