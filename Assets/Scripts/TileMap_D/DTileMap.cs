using UnityEngine;
using System.Collections.Generic;

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
	
	int[,] map_data;

	
	public enum TileType
	{
	 Unknown,
	 Floor,
	 Wall,
	 Player,
	 AI

	};
	public DTileMap(int sizex, int sizey)
	{

		this.size_x = sizex;
		this.size_y = sizey;
		
		map_data = new int[sizex,sizey];
		
		for(int x=0;x<sizex;x++)
		{
			for(int y=0;y<sizey;y++) 
			{
				map_data[x,y] = 3;
			}
		}
		
	}
	

	
	public int GetTileAt(int x, int y) {
		return map_data[x,y];
	}


}
