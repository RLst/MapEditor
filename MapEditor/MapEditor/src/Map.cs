using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor
{
    class Map
    {
		//This class can be created with nothing in it

		
		private List<Tile> tiles;
		private uint width;
		private uint height;

		public Map(uint width, uint height)
		{
			this.width = width;
			this.height = height;
		}

		public void AddTile(Tile tile)
		{

		}

		public void RemoveTile(int tileIDX)
		{

		}

		public void ResetMap(uint width, uint height)
		{

		}

	}
}
