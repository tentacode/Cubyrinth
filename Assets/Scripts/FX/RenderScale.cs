using UnityEngine;
using System.Collections;
using UnityEngine.VR;

public class RenderScale : MonoBehaviour
{
    public float renderScale;
    
	void Start ()
    {
        VRSettings.renderScale = renderScale;
    }
}
