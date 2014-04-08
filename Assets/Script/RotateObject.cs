using UnityEngine;
using System.Collections;

public class RotateObject : MonoBehaviour
{
	public Vector3 rotation;
	void Update ()
	{
	    transform.Rotate(rotation * Time.deltaTime);
	}
}
