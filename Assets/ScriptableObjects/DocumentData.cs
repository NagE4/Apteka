using UnityEngine;

[CreateAssetMenu(fileName = "NewDocument", menuName = "Customs/Document")]
public class DocumentData : ScriptableObject
{
    public string name;
    public string idNumber;
    public string issuingCountry;
    public string expirationDate;
    public bool isValid; // Whether the document is valid
}