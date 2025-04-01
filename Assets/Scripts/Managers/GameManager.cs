using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int day = 1;
    public int maxDays = 10;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void EndDay()
    {
        day++;
        if (day > maxDays)
        {
            Debug.Log("Game Over!");
            // Transition to end-game scene
        }
        else
        {
            Debug.Log("Starting Day " + day);
        }
    }
}