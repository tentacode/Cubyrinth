using UnityEngine;
using System.Collections;

public class RotateProps : MonoBehaviour
{
    void Start()
    {
        iTween.RotateBy(gameObject, iTween.Hash("x", 1, "time", 10, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.loop));
    }
}

