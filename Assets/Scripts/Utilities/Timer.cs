using UnityEngine;

public class Timer : MonoBehaviour
{
    public float dayDuration = 120f; // 2 minutes per day
    public int currentDay = 1;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= dayDuration)
        {
            timer = 0;
            currentDay++;
            Debug.Log("Starting Day " + currentDay);
        }
    }
}