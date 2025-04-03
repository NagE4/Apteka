using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Start Game button clicked!");
        SceneManager.LoadScene("SampleScene");
    }

}