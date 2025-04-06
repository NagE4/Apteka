using UnityEngine;

[CreateAssetMenu(fileName = "NewDocumentData", menuName = "ScriptableObjects/DocumentData", order = 1)]
public class DocumentData : ScriptableObject
{
    public string name; // Name of the person
    public string idNumber; // ID number
    public string issuingCountry; // Issuing country
    public string expirationDate; // Expiration date
    public bool isValid; // Whether the document is valid
}