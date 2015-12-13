using UnityEngine;
using System.Collections;

public class PlayerActivator : MonoBehaviour {
	public void Activate ()
    {
        GetComponent<VRController>().enabled = true;
        GetComponent<CharacterController>().enabled = true;
    }
	
	public void Desactivate ()
    {
        GetComponent<VRController>().enabled = false;
        GetComponent<CharacterController>().enabled = false;
    }
}
