using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxAnim : StateMachineBehaviour 
{
	public static bool done = false;
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if(stateInfo.IsName("boxMove5sec"))
		{
			done = true;
		}
     }
}
