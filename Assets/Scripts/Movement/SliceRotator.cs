using UnityEngine;
using System.Collections;

public class SliceRotator : MonoBehaviour
{
	[Header("Animation")]
	public float cycleDuration;
	public iTween.EaseType rotationEasing;
	public float shakeAmount;

	[Header("Debug input")]
	public KeyCode rotateAnticlockwiseKey;
	public KeyCode rotateClockwiseKey;

	private bool isRotating = false;
	enum RotationDirection{Anticlockwise = -1, Clockwise = 1}

	void Update()
	{
		if (Input.GetKeyUp(rotateAnticlockwiseKey)) {
			Rotate(RotationDirection.Anticlockwise);
		} else if (Input.GetKeyUp(rotateClockwiseKey)) {
			Rotate(RotationDirection.Clockwise);
		}
	}

	void Rotate(RotationDirection rotationDirection)
	{
		if (isRotating) {
			return;
		}

		isRotating = true;

		GetComponent<AudioSource>().Play();

		iTween.RotateBy(gameObject, iTween.Hash(
			"x", (int)rotationDirection * 0.25, 
			"easeType", rotationEasing, 
			"time", cycleDuration,
			"oncomplete", "RotationEnded",
			"space", Space.Self
		));

		iTween.ShakePosition(gameObject, iTween.Hash(
			"x", shakeAmount,
			"y", shakeAmount,
			"z", 0,
			"time", cycleDuration
		));
	}

	void RotationEnded()
	{
		isRotating = false;
	}
}
