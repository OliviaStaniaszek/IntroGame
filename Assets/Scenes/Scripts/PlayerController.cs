using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Vector2 moveValue;
    public float speed;
    private int count; //count number of pick-ups collected

    void Start(){
        count = 0;
    }
    
    void OnMove(InputValue value)
    {
        moveValue=value.Get<Vector2>();
    }

    // Update is called once per frame
    void FixedUpdate () {

        Vector3 movement = new Vector3 ( moveValue.x , 0.0f, moveValue.y);
        GetComponent < Rigidbody >().AddForce ( movement*speed*Time.fixedDeltaTime);

    }

    void OnTriggerEnter(Collider other){ //calls when object collides, passes in object collided with
        if(other.gameObject.tag == "PickUp"){ //check tag of collided object
            other.gameObject.SetActive(false); // if it was a pickup, deactivate the object
            count += 1;
        }
    }

}
