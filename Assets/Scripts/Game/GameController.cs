using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    public enum GameState {Title, Play, GameOver};
    public GameState state = GameState.Title;

    void Awake ()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

	void Update ()
    {
        if (state == GameState.Title && Input.anyKey)
        {
            GameObject.Find("FadeToBlack").GetComponent<FaderToBlack>().FadeToCallback(InitGame, 3.0f);
        }

	    if (Input.GetButtonUp("Cancel"))
        {
            Application.Quit();
        }
	}

    void InitGame()
    {
        state = GameState.Play;
        GameObject.Find("GameTitle").SetActive(false);
    }
}
