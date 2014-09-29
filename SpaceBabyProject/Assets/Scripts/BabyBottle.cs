using UnityEngine;
using System.Collections;

public class BabyBottle : MonoBehaviour {
	
	private bool _isCreated = false;
	public float speed = 0.2f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!_isCreated) {
			transform.position = new Vector3(11.1f, Random.Range (-3.3f, 3.3f)); //Create random position
			rigidbody2D.AddForce(new Vector2(-150, 0)); //Add force so the meteor moves
			
			_isCreated = true; //Now meteor is created
		}
		
		if (_isCreated) {
		}
		
		
		if (Input.GetKey(KeyCode.A))
		{
			transform.position = new Vector3(11.1f, Random.Range (-3.2f, 3.2f)); //Create random position
		}
	}
}
