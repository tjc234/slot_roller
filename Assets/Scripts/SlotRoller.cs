// imported packages
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// slot roller class
public class SlotRoller : MonoBehaviour
{
    // initialize public variables
    public List<Image> images;
    public float rollDelay;
    public int numLoops; 
    public int variance; 

    // initialize private variables
    private int listIndex;

    // delegate for slot roll end
    public delegate void SlotRollEnd();

    // event for slot roll end
    public event SlotRollEnd StopRoll;

    // start method to initialize the slot roller
    void Start()
    {
        // initialize the slot roller
        listIndex = 0;

        // loop through the images
        foreach (var image in images)
        {
            // disable current image
            image.enabled = false;
        }
        // enable first image
        images[listIndex].enabled = true;
    }

    // method to roll the slots
    public void RollSlots()
    {
        // start the slot roll loop coroutine
        StartCoroutine(RollSlotsLoop(rollDelay, numLoops, variance));
    }

    // method to roll the slots loop
    IEnumerator RollSlotsLoop(float delayTime, int numLoops, int variance)
    {
        // loop through the images
        int loopLimit = numLoops * images.Count + Random.Range(0, variance);
        for (int loopCnt = 0; loopCnt < loopLimit; loopCnt++)
        {
            // disable current image
            images[listIndex].enabled = false;

            // increment list index
            listIndex = (listIndex + 1) % images.Count;

            // enable next image
            images[listIndex].enabled = true;

            // wait for delay time and return
            yield return new WaitForSeconds(delayTime);
        }
        // invoke the slot roll end event
        StopRoll?.Invoke();
    }
}
