using System.Collections;
using System.Collections.Generic;
using ConstsEnums;
using UnityEngine;

public class Player : MonoBehaviour {
	//Test, ha lesz animáció, majd át kell írni
	public float speed;
	public StanceDatabase stanceDataBase;
	public int stanceIndex = 0;
	private AnimationSwitcher animationSwitcher;
	private Animator animator;


	void Start(){
		animator = GetComponent<Animator> ();
		animationSwitcher = new AnimationSwitcher ();
		animationSwitcher.Init (animator);
	}
		
	void Update () {
		Vector3 Move = new Vector3();
		Move.x += Time.deltaTime * speed * Input.GetAxis ("Horizontal");
		Move.z += Time.deltaTime * speed * Input.GetAxis ("Vertical");
		transform.position += Move;
		InputHandler ();

	}

	void InputHandler ()
	{
		if (Input.GetAxis ("SwitchStance") != 0) {
			stanceIndex = (stanceIndex + 1) % stanceDataBase.stanceList.Count;
			Debug.Log ("Switched to Index: " + stanceIndex);
			animationSwitcher.switchAnimationClips (stanceDataBase.stanceList [stanceIndex]);
			Debug.Log ("Switched to Index: " + stanceIndex);
		} 

		if (Input.GetAxis ("Move") != 0) {
			animator.SetInteger ("AnimationState", 1);	
		}
	}

}
