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

	
	public enum TileType
	{
	 Unknown,	//0
	 Floor,		//1
	 Wall,		//2
	 Player,
	 AI

	};
	public DTileMap(int sizex, int sizey)
	{

		this.size_x = sizex;
		this.size_y = sizey;
		
		map_data = new int[sizex*sizey];
		for(int y=0;y<sizey;y++)
		{
			for(int x=0;x<sizex;x++) 
			{
				map_data[(y*size_x)+x] = 1;
			}
		}
		map_data[9]=0;
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
}
