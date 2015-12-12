using UnityEngine;
using System.Collections;

public class DeathByTrigger : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "DeathTrigger") {
			Debug.Log("Death by trigger");
			GetComponent<Death>().Die();
		}
	}
}
