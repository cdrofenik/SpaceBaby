using UnityEngine;
using System.Collections;

public class BabyBottle : MonoBehaviour {

    public bool isActive = false;
    public Vector2 creationRange = new Vector2(3.2f, -3.2f);
    public Vector2 constantForceVector = new Vector2(-1.5f, 0.0f);

    private GameManager gameManager;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
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
			//_bottleCounter.BottlePickedUp();
            gameManager.BottleCollected();
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            isActive = false;
		}
        else if (collision.gameObject.tag == "OutsideBoundary")
        {
            //Movable obstacle is out of range
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            isActive = false;
        }
	}
}
