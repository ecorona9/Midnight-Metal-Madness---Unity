using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MidnightMetalMadness
{
    public class AICarEnemyController : MonoBehaviour
    {
        [SerializeField] private int speed;
        [SerializeField] private GameObject hitbox;
        [SerializeField] private float rev_time_init;
        private float rev_time;

        // AICar is an enemy that stays dormant until the player 
        // crosses its detection box, then the car revs up and tries
        // to run over the player. 

        // States of the car
        private bool is_awake; // 
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
            hitbox.SetActive(true);

        }

        public void WakeUp()
        {
            // Function to be called when Detector object detects the player.
            is_revving = true;
            //Debug.Log("Wakeup is accesssed");
        }


        // Regardless of direction add to its x vector regardless. 
        public void driveForward()
        {

            int newspeed;

            if (transform.localScale.x >= 0)
            {
                newspeed = speed;
            }
            else
            {
                newspeed = -1 * speed;
            }

            transform.position = transform.position + new Vector3((newspeed*.01f), 0, 0);



        }

        public void revvingState()
        {
            // If time allows, there will be a short animation of the car shaking up and down.
            // But otherwise the car will stay stationary for x amount of time. 
            //Debug.Log("RevvingState Working...");
            

            if(rev_time > 0f)
            {
                rev_time -= (1 * Time.deltaTime);
                //Debug.Log("Countdown! = " + rev_time);

            }
            else
            {
                is_awake = true;
                is_revving = false;
                //Debug.Log("Car is now going to MOVE!");
                enableHitbox();
                rev_time = rev_time_init;
            }



        }


        // Start is called before the first frame update
        void Start()
        {
            is_awake = false;
            is_revving = false;
            hitbox.SetActive(false);
            rev_time = rev_time_init;
            //Debug.Log("AICarEnemy Active. Hitbox Should be deact");


        }

        // Update is called once per frame
        void FixedUpdate()
        {

            if(is_awake)
            {
                driveForward();
            }

            if(is_revving)
            {
                revvingState();
            }


           
        }
        private void OnBecameInvisible()
        {
            if(is_awake)
            {
                Debug.Log("Destroyed");
                gameObject.SetActive(false);
            }
        }
        
    }
}
