using UnityEngine;
using System.Collections;

public class MovableObstacle : MonoBehaviour {

    private bool _isCreated = false;

    public float speed = 0.2f;

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
            rigidbody2D.AddForce(new Vector2(-100, 0)); //Add force so the obstacle moves
            _isCreated = true; //Now movable obstacle is created
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(11.1f, Random.Range(-3.2f, 3.2f)); //Create random position
        }
    }

    
}
