using UnityEngine;

public class CitizenBehavior : MonoBehaviour
{
    public DocumentData document;

    void Start()
    {
        // Assign a random document when the citizen spawns
        document = FindObjectOfType<DocumentGenerator>().GetRandomDocument();
    }

    public void Interact()
    {
        Debug.Log("Citizen presents document: " + document.name);
        FindObjectOfType<DecisionManager>().SetCurrentDocument(document);
    }
}