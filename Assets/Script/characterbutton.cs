using UnityEngine;
using System.Collections;

public class characterbutton : MonoBehaviour {

	public GameObject frog;

	
	
	private Rect FpsRect ;
	private string frpString;
	
	private GameObject instanceObj;
	public GameObject[] gameObjArray=new GameObject[9];
	public AnimationClip[] AniList  = new AnimationClip[9];
	
	float minimum = 2.0f;
	float maximum = 50.0f;
	float touchNum = 0f;
	string touchDirection ="forward"; 
	private GameObject CORGI_base;
	
	// Use this for initialization
	void Start () {
		
		//frog.animation["dragon_03_ani01"].blendMode=AnimationBlendMode.Blend;
		//frog.animation["dragon_03_ani02"].blendMode=AnimationBlendMode.Blend;
		//Debug.Log(frog.GetComponent("dragon_03_ani01"));
		
		//Instantiate(gameObjArray[0], gameObjArray[0].transform.position, gameObjArray[0].transform.rotation);
	}
	
 void OnGUI() {
	  if (GUI.Button(new Rect(20, 20, 70, 40),"0_idle")){
		 frog.animation.wrapMode= WrapMode.Loop;
			frog.animation.CrossFade("0_idle");
	  }
	    if (GUI.Button(new Rect(90, 20, 70, 40),"1_Walk")){
		  frog.animation.wrapMode= WrapMode.Loop;
			frog.animation.CrossFade("1_Walk");
	  }
		  if (GUI.Button(new Rect(160, 20, 70, 40),"2_Run")){
		  frog.animation.wrapMode= WrapMode.Loop;
			frog.animation.CrossFade("2_Run");
	  }
		  if (GUI.Button(new Rect(230, 20, 70, 40),"3_Jump")){
		  frog.animation.wrapMode= WrapMode.Loop;
			frog.animation.CrossFade("3_Jump");
	  }
		  if (GUI.Button(new Rect(300, 20, 70, 40),"4_Attack")){
		  frog.animation.wrapMode= WrapMode.Loop;
			frog.animation.CrossFade("4_Attack");
	  }
	    if (GUI.Button(new Rect(370, 20, 70, 40),"5_Pain")){
		  frog.animation.wrapMode= WrapMode.Loop;
			frog.animation.CrossFade("5_Pain");
	  } 
		if (GUI.Button(new Rect(440, 20, 70, 40),"6_Dead")){

			frog.animation.wrapMode= WrapMode.Loop;
			frog.animation.CrossFade("6_Dead");


		}
	    

 }

	// Update is called once per frame
	void Update () {
		
		//if(Input.GetMouseButtonDown(0)){
		
			//touchNum++;
			//touchDirection="forward";
		 // transform.position = new Vector3(0, 0,Mathf.Lerp(minimum, maximum, Time.time));
			//Debug.Log("touchNum=="+touchNum);
		//}
		/*
		if(touchDirection=="forward"){
			if(Input.touchCount>){
				touchDirection="back";
			}
		}
	*/
		 
		//transform.position = Vector3(Mathf.Lerp(minimum, maximum, Time.time), 0, 0);
	if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
		//frog.transform.Rotate(Vector3.up * Time.deltaTime*30);
	}
	
}
