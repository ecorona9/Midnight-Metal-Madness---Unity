// SUMMARY:
// 
// Requires a collider2d component and the gameobject layer to be "Trigger"
//
using UnityEngine;

namespace MidnightMetalMadness.Entity.Interactables
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private VoidEventSO coin_channel;
        [SerializeField] private VoidEventSO score_channel;

        private void OnTriggerEnter2D()
        {
            coin_channel.RaiseEvent();
            score_channel.RaiseEvent();
            Destroy(transform.gameObject);
        }
    }
}
