﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapEditor
{
    static class Program
    {
		static private Map map;							//The one and only map

		static private List<Tileset> tilesets;			//Can hold many tilesets
        //OR...
        static private List<Tile> tiles;                //All the tiles in the list box 


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
