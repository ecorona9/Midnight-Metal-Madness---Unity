/* Summary:
 * ButtonSoundFX plays the button sfx on button press
 */
using UnityEngine;

namespace MidnightMetalMadness.UI
{
    public class ButtonSoundFX : StateMachineBehaviour
    {
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            AudioManager.instance.PlayButtonSFX();
        }
    }
}
