using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	void Update ()
    {
	    if (Input.GetButtonUp("Cancel"))
        {
            Application.Quit();
        }
	}
}
