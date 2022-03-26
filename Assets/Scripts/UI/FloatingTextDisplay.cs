/*
 * Summary:
 * 
 * FloatingTextDisplay controls the text
 * that is being displayed and destroys the object 
 * after it spawns
 * 
 */
using UnityEngine;

namespace MidnightMetalMadness.UI
{
    public class FloatingTextDisplay : MonoBehaviour
    {
        [SerializeField] private TextMesh text_str;

        private void Start()
        {
            Destroy(gameObject, 0.3f);
        }

        public void SetText(string str, Color text_color)
        {
            text_str.color = text_color;
            text_str.text = str;
        }
    }
}
