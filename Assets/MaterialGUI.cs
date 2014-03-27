using UnityEngine;
using System.Collections;

public class MaterialGUI : MonoBehaviour
{
	public Renderer[] targets;
	private float backAlpha = 0.0f;
	private float lineAlpha = 1.0f;
	private float lineWidth = 0.05f;
	void OnGUI ()
	{
		GUILayout.BeginArea(new Rect(10,Screen.height-100,Screen.width-20,100));
		GUILayout.BeginHorizontal();
		GUILayout.Label("Line Width ("+lineWidth.ToString("0.0000")+")",GUILayout.Width(150));
		lineWidth = GUILayout.HorizontalSlider(lineWidth,0.0f,0.5f);
		GUILayout.EndHorizontal();
		GUILayout.BeginHorizontal();
		GUILayout.Label("Line Alpha ("+lineAlpha.ToString("0.0000")+")",GUILayout.Width(150));
		lineAlpha = GUILayout.HorizontalSlider(lineAlpha,0.0f,1.0f);
		GUILayout.EndHorizontal();
		GUILayout.BeginHorizontal();
		GUILayout.Label("Back Alpha ("+backAlpha.ToString("0.0000")+")",GUILayout.Width(150));
		backAlpha = GUILayout.HorizontalSlider(backAlpha,0.0f,1.0f);
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
	}
	void Update()
	{
		foreach(Renderer R in targets)
		{
			Color line = R.material.GetColor("_LineColor");
			Color back = R.material.GetColor("_GridColor");
			line.a = lineAlpha;
			back.a = backAlpha;
			R.material.SetColor("_LineColor",line);
			R.material.SetColor("_GridColor",back);
			R.material.SetFloat("_LineWidth",lineWidth);
		
		}
	}	
}
