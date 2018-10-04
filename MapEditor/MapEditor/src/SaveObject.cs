using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor
{
	class SaveObject
	//Consolidated object that is easy to save
	{
		public Map map;
		public List<Tileset> tilesets;
		//public List<Tile> tilePalette;
		//public ImageList tileSwatches;
		
		public SaveObject(Map map, List<Tileset> tilesets)
		{
			this.map = map;
			this.tilesets = tilesets;
		}
	}
}
