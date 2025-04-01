using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    public Text dialogueText;
    public string[] sentences;
    private int index = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && index < sentences.Length)
        {
            dialogueText.text = sentences[index];
            index++;
        }
    }
}