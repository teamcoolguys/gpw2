using System;
using System.Text.RegularExpressions;
using System.IO;

public class DTileMap {
	
	/*protected class DTile {
		bool isWalkable = false;
		int tileGraphicId = 0;
		string name = "Unknown";
	}
	
	List<DTile> tileTypes;
	
	void InitTiles() {
		tileType[1].name = "Floor";
		tileType[1].isWalkable = true;
		tileType[1].tileGraphicId = 1;
		tileType[1].damagePerTurn = 0;
	}*/
	
	int size_x;
	int size_y;
	
	public int[] map_data;

	public void readFile(string file)
	{
		FileInfo theSourceFile = null;
		StreamReader reader = null;
		
		theSourceFile = new FileInfo (file);
		reader = theSourceFile.OpenText ();
		
		string text = reader.ReadToEnd ();

		string [] lines = Regex.Split (text, "/r/n");
		
		map_data = new int[(this.size_x * this.size_y)];
		for (int i = 0; i < lines.Length; ++i) 
		{
			string[] stringsOfLine = Regex.Split (lines[i], " ");
		
			map_data[i] = int.Parse (stringsOfLine[i]);
		}
	}

	
	public enum TileType
	{			//0
	 Floor,		//1
	 Wall,		//2
	 Player,
	 AI,
	 Unknown
	};
	public DTileMap(int sizex, int sizey, string file)
	{

		this.size_x = sizex;
		this.size_y = sizey;

		//readFile (file);
		
		map_data = new int[sizex*sizey];
		for(int y=0;y<sizey;y++)
		{
			for(int x=0;x<sizex;x++) 
			{
				map_data[(y*size_x)+x] = 0;
			}
		}
		map_data[9]=1;
	}

	public int GetTileAt(int x, int y)
	{
		return map_data[(y*size_x)+x];
	}
	public void SetTileAt(int x, int y)
	{
		map_data[(y*size_x)+x]=0;
		return;
	}
	public float GetTilePosition(int x, int y)
	{
		float position = 0.0f;
		return position;
	}
}
