using UnityEngine;
using UnityEngine.UI;

public class DocumentViewer : MonoBehaviour
{
    public Text nameText;
    public Text idNumberText;
    public Text issuingCountryText;
    public Text expirationDateText;

    public void DisplayDocument(DocumentData document)
    {
        nameText.text = "Name: " + document.name;
        idNumberText.text = "ID Number: " + document.idNumber;
        issuingCountryText.text = "Issuing Country: " + document.issuingCountry;
        expirationDateText.text = "Expiration Date: " + document.expirationDate;
    }
}