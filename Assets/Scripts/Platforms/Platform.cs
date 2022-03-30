using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{ 
    [SerializeField] private float waitTime;

    private PlatformEffector2D effector;
 
    private void Awake()
    {
        effector = GetComponent<PlatformEffector2D>();
    }
    
    private void Update()
    {
        float movy = Input.GetAxisRaw("Vertical");
        if(Input.GetKeyUp(KeyCode.S)) {
            waitTime = 0.0025f;
        }
        if(Input.GetKey(KeyCode.S)) {
            if(waitTime <= 0) {
                effector.rotationalOffset = 180f;
                waitTime = 0.5f;
            }
            else {
                waitTime -= Time.deltaTime;
            }
        }
        else {
            effector.rotationalOffset = 0;
        }
    }
}
