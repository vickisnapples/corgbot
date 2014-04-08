using UnityEngine;
using System.Collections;

public class AnimateSize : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float scale = (Mathf.Sin (Time.time) * .1f);
		transform.localScale = new Vector3 (.8f, .8f, .8f) + new Vector3 (scale, scale, scale);
	}
}
