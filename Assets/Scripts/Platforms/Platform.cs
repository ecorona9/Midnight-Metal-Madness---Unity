using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Start is called before the first frame update

    PlatformEffector2D effector;
    [SerializeField] float waitTime;


    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float movy = Input.GetAxisRaw("Vertical");

        if(Input.GetKeyUp(KeyCode.S)) {
            waitTime = 0.0025f;
        }

        if(Input.GetKey(KeyCode.S)){
            if(waitTime <= 0) {
                effector.rotationalOffset = 180f;
                waitTime = 0.5f;
            }
            else {
                waitTime -= Time.deltaTime;
            }
        }
        else{
            effector.rotationalOffset = 0;
        }

        // if(Input.GetKey(KeyCode.W)) {
        //     effector.rotationalOffset = 0;
        // }
    }
}
