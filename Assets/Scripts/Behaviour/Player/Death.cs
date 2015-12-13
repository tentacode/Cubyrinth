using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour
{
	public void Die()
	{
		var fadeToBlack = GameObject.Find("PlayerFadeToBlack");
        fadeToBlack.GetComponent<FaderToBlack>().FadeToCallback(Respawn, 1.0f);
	}

	public void Respawn()
	{
        GameObject[] spawners = GameObject.FindGameObjectsWithTag("Respawn");

        float maxY = float.NegativeInfinity;
        Vector3 highPosition = new Vector3();
        Quaternion quaternion = new Quaternion();

        foreach (GameObject spawner in spawners)
        {
            if (spawner.transform.position.y > maxY)
            {
                maxY = spawner.transform.position.y;
                highPosition = spawner.transform.position;
                quaternion = spawner.transform.rotation;
            }
        }

        transform.position = highPosition;
        transform.rotation = quaternion;
    }
}
