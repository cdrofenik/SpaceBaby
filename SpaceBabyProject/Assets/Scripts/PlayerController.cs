using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.UpArrow)) {
			rigidbody2D.AddForce(new Vector2(0,10));
		}

		if (Input.GetKey (KeyCode.DownArrow)) {
			rigidbody2D.AddForce(new Vector2(0,-10));
		}
	}
}
