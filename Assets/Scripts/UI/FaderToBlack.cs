using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FaderToBlack : MonoBehaviour
{
	public delegate void FadeCallback();
	private float fadeDelay = 1.0f;
    
	private FadeCallback fadedCallback;
	private Image image;

	public enum FadeState {Idle, FadeIn, FadeOut};
	public FadeState fadeState = FadeState.Idle;

	void Start()
	{
		image = GetComponent<Image>();
	}

	public void FadeToCallback(FadeCallback callback, float duration)
	{
        fadeDelay = duration;
		fadeState = FadeState.FadeIn;
		fadedCallback = callback;
	}

	void Update()
	{
		if (fadeState == FadeState.FadeIn) {
			FadeIn();
		} else if (fadeState == FadeState.FadeOut) {
			FadeOut();
		}
	}

	void FadeIn()
	{
		image.color = new Color(1, 1, 1, Mathf.Clamp01(image.color.a + Time.deltaTime / fadeDelay));
		if (image.color.a == 1.0f) {
			fadedCallback();
			fadeState = FadeState.FadeOut;
		}
	}

	void FadeOut()
	{
		image.color = new Color(1, 1, 1, Mathf.Clamp01(image.color.a - Time.deltaTime / fadeDelay));
		if (image.color.a == 0.0f) {
			fadeState = FadeState.Idle;
		}
	}
}
