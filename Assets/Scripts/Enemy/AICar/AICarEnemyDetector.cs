using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MidnightMetalMadness
{
    public class AICarEnemyDetector : MonoBehaviour
    {
        [SerializeField] private CapsuleCollider2D player_collider;

        [SerializeField] private AICarEnemyController controller;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if(col.CompareTag("Player"))
            {
                //Debug.Log("Turning On!!!");
                controller.WakeUp();
            }
            
            
        }
    }
}
