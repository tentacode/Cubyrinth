using UnityEngine;
using System.Collections;
using UnityEngine.VR;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public enum GameState {Title, Play, GameOver};
    public GameState state = GameState.Title;
    public float VRScale = 1.0f;

    void Awake ()
    {
        VRSettings.renderScale = VRScale;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Start()
    {
        if (state == GameState.Title)
        {
            InitTitle();
        }
        else
        {
            InitTitle();
            InitGame();
        }
    }

	void Update ()
    {
        if (state == GameState.Title && Input.anyKey)
        {
            GameObject.Find("UI/FadeToBlack").GetComponent<FaderToBlack>().FadeToCallback(InitGame, 5.0f);
        }

	    if (Input.GetButtonUp("Cancel"))
        {
            Application.Quit();
        }
    }

    void InitTitle()
    {
        state = GameState.Title;
        GameObject.Find("GameTitle").GetComponent<Text>().enabled = true;
    }

    void InitGame()
    {
        state = GameState.Play;
        GameObject.Find("GameTitle").GetComponent<Text>().enabled = false;
        GameObject.Find("CameraController").GetComponent<CameraController>().ToggleCamera();
        GameObject.Find("PlayerUI/PlayerFadeToBlack").GetComponent<FaderToBlack>().fadeState = FaderToBlack.FadeState.FadeOut;
    }
}
