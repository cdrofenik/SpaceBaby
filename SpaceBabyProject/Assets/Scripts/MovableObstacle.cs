using UnityEngine;
using System.Collections;

public class MovableObstacle : MonoBehaviour {

	private bool _isCreated = false;
	private Vector2 _constantVector = new Vector2 (-1.5f, 0.0f);

	public float speed = 0.2f;
	public int objectId;

	// Use this for initialization
	void Start()
	{
		Physics.IgnoreLayerCollision(gameObject.layer, 11);
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (!_isCreated)
		{
			transform.position = new Vector3(11.1f, Random.Range(-3.2f, 3.2f)); //Create random position
			rigidbody2D.AddForce(_constantVector); //Add force so the obstacle moves
			_isCreated = true; //Now movable obstacle is created
		}
	}

	
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "PlayerContact")
		{
			//Player looses a life
			rigidbody2D.velocity = Vector2.zero;
			_isCreated = false;
		}
		else if (collision.gameObject.tag == "FrameEdgeCollider")
		{
			//Player looses a life
			rigidbody2D.velocity = Vector2.zero;
			_isCreated = false;
		}
	}
}
