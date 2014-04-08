using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject dog_wrapper;
	public GameObject dog;
    // keep track of the program entered by the player
    // need to pass in a length
//    public Program program;

	// Level and stack data
	Level level;
	Vector3 target;

	// Playback settings
	float speed = 2;

	// Use this for initialization
	void Start () {
		target = dog_wrapper.transform.position;
		dog = dog_wrapper.transform.Find ("Player").gameObject;
//		level = LevelManager.levels[0];
        // need to pass in a program of some sort
//        program = new Program();
	}

	// Eventually, these will be the actual ui buttons.
	void OnGUI() {
		int dir_index = ((Properties) dog_wrapper.GetComponent("Properties")).direction;
		int[] dir = Properties.directions [dir_index];
		if (GUI.Button(new Rect(20, 20, 70, 40),"0_idle")){
			dog.animation.wrapMode= WrapMode.Loop;
			dog.animation.CrossFade("0_idle");
		}
		if (GUI.Button(new Rect(90, 20, 70, 40),"1_Walk")){
			dog.animation.wrapMode= WrapMode.Loop;
			dog.animation.CrossFade("1_Walk");
			target = dog_wrapper.transform.position + new Vector3(dir[0],0,dir[1]);
		}
		if (GUI.Button(new Rect(160, 20, 70, 40),"2_Run")){
			dog.animation.wrapMode= WrapMode.Loop;
			dog.animation.CrossFade("2_Run");
			target = dog_wrapper.transform.position + new Vector3(dir[0],0,dir[1]);
		}
		if (GUI.Button(new Rect(230, 20, 70, 40),"3_Jump")){
			dog.animation.wrapMode= WrapMode.Loop;
			dog.animation.CrossFade("3_Jump");
		}
		if (GUI.Button(new Rect(300, 20, 70, 40),"4_Attack")){
			dog.animation.wrapMode= WrapMode.Loop;
			dog.animation.CrossFade("4_Attack");
		}
		if (GUI.Button(new Rect(370, 20, 70, 40),"5_Pain")){
			dog.animation.wrapMode= WrapMode.Loop;
			dog.animation.CrossFade("5_Pain");
		} 
		if (GUI.Button(new Rect(440, 20, 70, 40),"6_Dead")){
			dog.animation.wrapMode= WrapMode.Loop;
			dog.animation.CrossFade("6_Dead");
		}	    
	}

	// Update is called once per frame
	void Update () {
		// The step size is equal to speed times frame time.
		var step = speed * Time.deltaTime;

		// Current action is done. 
		if(dog_wrapper.transform.position.Equals(target)) {
			dog.animation.CrossFade("0_idle");
			// Load next action from program
//            Instruction nextAction = program.getNext(bot);

			// Make sure action is valid

		} else { // A move is being played.
			// Continue playing the move

			// If moving in a direction
			dog.animation["2_Run"].speed = speed/2;
			dog_wrapper.transform.position = Vector3.MoveTowards (dog_wrapper.transform.position, target, step);

			// If eating 

		}
	}
}
