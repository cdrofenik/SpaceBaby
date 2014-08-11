using UnityEngine;
using System.Collections;

public class Meteor : MonoBehaviour {

	//Viewport boundingbox
	private float minX = -7.5f;
	private float minY = -5.0f;
	private float maxX = 9.0f;
	private float maxY = 4.0f;

	private Vector3 _position = new Vector3 (-9, 6, 0);
	private Vector3 _velocity = new Vector3 (1, -1, 0);
	private bool _isCreated = false;

	public float speed = 1.5f;


//	public GameObject prefab;

//	void Start() {
//		Vector3 position = new Vector3(Random.Range(-10.0F, 10.0F), 0, Random.Range(-10.0F, 10.0F));
//		Instantiate(prefab, position, Quaternion.identity) as GameObject;
//	}

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

	void GeneratePosition()
	{
		int sector = Random.Range (0, 3);
		switch (sector)
		{
		case 0:
			_position = GenerateVectorForRange(0, 0, 11, 7);
			break;
		case 1:
			_position = GenerateVectorForRange(0, 0, 11, -7);
			break;
		case 2:
			_position = GenerateVectorForRange(-11, -7, 0, 0);
			break;
		case 3:
			_position = GenerateVectorForRange(-11, -7, 0, 0);
			break;
		}
	}

	void GenerateVelocity()
	{
		var playerObject = GameObject.FindWithTag ("Player");
		_velocity = playerObject.gameObject.transform.position - _position;
	}

	void Update ()
	{
		if (Input.GetKey(KeyCode.A))
		{
			_isCreated = false;
		}

		if (!_isCreated) {
			GeneratePosition();
			GenerateVelocity();

			transform.position = _position;	//generate position
			speed = Random.Range (1.5f, 2.0f);
			_isCreated = true;
		}
		transform.position += _velocity * speed * Time.deltaTime;
	}
}

