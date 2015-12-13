using UnityEngine;
using System.Collections;

public class PlayerActivator : MonoBehaviour
{
    public GameObject cameraRig;

	public void Activate ()
    {
        GetComponent<VRController>().enabled = true;
        GetComponent<CharacterController>().enabled = true;
        GetComponent<VRDebug>().enabled = true;
        cameraRig.SetActive(true);
    }
	
	public void Desactivate ()
    {
        GetComponent<VRController>().enabled = false;
        GetComponent<CharacterController>().enabled = false;
        GetComponent<VRDebug>().enabled = false;
        cameraRig.SetActive(false);
    }
}
