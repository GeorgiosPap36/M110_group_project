using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketEventListener : MonoBehaviour
{
    public XRSocketInteractor socketOne;
    public XRSocketInteractor socketTwo;
    public DoorAnimationController doorController; // Reference to the DoorAnimationController

    private bool isSocketOneOccupied = false;
    private bool isSocketTwoOccupied = false;

    private void Start()
    {
        // Subscribe to the select entered events of both sockets
        socketOne.selectEntered.AddListener(OnSocketOneItemPlaced);
        socketTwo.selectEntered.AddListener(OnSocketTwoItemPlaced);
    }

    private void OnSocketOneItemPlaced(SelectEnterEventArgs arg)
    {
        isSocketOneOccupied = true;
        CheckSocketsAndOpenDoor();
    }

    private void OnSocketTwoItemPlaced(SelectEnterEventArgs arg)
    {
        isSocketTwoOccupied = true;
        CheckSocketsAndOpenDoor();
    }

    private void CheckSocketsAndOpenDoor()
    {
        // If both sockets are occupied and the door is not open, trigger the door to open
        if (isSocketOneOccupied && isSocketTwoOccupied && !doorController.IsOpen)
        {
            doorController.DoorInteract(); // Open the door
        }
    }

    // Make sure to unsubscribe when the GameObject is disabled or destroyed
    private void OnDisable()
    {
        socketOne.selectEntered.RemoveListener(OnSocketOneItemPlaced);
        socketTwo.selectEntered.RemoveListener(OnSocketTwoItemPlaced);
    }
}
