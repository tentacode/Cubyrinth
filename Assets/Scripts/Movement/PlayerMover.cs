using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour
{
    public float walkSpeed;
    public float rotationSpeed;

    void Start()
    {
    }

    void Update()
    {

        float translation = Input.GetAxis("Vertical") * walkSpeed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);
        
    }
}
