using UnityEngine;

public class UIManager : MonoBehaviour
{
    private void OnEnable()
    {
        // Subscribe to the "NewDayStarted" event
        EventManager.Instance.AddListener("NewDayStarted", OnNewDayStarted);
    }

    private void OnDisable()
    {
        // Unsubscribe from the "NewDayStarted" event
        EventManager.Instance.RemoveListener("NewDayStarted", OnNewDayStarted);
    }

    private void OnNewDayStarted()
    {
        Debug.Log("UIManager: New Day Started!");

        // Update the UI to reflect the new day
        UpdateDayDisplay();
    }

    private void UpdateDayDisplay()
    {
        // Example: Update a text element to show the current day
        Debug.Log("Updating day display...");
    }
}