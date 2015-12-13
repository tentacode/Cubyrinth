using UnityEngine;
using System.Collections;

public class ButtonDoor : MonoBehaviour {
    public enum DoorInteraction {Drop, Reset};
    public DoorInteraction interaction;
    public DoorMover door;

    public void OnClick()
    {
        if (interaction == DoorInteraction.Drop)
        {
            door.DropDoor();
        }

        if (interaction == DoorInteraction.Reset)
        {
            door.ResetDoor();
        }
    }
}
