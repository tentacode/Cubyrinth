using UnityEngine;
using System.Collections;

public class DebugController : MonoBehaviour
{
	public bool debugActive;

	[Header("Debug rotation")]
	public SliceRotator slice1;
	public KeyCode slice1AnticlockwiseKey;
	public KeyCode slice1ClockwiseKey;
	public SliceRotator slice2;
	public KeyCode slice2AnticlockwiseKey;
	public KeyCode slice2ClockwiseKey;
	public SliceRotator slice3;
	public KeyCode slice3AnticlockwiseKey;
	public KeyCode slice3ClockwiseKey;

	[Header("Debug doors")]
	public DoorMover door1;
	public KeyCode door1ToggleKey;
	public DoorMover door2;
	public KeyCode door2ToggleKey;
	public DoorMover door3;
	public KeyCode door3ToggleKey;
	public DoorMover door4;
	public KeyCode door4ToggleKey;

	void Update()
	{
		if (!debugActive) {
			return;
		}

		if (Input.GetKeyUp(slice1AnticlockwiseKey)) {
			slice1.Rotate(SliceRotator.RotationDirection.Anticlockwise);
		}

		if (Input.GetKeyUp(slice1ClockwiseKey)) {
			slice1.Rotate(SliceRotator.RotationDirection.Clockwise);
		}

		if (Input.GetKeyUp(slice2AnticlockwiseKey)) {
			slice2.Rotate(SliceRotator.RotationDirection.Anticlockwise);
		}

		if (Input.GetKeyUp(slice2ClockwiseKey)) {
			slice2.Rotate(SliceRotator.RotationDirection.Clockwise);
		}

		if (Input.GetKeyUp(slice3AnticlockwiseKey)) {
			slice3.Rotate(SliceRotator.RotationDirection.Anticlockwise);
		}

		if (Input.GetKeyUp(slice3ClockwiseKey)) {
			slice3.Rotate(SliceRotator.RotationDirection.Clockwise);
		}

		if (Input.GetKeyUp(door1ToggleKey)) {
			ToggleDoor(door1);
		}

		if (Input.GetKeyUp(door2ToggleKey)) {
			ToggleDoor(door2);
		}

		if (Input.GetKeyUp(door3ToggleKey)) {
			ToggleDoor(door3);
		}

		if (Input.GetKeyUp(door4ToggleKey)) {
			ToggleDoor(door4);
		}
	}

	void ToggleDoor(DoorMover door)
	{
		if (door.doorState == DoorMover.DoorState.Idle) {
			door.DropDoor();
		} else if (door.doorState == DoorMover.DoorState.Fallen) {
			door.ResetDoor();
		}
	}
}
