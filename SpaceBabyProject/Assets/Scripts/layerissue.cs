using UnityEngine;
using System.Collections;

public class layerissue : MonoBehaviour {

	public TrailRenderer trail;

	void Start () {
		trail.sortingLayerName = "background";
		trail.sortingOrder = 2;
	
	}
}
