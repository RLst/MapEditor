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
		/// <summary>
		/// Essential objects required to save
		/// ----
		/// map
		/// tilesets
		/// TilePalette
		/// tileSwatches
		/// </summary>

		//Used to update title bar 
		public string appName;

		//Initial/Previously used values
		//<S>
		int rows = 8;
		int cols = 8;
		int tilewidth = 64;
		int tileheight = 64;

		//Flags
		private string currentDocumentPath = null;
		//private bool changesMade = false;
		private bool ChangesMade { get; set; } = false;
		private bool onCamPan = false;
		private bool onPaint = false;       //If the mouse has been pressed 
		//private bool onTileDrag = false;

		//Camera
		private static Camera cam;
		Point camDragStart;

		//Drag n Drop
		//private Tile draggedTile;

		//Map <S>
		public static Map map = null;        //Holds the actual map using actual tiles; pbCanvas displays the actual map

		//Tilesets <S> - Concrete location for Tiles to reference off
		public static List<Tileset> tilesets;

		//Tile palette
		private Tile selectedTile = null;
		public static List<Tile> TilePalette { get; set; }      //<S> //Holds the ACTUAL tiles in the Tile Palette
		private ImageList tileSwatches;							//Holds the thumbnails for lvTilePalette (List View)


		public EditorForm()
        {
            InitializeComponent();

			appName = this.Text;

			NewPKRMap(cols, rows, tilewidth, tileheight);
		}

		public void NewPKRMap(int cols, int rows, int tileWidth, int tileHeight)
		{
			currentDocumentPath = null;

			//Setup core
			tilesets = new List<Tileset>();
			TilePalette = new List<Tile>();
			tileSwatches = new ImageList();
			cam = new Camera();

			//Setup a blank map and draw the canvas (First ever run)
			////NEW MAP DIALOG GOES HERE!!! Always ask the user for map settings upon first launch

			map = new Map(cols, rows, tileWidth, tileHeight)    //Default starting map
			{
				Bitmap = new Bitmap(pbCanvas.Width, pbCanvas.Height)
			};
			DrawCanvas();

			//Flags and titlebar
			ChangesMade = false; currentDocumentPath = null;
			UpdateWindowTitlebar();

			//Setup tilePalette listview
			lvTilePalette.LargeImageList = tileSwatches;
			lvTilePalette.LargeImageList.ImageSize = new Size(86, 86);
			lvTilePalette.LargeImageList.ColorDepth = ColorDepth.Depth24Bit;

			///DEBUG
			statusStrip.Items.Add("Item 2");
			statusStrip.Items.Add("Item 3");
		}

		public void UpdateWindowTitlebar()
		{
			string changeFlag = (ChangesMade) ? "*" : null;

			string documentPath;
			if (currentDocumentPath != null)
			{
				FileInfo fi = new FileInfo(currentDocumentPath);
				documentPath = fi.Name + " - ";
			}
			else
			{
				documentPath = "Untitled Map - ";
			}
			Text = changeFlag + documentPath + appName;
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
				if (ChangesMade)
				//if (currentDocumentPath != null)	//ie. current document has been previously saved
				{
					var dlgResult = MessageBox.Show("Save changes before creating a new map?", "New map...", MessageBoxButtons.YesNoCancel);
					if (dlgResult == DialogResult.Cancel)
					{
						//Break out and cancel
						return;
					}
					else if (dlgResult == DialogResult.Yes)
					{
						//Save first
						Save();
					}
				}

				//Save map parameters for next time
				rows = NewMapDialog.Rows;
				cols = NewMapDialog.Cols;
				tilewidth = NewMapDialog.TileWidth;
				tileheight = NewMapDialog.TileHeight;

				//Continue with creating a new map once 
				NewPKRMap(cols, rows, tilewidth, tileheight);
			}
		}
		#endregion

		#region Open
		private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "pkr Map Files (*.pmap)|*.pmap|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
				//Prompt user to save if neccessary
				if (ChangesMade)
				{
					var dlgResult = MessageBox.Show("Save changes before loading in a new map?", "Open map...", MessageBoxButtons.YesNoCancel);
					if (dlgResult == DialogResult.Cancel)
					{
						//Break out and cancel
						return;
					}
					else if (dlgResult == DialogResult.Yes)
					{
						//Save first
						Save();
					}
					//else user chose No so continue...
				}

				string loadFileName = openFileDialog.FileName;

				//Load in the new map
				IFormatter formatter = new BinaryFormatter();
				//NewPKRMap(cols, rows, tilewidth, tileheight);			//Reset map
				Deserializeitem(loadFileName, formatter);
				UpdateTilePaletteItems();
				DrawCanvas();       //Redraw canvas

				//Flags and Titlebars
				ChangesMade = false; currentDocumentPath = loadFileName;
				UpdateWindowTitlebar();
            }
        }
		public void Deserializeitem(string fileName, IFormatter formatter)
		{
			FileStream fs = new FileStream(fileName, FileMode.Open);

			map = formatter.Deserialize(fs) as Map;
			tilesets = formatter.Deserialize(fs) as List<Tileset>;
			TilePalette = formatter.Deserialize(fs) as List<Tile>;
			//tileSwatches = formatter.Deserialize(fs) as ImageList;

			fs.Close();
		}
		#endregion

		#region Save
		private void Save()
		{
			if (currentDocumentPath != null)	//ie. Current work has not been saved previously...
			{
				IFormatter formatter = new BinaryFormatter();
				SerializeItem(currentDocumentPath, formatter);

				//Flags and Titlebars
				ChangesMade = false;
				UpdateWindowTitlebar();
			}
			else 
			{
				SaveAs();
			}
		}
		private void SaveAs()
		{
			//Calls the save dialog and prompts user for a new save file            
			SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "pkr Map Files (*.pmap)|*.pmap|All Files (*.*)|*.*";

			//If user pressed ok and file is valid
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
				string saveFileName = saveFileDialog.FileName;
				IFormatter formatter = new BinaryFormatter();
				SerializeItem(saveFileName, formatter);

				//Flags and Titlebars
				currentDocumentPath = saveFileName;	ChangesMade = false;
				UpdateWindowTitlebar();
            }
		}
		public void SerializeItem(string fileName, IFormatter formatter)
		{
			FileStream fs = new FileStream(fileName, FileMode.Create);

			//Need to serialize in order
			formatter.Serialize(fs, map);
			formatter.Serialize(fs, tilesets);
			formatter.Serialize(fs, TilePalette);
			//formatter.Serialize(fs, tileSwatches);	//Apprently can't serialise ImageLists

			fs.Close();
		}
		private void SaveToolStripButton_Click(object sender, EventArgs e)
		{
			Save();
		}
		private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Save();
		}
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
			SaveAs();
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

		#region Drag/Drop
		private void lvTilePalette_MouseDown(object sender, MouseEventArgs e)
		{
			//Only start drag and drop if there is currently a selected tile
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
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}
		private void EditorForm_DragDrop(object sender, DragEventArgs e)
		{
			//Retrieve the tile to be dropped
			Tile dragDropTile = e.Data.GetData(typeof(Tile)) as Tile;

			//Get map's IDX at cursor's location
			var mapIDX = map.CanvasPosToIndex(43 + e.X + cam.X, 110 + e.Y + cam.Y);

			//Drop (Paint) the tile onto the canvas at cursor's location
			if (isMouseWithinMapBounds(mapIDX))
			{
				map.Tiles[mapIDX.X, mapIDX.Y] = dragDropTile;
				//Redraw canvas
				DrawCanvas();
			}
			else
			{
				//throw new System.Exception("Tile dropped out of bounds of map!");
			}
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
			TilesetLoaderForm tileSetLoadForm = new TilesetLoaderForm(tilewidth, tileheight);

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

			lvTilePalette.Clear();

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

		#region Canvas
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

			//////Canvas Drag and Drop
			//if (e.Button == MouseButtons.Right)
			//{
			//	//dragPhase = DragPhase.Begun;
			//	onTileDrag = true;

			//	//Get the tile at cursor if any
			//	draggedTile = map.FindTile(new Point(e.X + cam.X, e.Y + cam.Y));

			//	if (draggedTile == null)
			//		onTileDrag = false; //A valid tile wasn't found at cursor
			//	else
			//		UseWaitCursor = true;
			//}
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


			///DEBUG
			statusStrip.Items[0].Text = "Map Coords: " + (e.X+cam.X) + ", " + (e.Y+cam.Y);
			statusStrip.Items[1].Text = "Map Tile Index: " + map.CanvasPosToIndex(e.X+cam.X, e.Y+cam.Y);
			//statusStrip.Items[2].Text = "Drag phase: " + onTileDrag;
		}

		private void Canvas_MouseUp(object sender, MouseEventArgs e)
		{
			//Clear all mouse states
			onPaint = false;
			onCamPan = false;

			////Canvas Drag and drop
			//onTileDrag = false;
			//if (draggedTile != null)
			//{
			//	//Get the drop location on the map
			//	var dropMapIDX = map.CanvasPosToIndex(e.X + cam.X, e.Y + cam.Y);

			//	//"Pickup" the tile
			//	map.Tiles[draggedTile.MapIDX.X, draggedTile.MapIDX.Y] = null;

			//	//"Drop" the tile
			//	map.Tiles[dropMapIDX.X, dropMapIDX.Y] = draggedTile;
			//	DrawCanvas();
			//	ChangesMade = true;

			//	//Change cursor (feedback for the user)
			//	Application.UseWaitCursor = false;
			//}
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

			var mouseMapIDX = map.CanvasPosToIndex(me.X + cam.X, me.Y + cam.Y);

			//Mouse has to be within bounds of map
			if (isMouseWithinMapBounds(mouseMapIDX))
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

						//Flags and Titlebars
						ChangesMade = true;
						UpdateWindowTitlebar();
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

		private bool isMouseWithinMapBounds(Point mouseMapIDX)
		{
			return (Enumerable.Range(0, map.Tiles.GetLength(0)).Contains(mouseMapIDX.X) &&
				Enumerable.Range(0, map.Tiles.GetLength(1)).Contains(mouseMapIDX.Y));
		}

		private void DrawCanvas()
		{
			////NOTE: Take notice of camera offsets!

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
			if (!PromptSave(e))
			{
				Application.Exit();
			}
		}
		private void EditorForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = PromptSave(e);
		}

		private bool PromptSave(EventArgs e)
		{
			//Prompt user to save if neccessary
			if (ChangesMade)
			{
				var dlgResult = MessageBox.Show("Save changes before quitting?", "Quit...", MessageBoxButtons.YesNoCancel);
				if (dlgResult == DialogResult.Cancel)
				{
					//Break out
					return true;	//Cancel Close
				}
				else if (dlgResult == DialogResult.Yes)
				{
					//Save first
					Save();
				}
				//else user chose No so continue...
			}
			return false;	//Proceed with close
		}
		#endregion


	}
}
