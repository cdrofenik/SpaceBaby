using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public int bottlesCollected = 0;
    public int maxBottles = 10;

    public GUIText scoreBoard;
    public GUIText time;
    public bool activateBoost = false;

    private Vector2 acceleratorVector = new Vector2(-6.5f, 0.0f);

	// Use this for initialization
	void Start () {
        scoreBoard.text = "Left " + maxBottles;
	}
	
	// Update is called once per frame
	void Update () {
        //Bottles and movable obsicles now move a lot faster
    }

    void boostObjects()
    {
        var movableObjs = GameObject.FindObjectsOfType<MovableObstacle>();
        foreach (MovableObstacle movObj in movableObjs)
        {
            movObj.constantForceVector = acceleratorVector;
        }

        var bottles = GameObject.FindObjectsOfType<BabyBottle>();
        foreach (BabyBottle bttl in bottles)
        {
            bttl.constantForceVector = acceleratorVector;
        }
    }

    void ApplyForceToMovableObjects(Vector2 frc)
    {
        var movableObjs = GameObject.FindObjectsOfType<MovableObstacle>();
        foreach (MovableObstacle movObj in movableObjs)
        {
			movObj.constantForceVector = frc;
        }
    }

    void ApplyForceToBottles(Vector2 frc)
    {
        var bottles = GameObject.FindObjectsOfType<BabyBottle>();
        foreach (BabyBottle bttl in bottles)
        {
			bttl.constantForceVector = frc;
        }
    }

    void removeBoostFromObjects()
    {
        ApplyForceToBottles(new Vector2(-1.5f, 0.0f));
        ApplyForceToMovableObjects(new Vector2(-1.5f, 0.0f));
    }

    //Triggered when bottle colides with the player
    public void BottleCollected()
    {
        Debug.Log("BottleCollected");
        bottlesCollected++;
        boostObjects();
        scoreBoard.text = "Left " + (maxBottles - bottlesCollected).ToString();
    }

    public void ObsticleCollide()
    {
        Debug.Log("Collided with obsticle");
        removeBoostFromObjects();
        activateBoost = false;

    }
}
