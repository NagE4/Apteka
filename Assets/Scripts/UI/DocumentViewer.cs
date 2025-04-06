using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DocumentViewer : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI idNumberText;
    public TextMeshProUGUI issuingCountryText;
    public TextMeshProUGUI expirationDateText;

    public void DisplayDocument(DocumentData document)
    {
        nameText.text = "Name: " + document.name;
        idNumberText.text = "ID Number: " + document.idNumber;
        issuingCountryText.text = "Issuing Country: " + document.issuingCountry;
        expirationDateText.text = "Expiration Date: " + document.expirationDate;

        gameObject.SetActive(true);
        
    }

    public void ClosePanel()
    {
        // Hide the panel
        gameObject.SetActive(false);
    }
}
