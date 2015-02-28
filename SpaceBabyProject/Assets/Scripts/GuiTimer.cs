using UnityEngine;
using System.Collections;

public class GuiTimer : MonoBehaviour
{
    //private Time timer;
    private float startTime;
    private GUIText timeComponent;

    // Use this for initialization
    void Start()
    {
        startTime = Time.time;
        timeComponent = this.GetComponent<GUIText>();
    }

    // Update is called once per frame
    void Update()
    {
        var guiTime = Time.time - startTime;
        var minutes = guiTime / 60;
        var seconds = guiTime % 60;
        var fraction = (guiTime * 100) % 100;

        timeComponent.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, fraction);
    }

    public void ResetTime()
    {
        startTime = Time.time;
    }
}
