using UnityEngine;
using System.Collections;

public class AnimateShadow : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				float scale = (Mathf.Sin (Time.time) * .01f);
				transform.localScale = new Vector3 (.07f, .07f, .07f) + new Vector3 (scale, scale, scale);
		}
}

