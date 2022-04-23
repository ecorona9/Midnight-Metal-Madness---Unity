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
            
            Debug.Log("Car Start!");
        }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
