using UnityEngine;

namespace StackFall.StateMachineBehaviors
{
	public class FadeBehavior : StateMachineBehaviour
	{
		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			Destroy(animator.gameObject, stateInfo.length);
		}
	}
}
