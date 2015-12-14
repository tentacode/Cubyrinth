using UnityEngine;
using System.Collections;

public class RotateProps : MonoBehaviour
{
    float rotationSpeed = 25.0f;

    void Start()
    {
        //iTween.RotateBy(gameObject, iTween.Hash("x", 1, "time", 10, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.loop));
    }

    void Update()
    {
        transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
    }
}

