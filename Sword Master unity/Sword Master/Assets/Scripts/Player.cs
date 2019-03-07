using System.Collections;
using System.Collections.Generic;
using ConstsEnums;
using UnityEngine;

public class Player : MonoBehaviour {
	//Test, ha lesz animáció, majd át kell írni
	public StanceDatabase stanceDataBase;
    public int stanceIndex = 0;
    public PlayerCamera camera;

    private InputHandler input;
    private AnimationSwitcher animationSwitcher;
	private Animator animator;


	void Start(){
        input = GetComponent<InputHandler>();
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

        //animator.SetFloat("Move X", Input.GetAxis(Controller.LeftStickX));
        //animator.SetFloat("Move Y", -Input.GetAxis(Controller.LeftStickY));
        animator.SetFloat(AnimatorParameters.MoveX, input.getAxis(InputSettings.MOVEX));
        animator.SetFloat(AnimatorParameters.MoveY, -input.getAxis(InputSettings.MOVEY));



        /*
        if (input.getButtonDown(InputSettings.SWITCH)) {
			stanceIndex = (stanceIndex + 1) % stanceDataBase.stanceList.Count;
			animationSwitcher.switchAnimationClips (stanceDataBase.stanceList [stanceIndex]);
			Debug.Log ("Switched to Index: " + stanceIndex);
		} 

		if (Input.GetButtonDown (Controller.XButton)) {
			animator.SetInteger ("AnimationState", (int) AnimationStates.IDLE);	
		}
        */
	}

}
