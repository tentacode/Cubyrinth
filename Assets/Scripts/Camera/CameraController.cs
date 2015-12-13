using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
	public GameObject globalCamera;
	public GameObject player;
	public KeyCode switchCameraKey;

    [Header("Raytracing")]
    public Camera rayCamera;
	public float minDistanceRayHit = 2.5f;
    public float rayRadius = 0.5f;

	void Start()
	{
        player.GetComponent<PlayerActivator>().Desactivate();
		Cursor.visible = false;
	}

	void Update ()
	{
		if (Input.GetKeyDown(switchCameraKey)) {
			ToggleCamera();
        }

        if (IsFpsCamera()) {
            RayCast();
        }
	}

    void RayCast()
    {
        RaycastHit hit;

        Vector3 middleScreenPosition = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Vector3 rayOrigin = rayCamera.ScreenToWorldPoint(middleScreenPosition);

        if (!Physics.SphereCast(rayOrigin, rayRadius, rayCamera.transform.forward, out hit) && IsFpsCamera()) {
            return;
        }

        float distance = Vector3.Distance(player.transform.position, hit.collider.gameObject.transform.position);
        if (distance > minDistanceRayHit) {
            return;
        }

        if (hit.collider.tag == "RotationButton" || hit.collider.tag == "DoorButton") {
            hit.collider.gameObject.GetComponent<ButtonColor>().Hit();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (hit.collider.tag == "RotationButton")
            {
                hit.collider.gameObject.GetComponent<ButtonRotateSlice>().OnClick();
            }

            if (hit.collider.tag == "DoorButton")
            {
                hit.collider.gameObject.GetComponent<ButtonDoor>().OnClick();
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
		} else {
			globalCamera.SetActive(true);
            player.GetComponent<PlayerActivator>().Desactivate();
		}
	}
}
