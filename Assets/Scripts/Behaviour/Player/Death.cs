using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour
{
	public void Die()
	{
		var fadeToBlack = GameObject.Find("FadeToBlack");

		fadeToBlack.GetComponent<FaderToBlack>().FadeToCallback(Respawn);
	}

	public void Respawn()
	{
        GameObject[] spawners = GameObject.FindGameObjectsWithTag("Respawn");

        float maxY = float.NegativeInfinity;
        Vector3 highPosition = new Vector3();

        foreach (GameObject spawner in spawners)
        {
            if (spawner.transform.position.y > maxY)
            {
                maxY = spawner.transform.position.y;
                highPosition = spawner.transform.position;
            }
        }

        transform.position = highPosition;
    }
}
