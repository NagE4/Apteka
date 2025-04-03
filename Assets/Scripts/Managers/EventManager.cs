using System;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    // Singleton instance for global access
    public static EventManager Instance { get; private set; }

    // Dictionary to store event listeners
    private readonly Dictionary<string, Action> eventListeners = new Dictionary<string, Action>();

    private void Awake()
    {
        // Ensure only one instance of EventManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject); // Prevent duplicate instances
        }
    }

    /// <summary>
    /// Add a listener for a specific event.
    /// </summary>
    /// <param name="eventName">Name of the event.</param>
    /// <param name="listener">Action to be invoked when the event is triggered.</param>
    public void AddListener(string eventName, Action listener)
    {
        if (!eventListeners.ContainsKey(eventName))
        {
            eventListeners[eventName] = listener;
        }
        else
        {
            eventListeners[eventName] += listener;
        }
    }

    /// <summary>
    /// Remove a listener for a specific event.
    /// </summary>
    /// <param name="eventName">Name of the event.</param>
    /// <param name="listener">Action to be removed.</param>
    public void RemoveListener(string eventName, Action listener)
    {
        if (eventListeners.ContainsKey(eventName))
        {
            eventListeners[eventName] -= listener;

            // Clean up empty events
            if (eventListeners[eventName] == null)
            {
                eventListeners.Remove(eventName);
            }
        }
    }

    /// <summary>
    /// Trigger an event by name.
    /// </summary>
    /// <param name="eventName">Name of the event to trigger.</param>
    public void TriggerEvent(string eventName)
    {
        if (eventListeners.ContainsKey(eventName))
        {
            eventListeners[eventName]?.Invoke();
        }
        else
        {
            Debug.LogWarning($"Event '{eventName}' has no listeners.");
        }
    }
}