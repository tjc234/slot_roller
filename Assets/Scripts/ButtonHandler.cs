// imported packages
using UnityEngine;
using UnityEngine.UI;

// button handler class
public class ButtonHandler : MonoBehaviour
{
    // initialize public variables
    public Main main;

    // method to pull the slot lever
    public void PullSlotLever()
    {
        // disable the lever button
        main.DisableLever();

        // roll each of the slots
        main.slotRoller0.RollSlots(); 
        main.slotRoller1.RollSlots();
        main.slotRoller2.RollSlots(); 
    }
}
