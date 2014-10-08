using UnityEngine;
using System.Collections;

public class BottleCounter : MonoBehaviour {

	public int bottleCounter;

	// Use this for initialization
	void Start () {
		bottleCounter = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void BottlePickedUp()
	{
		bottleCounter++;
	}

	public int GetBottleCount()
	{
		return bottleCounter;
	}
}
