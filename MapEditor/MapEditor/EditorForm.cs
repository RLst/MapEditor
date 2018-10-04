using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace MapEditor
{

	public partial class EditorForm : Form
    {
		//Initial/Previously used values
		int rows = 15;
		int cols = 10;
		int tilewidth = 32;
		int tileheight = 32;

		//Map [serialize]
		public static Map map = null;        //Holds the actual map using actual tiles; pbCanvas displays the actual map

		//Tilesets - Concrete location for Tiles to reference off  [serialize]
		public static List<Tileset> tilesets;

		//Tile palette
		private Tile selectedTile = null;
		public static List<Tile> TilePalette { get; set; }		//Holds the ACTUAL tiles in the Tile Palette
		private ImageList tileSwatches;							//Holds the thumbnails for lvTilePalette (List View)
		
		//Camera
		private static Camera cam;
		Point camDragStart;
		bool onCamPan = false;

		//Paint
		bool onPaint = false;       //If the mouse has been pressed 

		//Drag n Drop
		private bool onTileDrag = false;
		private Tile draggedTile;

		//private bool onSelect;
		//private Point selectionBoxStart;		//Don't over-complicate

		//Saving
		private string currentDocumentPath = null;
		private bool currentDocumentPreviouslySaved;
		private bool changesMade = true;

		public EditorForm()
        {
            InitializeComponent();

			//Setup core
			tilesets = new List<Tileset>();
			TilePalette = new List<Tile>();
			tileSwatches = new ImageList();
			cam = new Camera();
			currentDocumentPreviouslySaved = false;

			//Setup a blank map and draw the canvas (First ever run)
			////NEW MAP DIALOG GOES HERE!!! Always ask the user for map settings upon first launch

			map = new Map(cols, rows, tilewidth, tileheight)	//Default starting map
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

		public void Clear()
		{
			map = new Map(cols, rows, tilewidth, tileheight);
			tilesets = new List<Tileset>();
			TilePalette = new List<Tile>();
			tileSwatches = new ImageList();
			cam = new Camera();
			currentDocumentPreviouslySaved = false;
			DrawCanvas();
		}

		#region New
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
				map.NewMap(cols, rows, tilewidth, tileheight);
				DrawCanvas();
			}

		}
		private void newMapToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var NewMapDialog = new NewMapDialog();

			NewMapDialog.ShowDialog();
		}

		#endregion

		#region Open
		//To LOAD a pkrMapEditor "document"....
		//- Load all the individual tiles into List<Tile> TilePalette
		//- Load in a new map
		//- Check new loaded map data is good
		//- Check if the current document has been saved yet
		//- Clear all tiles in TilePalette
		//- Clear the current map
		//- Redraw TilePalette
		//- Redraw map
		private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "pkr Map Files (*.map)|*.map|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string loadFileName = openFileDialog.FileName;

				//Load in the new map
				IFormatter formatter = new BinaryFormatter();
				Deserializeitem(loadFileName, formatter);

				//Check new map data is good

				//Check if the current document has been saved yet
				if (currentDocumentPath != null)
				{
					//PromptToSave();
					var dlgResult = MessageBox.Show("Save changes before loading in the new map?", "Open map...", MessageBoxButtons.YesNoCancel);
					if (dlgResult == DialogResult.Yes)
					{
						Save();
					}
					else if (dlgResult == DialogResult.No)
					{
						/////////////////////ASDFASDFASDF
					}
					else if (dlgResult == DialogResult.Cancel)
					{

					}
				}
            }
        }
		void PromptToSave()
		{
			//Prompt for user to save
			
		}
		public void Deserializeitem(string fileName, IFormatter formatter)
		{
			FileStream fs = new FileStream(fileName, FileMode.Open);

			//tilesets = (List<Tileset>)formatter.Deserialize(fs);
			map = (Map)formatter.Deserialize(fs);
			TilePalette = (List<Tile>)formatter.Deserialize(fs);

			fs.Close();
			DrawCanvas();
		}
		#endregion

		#region Save
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
		//To save a pkrMapEditor "document"...
		//1. Save all the individual tiles in List<Tile> TilePalette
		//2. Save the map which includes references to it's own tiles
		private void Save()
		{
			if (currentDocumentPath != null)    //ie. the current work has already been previously saved to a file
			{
				//Save as normal
				currentDocumentPreviouslySaved = true;	//Important to set saved flag
			}
			else 
			//if (!currentDocumentPreviouslySaved)
			{
				SaveAs();
			}
		}
		private void SaveAs()
		{
			//Calls the save dialog and prompts user for a new save file            
			SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "pkr Map Files (*.map)|*.map|All Files (*.*)|*.*";

			//If user pressed ok and file is valid
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
				string saveFileName = saveFileDialog.FileName;
				currentDocumentPath = saveFileName;	changesMade = false;
				IFormatter formatter = new BinaryFormatter();
				SerializeItem(saveFileName, formatter);

				//FileStream fs = new FileStream(saveFileName, FileMode.Create);
				//BinaryFormatter bf = new BinaryFormatter();
				//SaveObject saveMe = new SaveObject(map, tilesets);              //Get save object
				//bf.Serialize(fs, saveMe);
				//fs.Close();
            }
			changesMade = false;
			//currentDocumentPrekviouslySaved = true;  //Important to set saved flag
		}
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
		public void SerializeItem(string fileName, IFormatter formatter)
		{
			FileStream fs = new FileStream(fileName, FileMode.Create);

			//Need to serialize in order
			formatter.Serialize(fs, map);
			formatter.Serialize(fs, TilePalette);

			fs.Close();
		}

		#endregion

		#region Cut/Copy/Paste
		private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
		#endregion

		#region View
		private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }
        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }
		#endregion

		#region TilePalette
		private void AddTilesButton_Click(object sender, EventArgs e)
		{
			TilesetLoaderForm tileSetLoadForm = new TilesetLoaderForm();

			if (tileSetLoadForm.ShowDialog(this) == DialogResult.OK) 
			{
				//Load in new tiles from the tileset

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

		#endregion

		#region CanvasEdit
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
				onCamPan = true;
				camDragStart = new Point(e.X + cam.X, e.Y + cam.Y);

				///DEBUG
				statusStrip.Items[2].Text = "Drag start: " + camDragStart;
			}

			////Canvas Drag and Drop
			if (e.Button == MouseButtons.Right)
			{
				//dragPhase = DragPhase.Begun;
				onTileDrag = true;

				//Get the tile at cursor if any
				draggedTile = map.FindTile(new Point(e.X + cam.X, e.Y + cam.Y));

				if (draggedTile == null)
					onTileDrag = false; //A valid tile wasn't found at cursor
				else
					UseWaitCursor = true;
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
			if (onCamPan)
			{
				//"Move" camera
				PanCamera(e);
			}

			//////Drag and Drop
			//if (onTileDrag)
			////if (dragPhase == DragPhase.Dragging)
			//{
			//	//Tile "in transit"
			//	Application.UseWaitCursor = true;
			//}

			///DEBUG
			statusStrip.Items[0].Text = "Map Coords: " + (e.X+cam.X) + ", " + (e.Y+cam.Y);
			statusStrip.Items[1].Text = "Map Tile Index: " + map.PosToIndex(e.X+cam.X, e.Y+cam.Y);
			statusStrip.Items[2].Text = "UseWaitCursor: " + UseWaitCursor;
			//statusStrip.Items[2].Text = "Drag phase: " + onTileDrag;
		}

		private void Canvas_MouseUp(object sender, MouseEventArgs e)
		{
			//Clear all mouse states
			onPaint = false;
			onCamPan = false;

			////Canvas Drag and drop
			onTileDrag = false;
			if (draggedTile != null)
			{
				//Get the drop location on the map
				var dropMapIDX = map.PosToIndex(e.X + cam.X, e.Y + cam.Y);

				//"Pickup" the tile
				map.Tiles[draggedTile.MapIDX.X, draggedTile.MapIDX.Y] = null;

				//"Drop" the tile
				map.Tiles[dropMapIDX.X, dropMapIDX.Y] = draggedTile;
				DrawCanvas();

				//Change cursor (feedback for the user)
				Application.UseWaitCursor = false;
			}
		}

		private void PanCamera(MouseEventArgs me)
		{
			//Set the new camera position
			cam.X = camDragStart.X - me.X;
			cam.Y = camDragStart.Y - me.Y;
			DrawCanvas();
		}

		private void PaintTile(MouseEventArgs me)
		{
			selectedTile = GetSelectedTile(out int selectedIndex);

			var mouseMapIDX = map.PosToIndex(me.X + cam.X, me.Y + cam.Y);

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
						selectedTile.MapIDX = mouseMapIDX;
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
		private bool MouseWithinMapBounds(Point mouseMapIDX)
		{
			return (Enumerable.Range(0, map.Tiles.GetLength(0)).Contains(mouseMapIDX.X) &&
				Enumerable.Range(0, map.Tiles.GetLength(1)).Contains(mouseMapIDX.Y));
		}

		private void DrawCanvas()
		{
			/// NOTE: Take notice of camera offsets!

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
				g.DrawLine(pen, 0 - cam.X, y - cam.Y, map.Width - cam.X, y - cam.Y);
			}
			g.DrawLine(pen, 0 - cam.X, map.Height - cam.Y, map.Width - cam.X, map.Height - cam.Y);  //Grid border of map
																									//Horizontals
			for (int x = 0; x < map.Width; x += map.TileWidth)
			{
				g.DrawLine(pen, x - cam.X, 0 - cam.Y, x - cam.X, map.Height - cam.Y);
			}
			g.DrawLine(pen, map.Width - cam.X, 0 - cam.Y, map.Width - cam.X, map.Height - cam.Y);   //Grid border of map

			//// Draw the tiles ////
			//Go through the map
			for (int row = 0; row < map.Tiles.GetLength(0); row++)
			{
				for (int col = 0; col < map.Tiles.GetLength(1); col++)
				{
					//Draw tile if available
					if (map.Tiles[row, col] != null)
					{
						g.DrawImage(map.Tiles[row, col].Image, row * map.TileWidth - cam.X, col * map.TileHeight - cam.Y);
					}
				}
			}

			//Finished drawing
			g.Dispose();

			//Update the display box
			pbCanvas.Image = map.Bitmap;
		}
		#endregion

		#region Help
		private void HelpToolStripButton_Click(object sender, EventArgs e)
		{
			//Open user manual
		}
		private void UserManualToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//Open user manual
		}
		#endregion

		#region Exit
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
		#endregion


		#region Drag/Drop
		private void lvTilePalette_MouseDown(object sender, MouseEventArgs e)
		{
			if (selectedTile != null)
			{
				lvTilePalette.DoDragDrop(selectedTile, DragDropEffects.Copy);
			}
		}

		private void EditorForm_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(Tile)))
			{
				e.Effect = DragDropEffects.Copy;
			}
		}
		private void EditorForm_DragDrop(object sender, DragEventArgs e)
		{
			//Drop (Paint) the tile onto the canvas at cursor's location
			//e.x

			e.Data.GetData(typeof(Tile));
		}

		private void pbCanvas_DragEnter(object sender, DragEventArgs e)
		{

		}
		private void pbCanvas_DragDrop(object sender, DragEventArgs e)
		{

		}
		#endregion


	}
}
