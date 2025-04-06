using System.Collections.Generic;
using UnityEngine;

public class DocumentGenerator : MonoBehaviour
{
    public List<DocumentData> validDocuments;
    public List<DocumentData> invalidDocuments;

    public DocumentViewer documentViewer; // Reference to the DocumentViewer

    public DocumentData GetRandomDocument()
    {
        bool isValid = Random.value > 0.5f; // 50% chance of valid/invalid
        DocumentData randomDocument = isValid 
            ? validDocuments[Random.Range(0, validDocuments.Count)] 
            : invalidDocuments[Random.Range(0, invalidDocuments.Count)];
        
        return randomDocument;
    }

    public void GenerateAndDisplayDocument()
    {
        // Get a random document
        DocumentData document = GetRandomDocument();

        // Display the document using the DocumentViewer
        if (documentViewer != null)
        {
            Debug.Log("DocumentViewer is assigned.");
            documentViewer.gameObject.SetActive(true); // Ensure the panel is visible
            documentViewer.DisplayDocument(document);
        }
        else
        {
            Debug.LogError("DocumentViewer is not assigned!");
        }
    }
}