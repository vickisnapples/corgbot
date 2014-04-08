using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GridManager: MonoBehaviour
{
	//following public variable is used to store the hex model prefab;
	//instantiate it by dragging the prefab on this variable using unity editor
	public GameObject Tile1;
	public GameObject Tile2;
	public GameObject Tile3;
	public GameObject Special;
	public GameObject Transporter;
	public GameObject Player;
	public Material lineMaterial;
	//next two variables can also be instantiated using unity editor
	public int gridWidth = 8;
	public int gridHeight = 8;
	
	//Tileagon tile width and height in game world
	private float tileWidth;
	private float tileHeight;
	private float tileDepth;

	void loadLevel(Level l)
	{
		// TODO(vshan) plop the level name into the UI
		GameObject tileGridGO = new GameObject("TileGrid");
		for (int y = 0; y < 8; y++)
		{
			for (int x = 0; x < 8; x++)
			{
				Debug.Log("y is " + y);
				Debug.Log("x is " + x);
				int depth = l.heightMap[7-x,y];
				for (int i = 0; i < l.heightMap[7-x,y]; i++)
				{
					GameObject t;
					if(i == depth-1)
					{
						if(l.featureMap[7-x,y] == 'b')
							t = (GameObject)Instantiate(Special);
						else if(l.featureMap[7-x,y] == 't')
							t = (GameObject)Instantiate(Transporter);
						else
							t = (GameObject)Instantiate(getPrefab(depth));

						// Put the player here
						char feature = l.featureMap[7-x,y];
						if(feature == '>')
						{
							Vector3 trans = calcWorldCoord(new Vector2(y, x), i);
							trans[1] += .6f;
							Properties properties = (Properties)Player.GetComponent("Properties");
							properties.direction = 1;
							Player.transform.position = trans;
							Player.transform.localEulerAngles = new Vector3(0,90,0);
						}
						// Put the player here
						if(feature == '<')
						{
							Vector3 trans = calcWorldCoord(new Vector2(y, x), i);
							trans[1] += .6f;
							Properties properties = (Properties)Player.GetComponent("Properties");
							properties.direction = 3;
							Player.transform.position = trans;
							Player.transform.localEulerAngles = new Vector3(0,-90,0);
						}
						// Put the player here
						if(feature == '^')
						{
							Vector3 trans = calcWorldCoord(new Vector2(y, x), i);
							trans[1] += .6f;
							Properties properties = (Properties)Player.GetComponent("Properties");
							properties.direction = 0;
							Player.transform.position = trans;
							Player.transform.localEulerAngles = new Vector3(0,0,0);
						}
						// Put the player here
						if(feature == 'v')
						{
							Vector3 trans = calcWorldCoord(new Vector2(y, x), i);
							trans[1] += .6f;
							Properties properties = (Properties)Player.GetComponent("Properties");
							properties.direction = 2;
							Player.transform.position = trans;
							Player.transform.localEulerAngles = new Vector3(0,180,0);
						}
						// Put the player here
                        // starting on a blue tile
						if(feature == 'w')
						{
							Vector3 trans = calcWorldCoord(new Vector2(y, x), i);
							trans[1] += .6f;
							Properties properties = (Properties)Player.GetComponent("Properties");
							properties.direction = 0;
							Player.transform.position = trans;
							Player.transform.localEulerAngles = new Vector3(0,0,0);
							t = (GameObject)Instantiate(Special);
						}
						// Put the player here
                        // starting on a blue tile
						if(feature == 'a')
						{
							Vector3 trans = calcWorldCoord(new Vector2(y, x), i);
							trans[1] += .6f;
							Properties properties = (Properties)Player.GetComponent("Properties");
							properties.direction = 3;
							Player.transform.position = trans;
							Player.transform.localEulerAngles = new Vector3(0,-90,0);
							t = (GameObject)Instantiate(Special);
						}
						// Put the player here
                        // starting on a blue tile
						if(feature == 's')
						{
							Vector3 trans = calcWorldCoord(new Vector2(y, x), i);
							trans[1] += .6f;
							Properties properties = (Properties)Player.GetComponent("Properties");
							properties.direction = 2;
							Player.transform.position = trans;
							Player.transform.localEulerAngles = new Vector3(0,180,0);
							t = (GameObject)Instantiate(Special);
						}
						// Put the player here
                        // starting on a blue tile
						if(feature == 'd')
						{
							Vector3 trans = calcWorldCoord(new Vector2(y, x), i);
							trans[1] += .6f;
							Properties properties = (Properties)Player.GetComponent("Properties");
							properties.direction = 1;
							Player.transform.position = trans;
							Player.transform.localEulerAngles = new Vector3(0,90,0);
							t = (GameObject)Instantiate(Special);
						}
					}
					else
						t = (GameObject)Instantiate(getPrefab(depth));

					//Current position in grid
					Vector2 gridPos = new Vector2(y, x);

					t.transform.position = calcWorldCoord(gridPos, i);
					t.transform.parent = tileGridGO.transform;
				}
			}
		}

		// Add the transport lines
		foreach (KeyValuePair<int[], int[]> entry in l.transportMap) {
			GameObject t = new GameObject();
			LineRenderer lineRenderer = (LineRenderer) t.AddComponent("LineRenderer");
			lineRenderer.material = new Material(lineMaterial);
			lineRenderer.SetColors(Color.white, Color.white);
			lineRenderer.SetWidth(0.2f,0.2f);
			lineRenderer.SetVertexCount(3);

			Vector3 start = calcWorldCoord (new Vector2(entry.Key[1], 7-entry.Key[0]), l.heightMap[entry.Key[1],entry.Key[0]]);
			lineRenderer.SetPosition(0, start);
			Vector3 end = calcWorldCoord (new Vector2(entry.Value[1], 7-entry.Value[0]), l.heightMap[entry.Key[1],entry.Key[0]]);
			lineRenderer.SetPosition(2, end);
			Vector3 mid = Vector3.Lerp(start, end, 0.5f);
			mid[1] = 3;
			lineRenderer.SetPosition(1, mid);
		}
	}

	//Get the appropriate tile for depth
	GameObject getPrefab(int depth)
	{
		if (depth == 1) {
			return Tile1;
		} else if (depth == 2) {
			return Tile2;
		} else
			return Tile3;
	}

	//Method to initialise Tile width and height
	void setSizes()
	{
		//renderer component attached to the Tile prefab is used to get the current width and height
		tileWidth = Tile1.renderer.bounds.size.x;
		tileHeight = Tile1.renderer.bounds.size.z;
		tileDepth = Tile1.renderer.bounds.size.y;
	}
	
	//Method to calculate the position of the first hexagon tile
	//The center of the hex grid is (0,0,0)
	Vector3 calcInitPos()
	{
		Vector3 initPos;
		//the initial position will be in the left upper corner
		 initPos = new Vector3(-tileWidth * gridWidth / 2f + tileWidth / 2, 0,
		                       gridHeight / 2f * tileHeight - tileHeight / 2);
//		initPos = new Vector3(0,0,0);
		
		return initPos;
	}
	
	//method used to convert hex grid coordinates to game world coordinates
	public Vector3 calcWorldCoord(Vector2 gridPos, int height)
	{
		//Position of the first tile
		Vector3 initPos = calcInitPos();
		
		float x = initPos.x + gridPos.x * tileWidth;
		float y = tileDepth;
		float z = initPos.z + gridPos.y * tileHeight;
		return new Vector3(x, y*height, z);
	}
	
	//Finally the method which initialises and positions all the tiles
	void createGrid()
	{
		Debug.Log ("at create, size is " + LevelManager.levels.Count);
		loadLevel (LevelManager.levels[0]);
//		for (float y = 0; y < gridHeight; y++)
//		{
//			for (float x = 0; x < gridWidth; x++)
//			{
//				//GameObject assigned to Tile public variable is cloned
//				GameObject t = (GameObject)Instantiate(Tile);
//				//Current position in grid
//				Vector2 gridPos = new Vector2(x, y);
//				t.transform.position = calcWorldCoord(gridPos);
//				t.transform.parent = tileGridGO.transform;
//			}
//		}
	}
	
	//The grid should be generated on game start
	void Start()
	{
		setSizes();
		createGrid();
	}

}
