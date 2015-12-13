using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    void Awake ()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

	void Update ()
    {
	    if (Input.GetButtonUp("Cancel"))
        {
            Application.Quit();
        }
	}
}
