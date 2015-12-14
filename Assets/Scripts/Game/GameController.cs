using UnityEngine;
using System.Collections;
using UnityEngine.VR;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public enum GameState {Title, Play, GameOver};
    public GameState state = GameState.Title;
    public float VRScale = 1.0f;
    private float startTime;
    private float completedTime;

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

    void Restart()
    {
        Application.LoadLevel(Application.loadedLevelName);
    }

	void Update ()
    {
        if (state == GameState.Title && Input.anyKey)
        {
            GameObject.Find("UI/FadeToBlack").GetComponent<FaderToBlack>().FadeToCallback(InitGame, 5.0f);
        }

        if (state == GameState.GameOver && Input.GetButtonUp("Fire1"))
        {
            GameObject.Find("UI/FadeToBlack").GetComponent<FaderToBlack>().FadeToCallback(Restart, 0.5f);
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
        GameObject.Find("GameTitle").GetComponent<Text>().text = "C U B Y R I N T H";
    }

    void InitGame()
    {
        state = GameState.Play;
        GameObject.Find("GameTitle").GetComponent<Text>().enabled = false;
        GameObject.Find("CameraController").GetComponent<CameraController>().ToggleCamera();
        startTime = Time.time;
        GameObject.Find("PlayerUI/PlayerFadeToBlack").GetComponent<FaderToBlack>().fadeState = FaderToBlack.FadeState.FadeOut;
    }

    public void EndGame()
    {
        completedTime = Mathf.Floor(Time.time - startTime);
        GameObject.Find("PlayerUI/PlayerFadeToBlack").GetComponent<FaderToBlack>().FadeToCallback(DisplayCredits, 5.0f);
    }

    void DisplayCredits()
    {
        state = GameState.GameOver;
        float completedMinutes = Mathf.Floor(completedTime / 60);
        float completedHours = Mathf.Floor(completedMinutes / 60);
        
        string chrono = completedHours.ToString() + ":" + (completedMinutes % 60).ToString().PadLeft(2, '0') + ":" + (completedTime % 60).ToString().PadLeft(2, '0');

        GameObject.Find("CameraController").GetComponent<CameraController>().ToggleCamera();
        GameObject.Find("GameTitle").GetComponent<Text>().enabled = true;
        GameObject.Find("GameTitle").GetComponent<Text>().fontSize = 200;
        GameObject.Find("GameTitle").GetComponent<Text>().text = "T  H  E    E  N  D\ntime "+ chrono +"\nby V&G";
        GameObject.Find("UI/FadeToBlack").GetComponent<FaderToBlack>().FadeOut(1.0f);
    }
}
