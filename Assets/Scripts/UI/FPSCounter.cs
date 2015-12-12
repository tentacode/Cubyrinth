using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour {
    private Text text;
    private float nextCheck = 0;

    public float checkInterval;
    
	void Start ()
    {
        text = GetComponent<Text>();
	}
	
	void Update ()
    {
        if (Time.time < nextCheck)
        {
            return;
        }

        var fps = 1.0 / Time.deltaTime;
        text.text = fps.ToString();
        nextCheck = Time.time + checkInterval;
	}
}
