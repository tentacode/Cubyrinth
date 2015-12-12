using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
	public GameObject globalCamera;
	public GameObject playerCamera;
	public KeyCode switchCameraKey;
	public Image crosshair;

	void Awake()
	{
		playerCamera.SetActive(false);
		Cursor.visible = false;
	}

	void Update ()
	{
		if (Input.GetKeyDown(switchCameraKey)) {
			ToggleCamera();
		}

		if (Input.GetButtonDown("Fire1") && IsFpsCamera()) {
			RaycastHit hit;

			Vector3 middleScreenPosition = new Vector3(Screen.width / 2, Screen.height / 2, 0);
			Ray ray = GameObject.Find("FirstPersonCharacter").GetComponent<Camera>().ScreenPointToRay(middleScreenPosition);
			if (Physics.Raycast(ray, out hit)) {
				if (hit.collider.tag == "RotationButton") {
					hit.collider.gameObject.GetComponent<ButtonRotateSlice>().OnClick();
				}
			}
		}
	}

	bool IsFpsCamera()
	{
		return !globalCamera.activeSelf;
	}

	void ToggleCamera()
	{
		if (!IsFpsCamera()) {
			globalCamera.SetActive(false);
			playerCamera.SetActive(true);
			crosshair.enabled = true;
		} else {
			globalCamera.SetActive(true);
			playerCamera.SetActive(false);
			crosshair.enabled = false;
		}
	}
}
