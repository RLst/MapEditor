using System;
using System.Windows.Forms;

namespace MapEditor
{
    static class Program
    {
		//static public Map map;							//The one and only map

		//static private List<Tileset> tilesets;			//Can hold many tilesets
  //      //OR...
  //      static private List<Tile> availableTiles;                //All the tiles in the list box 


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new EditorForm());       //Run the main editor
        }
    }
}
