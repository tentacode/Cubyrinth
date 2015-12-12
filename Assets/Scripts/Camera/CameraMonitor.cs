using UnityEngine;
using System.Collections;

public class CameraMonitor : MonoBehaviour
{
	public float aspectRatio;

	void Start ()
	{
		GetComponent<Camera>().aspect = aspectRatio;
	}
}
