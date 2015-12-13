using UnityEngine;
using System.Collections;

public class DeathByFall : MonoBehaviour
{
    public float deathHeight;
    
    private CharacterController characterController;
    private enum FallState {Grounded, Falling};
    private FallState fallState = FallState.Grounded;
    private Vector3 lastGroundedPosition;

	void Start ()
    {
        characterController = GetComponent<CharacterController>();
    }
	
	void Update ()
    {
        if (!characterController.isGrounded && fallState == FallState.Grounded) {
            lastGroundedPosition = transform.position;
            fallState = FallState.Falling;
        }

        if (characterController.isGrounded && fallState == FallState.Falling)
        {
            fallState = FallState.Grounded;
            float fallHeight = lastGroundedPosition.y - transform.position.y;

            if (fallHeight > deathHeight)
            {
                Debug.Log("Death by fall");
                GetComponent<Death>().Die();
            }
        }
    }
}
