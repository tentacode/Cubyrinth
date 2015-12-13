using UnityEngine;
using System.Collections;

public class DoorMover : MonoBehaviour {

	public Transform dropPoint;
	public float translateDuration;
	public iTween.EaseType translationEasing;

	public enum DoorState {Idle, Falling, Fallen};
	public DoorState doorState = DoorState.Idle;
	public Transform transitionPoint;
	public Transform startPoint;

	public void DropDoor ()
	{
		if (doorState != DoorState.Idle) {
			return;
		}

		Translate(startPoint.position, dropPoint.position, "DoorFallen");
		Rotate(dropPoint.rotation.eulerAngles);
	}

	public void ResetDoor ()
	{
		if (doorState != DoorState.Fallen) {
			return;
		}

		Translate(dropPoint.position, startPoint.position, "DoorIdled");
		Rotate(startPoint.rotation.eulerAngles);
	}

	void Translate(Vector3 origin, Vector3 destination, string callback)
	{
		doorState = DoorState.Falling;

		Vector3[] paths;
		paths = new Vector3[2];
		paths[0] = transitionPoint.position;
		paths[1] = destination;

		iTween.MoveTo(gameObject, iTween.Hash(
			"path", paths,
			"position", destination,
			"easeType", translationEasing, 
			"time", translateDuration,
			"oncomplete", callback
		));
	}

	void Rotate(Vector3 destination)
	{
		iTween.RotateTo(gameObject, destination, translateDuration);
	}

	void DoorFallen()
	{
		doorState = DoorState.Fallen;
	}

	void DoorIdled()
	{
		doorState = DoorState.Idle;
	}
}
