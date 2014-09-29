using UnityEngine;
using System.Collections;

public class Meteor : MonoBehaviour {

	//Viewport boundingbox
	private float minX = -8.7f;
	private float minY = -4.4f;
	private float maxX = 8.7f;
	private float maxY = 4.4f;

	private bool _isCreated = false;

	public float speed = 0.2f;

	private bool IsInViewport(Vector3 point)
	{
		if (point.x > minX && point.x < maxX && point.y > minY && point.y < maxY)
			return true;
		else
			return false;
	}

	private Vector3 GenerateVectorForRange(float xmin, float ymin, float xmax, float ymax)
	{
		Vector3 meteorTemporaryPosition = new Vector3(Random.Range (xmin, xmax), Random.Range (ymin, ymax));
		while (IsInViewport(meteorTemporaryPosition))
		{
			meteorTemporaryPosition = new Vector3(Random.Range (xmin, xmax), Random.Range (ymin, ymax));
		}
		return meteorTemporaryPosition;
	}

	void FixedUpdate ()
	{
		if (!_isCreated) {
			transform.position = new Vector3(11.1f, Random.Range (-3.2f, 3.2f)); //Create random position
			rigidbody2D.AddForce(new Vector2(-100, 0)); //Add force so the meteor moves

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

