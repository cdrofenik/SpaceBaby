using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float jetpackForce = 15.0f;

    bool jetpackActive = false;

    // Use this for initialization
    void Start () {
    
    }
    
    // Update is called once per frame
    void FixedUpdate () {
        if (Input.GetKey (KeyCode.UpArrow)) {
            jetpackActive = true;
        }

        if (jetpackActive)
        {
            rigidbody2D.AddForce(new Vector2(0, jetpackForce));
            jetpackActive = false;
        }
    }
}
