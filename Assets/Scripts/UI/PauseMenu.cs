
/* Summary:
 * 
 * This script has the contains functions for the Pause Canvas
 * 
 */
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Animator pause_menu;

    public void HidePauseMenu()
    {
        pause_menu.SetTrigger("HidePauseMenu");
    }

    public void ShowPauseMenu()
    {
        pause_menu.SetTrigger("ShowPauseMenu");
    }

    
}
