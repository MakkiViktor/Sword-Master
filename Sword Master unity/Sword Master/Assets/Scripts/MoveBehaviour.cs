using System.Collections;
using System.Collections.Generic;
using ConstsEnums;
using UnityEngine;

public class MoveBehaviour : StateMachineBehaviour {
    public float startMoveSensivity = 0.25f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (Mathf.Abs(animator.GetFloat(AnimatorParameters.MoveX)) > startMoveSensivity || Mathf.Abs(animator.GetFloat(AnimatorParameters.MoveY)) > startMoveSensivity)
            animator.SetInteger(AnimatorParameters.AnimationState, (int) AnimationStates.MOVE);
        else if (Mathf.Abs(animator.GetFloat(AnimatorParameters.MoveX)) <= startMoveSensivity && Mathf.Abs(animator.GetFloat(AnimatorParameters.MoveY)) <= startMoveSensivity)
            animator.SetInteger(AnimatorParameters.AnimationState, (int)AnimationStates.IDLE);
    }

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//	animator.SetInteger ("AnimationState", (int)AnimationStates.VOID);
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
