using System.Collections.Generic;
using UnityEngine;

public class DocumentGenerator : MonoBehaviour
{
    public List<DocumentData> validDocuments;
    public List<DocumentData> invalidDocuments;

    public DocumentData GetRandomDocument()
    {
        bool isValid = Random.value > 0.5f; // 50% chance of valid/invalid
        return isValid ? validDocuments[Random.Range(0, validDocuments.Count)] :
                         invalidDocuments[Random.Range(0, invalidDocuments.Count)];
    }
}