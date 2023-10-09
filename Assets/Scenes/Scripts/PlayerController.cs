using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public Vector2 moveValue;
    public float speed;
    private int count; //count number of pick-ups collected
    private int numPickups = 4;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI winText;

    public TextMeshProUGUI playerPosition;
    public TextMeshProUGUI playerVelocity;
    public TextMeshProUGUI pickupDistance;

    public Vector3 pos;


    void Start() {
        count = 0;
        winText.text = "";
        SetCountText();
    }


    void OnMove(InputValue value)
    {
        moveValue=value.Get<Vector2>();
        pos = transform.position;
        playerPosition.text = "Position: " + pos.ToString();
    }

    // Update is called once per frame
    void FixedUpdate() {

        Vector3 movement = new Vector3 ( moveValue.x , 0.0f, moveValue.y);
        GetComponent < Rigidbody >().AddForce ( movement*speed*Time.fixedDeltaTime);

    }

    void OnTriggerEnter(Collider other){ //calls when object collides, passes in object collided with
        if(other.gameObject.tag == "PickUp"){ //check tag of collided object
            other.gameObject.SetActive(false); // if it was a pickup, deactivate the object
            count ++;
            SetCountText();
        }
    }
private void SetCountText() {
    scoreText.text = "Score: " + count.ToString();
    if(count >= numPickups){
        winText.text = "You win!";
    }
}
}
