using System.Collections;
using System.Collections.Generic;
using ConstsEnums;
using UnityEngine;

public class Player : MonoBehaviour {
	//Test, ha lesz animáció, majd át kell írni
	public float speed;
	public StanceDatabase stanceDataBase;
	public int stanceIndex = 0;
    public PlayerCamera camera;

	private AnimationSwitcher animationSwitcher;
	private Animator animator;


	void Start(){
		animator = GetComponent<Animator> ();
		animationSwitcher = new AnimationSwitcher ();
		animationSwitcher.Init (animator);
	}
		
	void Update () {

		InputHandler ();
        transform.rotation = Quaternion.Euler(0, camera.getXRotation(), 0);
	}

	public void InputHandler ()
	{
        /*
		Vector3 Move = new Vector3();
		Move.x += Time.deltaTime * speed * Input.GetAxis ("Left Stick X");
		Move.z += Time.deltaTime * speed * Input.GetAxis ("Left Stick Y");
		transform.position += Move;
        */

        animator.SetFloat("Move X", Input.GetAxis(Controller.LeftStickX));
        animator.SetFloat("Move Y", -Input.GetAxis(Controller.LeftStickY));

        if (Input.GetButtonDown (Controller.OButton)) {
			stanceIndex = (stanceIndex + 1) % stanceDataBase.stanceList.Count;
			animationSwitcher.switchAnimationClips (stanceDataBase.stanceList [stanceIndex]);
			Debug.Log ("Switched to Index: " + stanceIndex);
		} 

		if (Input.GetButtonDown (Controller.XButton)) {
			animator.SetInteger ("AnimationState", (int) AnimationStates.RIGHTCUT);	
		}
	}

}
