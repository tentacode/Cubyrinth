using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name =="Ending")
        {
            Debug.Log("End Game");
            GameController gameController = GameObject.Find("Game").GetComponent<GameController>();
            gameController.EndGame();
        }
    }
}
