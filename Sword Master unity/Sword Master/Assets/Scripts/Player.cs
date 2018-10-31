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

		InputHandler ();
	}

	public void InputHandler ()
	{
        /*
		Vector3 Move = new Vector3();
		Move.x += Time.deltaTime * speed * Input.GetAxis ("Left Stick X");
		Move.z += Time.deltaTime * speed * Input.GetAxis ("Left Stick Y");
		transform.position += Move;
        */

        animator.SetFloat("Move X", Input.GetAxis("Left Stick X"));
        animator.SetFloat("Move Y", -Input.GetAxis("Left Stick Y"));


        if (Input.GetButtonDown ("O Button")) {
			stanceIndex = (stanceIndex + 1) % stanceDataBase.stanceList.Count;
			animationSwitcher.switchAnimationClips (stanceDataBase.stanceList [stanceIndex]);
			Debug.Log ("Switched to Index: " + stanceIndex);
		} 

		if (Input.GetButtonDown ("X Button")) {
			animator.SetInteger ("AnimationState", 1);	
		}
	}

}
