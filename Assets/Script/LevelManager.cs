using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;
using System;
using System.Collections.Generic;


public class Level
{
	public string name { get; set; }
	public int[,] heightMap { get; set; }
	public char[,] featureMap { get; set; }
	public Dictionary<int[],int[]> transportMap { get; set; }

	public Level(string n, int[,] h, char[,] f, Dictionary<int[],int[]> t)
	{
		name = n;
		// 2d array of grid heights
		heightMap = h;
		// 2d array of features
		featureMap = f;
		// Point map for transporters
		transportMap = t;
	}
	
	public void print()
	{
		Debug.Log ("Level name: " + name);
		Debug.Log ("Height map: ");
		for (int i = 0; i < heightMap.GetLength(0); i++) {
			string line = "";
			for (int j = 0; j < heightMap.GetLength(1); j++) {
				line += heightMap[i,j];
			}
			Debug.Log(line);
		}
		
		Debug.Log ("Feature map: ");
		for (int i = 0; i < heightMap.GetLength(0); i++) {
			string line = "";
			for (int j = 0; j < heightMap.GetLength(1); j++) {
				line += featureMap[i,j];
			}
			Debug.Log(line);
		}

		Debug.Log ("Transport map: ");
		foreach (KeyValuePair<int[], int[]> entry in transportMap) {
			Debug.Log ("Transport ("+entry.Key[0]+","+entry.Key[1]+") maps to ("+entry.Value[0]+","+entry.Value[1]+")");
		}
	}
}

public class LevelManager : MonoBehaviour
{
	public int levelHeight = 8;
	public int levelWidth = 8;
	public static List<Level> levels = new List<Level>();

	
	// Use this for initialization
	void Start ()
	{
		TextAsset levelData = Resources.Load("LevelData") as TextAsset;
		StringReader sr = new StringReader(levelData.text);
		using (sr)
		{
			string line;
			line = sr.ReadLine();

			while(line != null)
			{
				// Get the level name
				string name  = line;

				int[,] h = new int[levelHeight, levelWidth];

				// Get the level height map
				sr.ReadLine();
				for(int i = 0; i < levelHeight; i++)
				{
					line = sr.ReadLine();
					string[] row_values = line.Split((string[])null, System.StringSplitOptions.None);
					for(int j = 0; j < levelWidth; j++)
					{
						h[i,j] = int.Parse(row_values[j]);
					}
				}

				char[,] f = new char[levelHeight, levelWidth];

				// Get the level feature map
				sr.ReadLine();
				for(int i = 0; i < levelHeight; i++)
				{
					line = sr.ReadLine();
					string[] row_values = line.Split((string[])null, System.StringSplitOptions.None);
					for(int j = 0; j < levelWidth; j++)
					{
						f[i,j] = char.Parse(row_values[j]);
					}
				}

				sr.ReadLine();
				line = sr.ReadLine();
				Dictionary<int[], int[]> d = new Dictionary<int[], int[]>();
				while(line != "-")
				{
					string[] row_values = line.Split((string[])null, System.StringSplitOptions.None);
					int[] key = new int[2] {int.Parse (row_values[0]), int.Parse (row_values[1])};
					int[] val = new int[2] {int.Parse (row_values[2]), int.Parse (row_values[3])};
					d[key] = val;
					line = sr.ReadLine();
				}
				Level l = new Level(name, h, f, d);
				l.print();
				
				levels.Add(l);
				Debug.Log ("level added.");
				Debug.Log (levels.Count);

				line = sr.ReadLine();
			}
		}
	}

	// Update is called once per frame
	void Update ()
	{

	}
}

