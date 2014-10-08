﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float jetpackForce = 0.5f;
    public bool jetpackActive = false;

    GameObject jetpackSystem;

    IEnumerator SleepMethod()
    {
        yield return new WaitForSeconds(0.5f);
        jetpackSystem.GetComponent<ParticleSystem>().startSize = 0.25f;
        //jetpackSystem.GetComponent<ParticleSystem>().Stop();
        jetpackActive = false;
    }

    // Use this for initialization
    void Start () {
        jetpackSystem = GameObject.Find("JetpackFlames");
    }
    
    // Update is called once per frame
    void FixedUpdate () {
        if (Input.GetKey (KeyCode.UpArrow)) {
            jetpackActive = true;
            jetpackSystem.GetComponent<ParticleSystem>().startSize = 0.5f;
            //jetpackSystem.GetComponent<ParticleSystem>().Play();
        }

        if (jetpackActive)
        {
            rigidbody2D.AddForce(new Vector2(0, jetpackForce));
            StartCoroutine(SleepMethod());
        }

    }
}
