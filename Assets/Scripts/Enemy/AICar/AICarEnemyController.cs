using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MidnightMetalMadness
{
    public class AICarEnemyController : MonoBehaviour
    {
        [SerializeField] private int speed;
        [SerializeField] private GameObject hitbox;

        // AICar is an enemy that stays dormant until the player 
        // crosses its detection box, then the car revs up and tries
        // to run over the player. 
        private bool is_awake;
        private bool is_revving;

        public bool isAwake()
        {
            if (is_awake)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void enableHitbox()
        {
            hitbox.SetActive(false);

        }


        // Start is called before the first frame update
        void Start()
        {
            is_awake = false;
            is_revving = false;

            
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
