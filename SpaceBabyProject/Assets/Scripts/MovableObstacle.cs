using UnityEngine;
using System.Collections;

public class MovableObstacle : MonoBehaviour {

    public bool isActive = false;
    public Vector2 creationRange = new Vector2(3.2f, -3.2f);
	public Vector2 constantForceVector = new Vector2(-1.5f, 0.0f);

    private GameManager gameManager;

	// Use this for initialization
	void Start()
	{
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		Physics.IgnoreLayerCollision(gameObject.layer, 11); //Ignore collision with MovableObstacle
	}

	// Update is called once per frame
	void FixedUpdate()
	{
        if (!isActive)
		{
            transform.position = new Vector3(11.1f, Random.Range(creationRange.y, creationRange.x)); //Create random position
			GetComponent<Rigidbody2D>().AddForce(constantForceVector); //Add force so the obstacle moves
            isActive = true; //Now movable obstacle is active
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "PlayerContact")
		{
			//Player looses a life
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            isActive = false;
            gameManager.ObsticleCollide();
		}
        else if (collision.gameObject.tag == "OutsideBoundary")
		{
			//Movable obstacle is out of range
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            isActive = false;
		}
	}
}
