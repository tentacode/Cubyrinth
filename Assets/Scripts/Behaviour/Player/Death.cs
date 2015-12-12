using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour
{
	public Transform respawnPoint;

	public void Die()
	{
		var fadeToBlack = GameObject.Find("FadeToBlack");

		fadeToBlack.GetComponent<FaderToBlack>().FadeToCallback(Respawn);
	}

	public void Respawn()
	{
		var rb = gameObject.GetComponent<Rigidbody>();
		rb.transform.position = respawnPoint.position;
		rb.transform.rotation = respawnPoint.rotation;
	}
}
