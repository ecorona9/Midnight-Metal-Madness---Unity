using UnityEngine;

namespace MidnightMetalMadness.Entity.Interactables
{
    public class EventAreaTrigger : MonoBehaviour
    {
        [SerializeField] private int id;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            EventAreaManager.instance.AwakeCops(collision.transform, id); 

            Destroy(gameObject);
        }
    }
}
