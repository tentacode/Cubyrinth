using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
	public GameObject globalCamera;
	public GameObject player;
    public Camera rayCamera;
	public KeyCode switchCameraKey;
	public Image crosshair;
	public float minDistanceRayHit = 2.5f;

	void Awake()
	{
        player.GetComponent<PlayerActivator>().Desactivate();
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
			Ray ray = rayCamera.ScreenPointToRay(middleScreenPosition);
			if (Physics.Raycast(ray, out hit)) {
				float distance = Vector3.Distance(rayCamera.transform.position, hit.collider.gameObject.transform.position);

                if (distance < minDistanceRayHit && hit.collider.tag == "RotationButton")
                {
                    hit.collider.gameObject.GetComponent<ButtonRotateSlice>().OnClick();
                }

                if (distance < minDistanceRayHit && hit.collider.tag == "DoorButton")
                {
                    hit.collider.gameObject.GetComponent<ButtonDoor>().OnClick();
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
            player.GetComponent<PlayerActivator>().Activate();
            crosshair.enabled = true;
		} else {
			globalCamera.SetActive(true);
            player.GetComponent<PlayerActivator>().Desactivate();
            crosshair.enabled = false;
		}
	}
}
