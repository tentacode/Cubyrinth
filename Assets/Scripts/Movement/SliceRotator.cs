using UnityEngine;
using System.Collections;

public class SliceRotator : MonoBehaviour
{
	[Header("Animation")]
	public float cycleDuration;
	public iTween.EaseType rotationEasing;
	public float shakeAmount;
	public string rotationAxis = "x";

	private bool isRotating = false;
	public enum RotationDirection{Anticlockwise = -1, Clockwise = 1}

	public void Rotate(RotationDirection rotationDirection)
	{
		if (isRotating) {
			return;
		}

		isRotating = true;

		GetComponent<AudioSource>().Play();

		iTween.RotateBy(gameObject, iTween.Hash(
			rotationAxis, (int)rotationDirection * 0.25, 
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
