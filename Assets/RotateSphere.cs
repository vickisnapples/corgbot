using UnityEngine;
using System.Collections;

public class RotateSphere : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	float rotationsPerMinute = 10.0f;
	// Update is called once per frame
	void Update () {
		transform.Rotate(0f,6.0f*rotationsPerMinute*Time.deltaTime,0f);
	}
}
