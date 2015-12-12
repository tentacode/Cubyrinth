using UnityEngine;
using System.Collections;

public class ZoneCheckpoint : MonoBehaviour
{
	public Transform respawnPoint;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			other.GetComponent<Death>().respawnPoint = respawnPoint;
		}
	}
}
