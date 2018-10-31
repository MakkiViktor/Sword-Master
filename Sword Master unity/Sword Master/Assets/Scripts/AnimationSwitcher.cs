using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSwitcher {
	public Animator animator;
	private AnimatorOverrideController animatorOverrideController;
	private AnimationClipOverrides animationClipOverrides;

	private class AnimationClipOverrides : List<KeyValuePair <AnimationClip, AnimationClip>>{
		public AnimationClipOverrides(int capacity):base(capacity){}

		public AnimationClip this[string name]{
			get{ return this.Find (x => x.Key.name.Equals (name)).Value; }
			set{ 
				int index = this.FindIndex (x => x.Key.name.Equals (name));
				if (index != -1)
					this [index] = new KeyValuePair<AnimationClip, AnimationClip> (this [index].Key, value);
				else
					throw new KeyNotFoundException ("animationclip with this name not found");
			} 
		}
	}
	public void Init(Animator animator = null){
		if (animator != null)
			this.animator = animator;
		if (this.animator == null)
			throw new MissingReferenceException ("Animator is not set");
		animatorOverrideController = new AnimatorOverrideController (animator.runtimeAnimatorController);
		this.animator.runtimeAnimatorController = animatorOverrideController;

		animationClipOverrides = new AnimationClipOverrides (this.animatorOverrideController.overridesCount);
		animatorOverrideController.GetOverrides (animationClipOverrides);
	}

	public void switchAnimationClips(StanceData stance){
		foreach (var data in stance.stanceAnimation) {
			animationClipOverrides [data.animation.name] = data.animation;
		}
		animatorOverrideController.ApplyOverrides (animationClipOverrides);
	}
}
