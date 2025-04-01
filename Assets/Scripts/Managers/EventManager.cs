using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public List<EventData> events;
    private int currentIndex = 0;

    public void TriggerNextEvent()
    {
        if (currentIndex < events.Count)
        {
            Debug.Log("Event: " + events[currentIndex].description);
            currentIndex++;
        }
        else
        {
            Debug.Log("No more events.");
        }
    }
}