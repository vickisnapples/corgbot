using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Properties : MonoBehaviour {

	public int direction;
	public static List<int[]> directions = new List<int[]> ();

	void Start() {
		directions.Add(new int[] { 0, 1 });
		directions.Add(new int[] { 1, 0 });
		directions.Add(new int[] { 0, -1 });
		directions.Add(new int[] { -1, 0 });
	}

}
