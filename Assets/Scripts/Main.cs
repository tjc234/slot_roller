// imported packages
using UnityEngine;
using UnityEngine.UI;

// main driver class
public class Main : MonoBehaviour
{
    // initialize public variables
    public GameObject leverButton;
    public SlotRoller slotRoller0;
    public SlotRoller slotRoller1;
    public SlotRoller slotRoller2;

    // initialize private variables
    private int slotsFinished = 0;

    // start method to initialize the event listeners
    void Start()
    {
        // add event listeners to the slot roller objects
        slotRoller0.StopRoll += SlotRollEnded;
        slotRoller1.StopRoll += SlotRollEnded;
        slotRoller2.StopRoll += SlotRollEnded;
    }

    // method to disable the lever button
    public void DisableLever()
    {
        // disable the lever button
        leverButton.GetComponent<Button>().interactable = false;
    }

    // method to handle the slot roll ended event
    private void SlotRollEnded()
    {
        // increment counter
        slotsFinished++;

        // check if all slots have finished
        if (slotsFinished == 3)
        {
            // enable the lever button
            leverButton.GetComponent<Button>().interactable = true;

            // reset counter
            slotsFinished = 0;
        }
    }
}
