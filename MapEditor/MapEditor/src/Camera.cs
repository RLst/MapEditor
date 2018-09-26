namespace MapEditor
{
    public class Camera
	{
		//Position
		public int X { get; set; }
		public int Y { get; set; }

		//Zoom
		public float Zoom { get; set; }

		public Camera(int x = 0, int y = 0)		//Defaults to 0,0
		{
			X = x;
			Y = y;
		}
		
	}
}
