using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DecisionManager : MonoBehaviour
{
    public DocumentViewer documentViewer;
    public TextMeshProUGUI moneyText;
    public int money = 0;

    private DocumentData currentDocument;
    private DocumentGenerator documentGenerator;

    void Start()
    {
        documentGenerator = FindObjectOfType<DocumentGenerator>();
        NextDocument();
    }

    public void SetCurrentDocument(DocumentData document)
    {
        currentDocument = document;
        documentViewer.DisplayDocument(document);
    }

    public void Approve()
    {
        if (currentDocument.isValid)
        {
            Debug.Log("Correct decision: Approved.");
            money += 5; // Earn money for correct approval
        }
        else
        {
            Debug.Log("Wrong decision: Denied invalid document.");
            money -= 10; // Lose money for incorrect approval
        }
        NextDocument();
    }

    public void Deny()
    {
        if (!currentDocument.isValid)
        {
            Debug.Log("Correct decision: Denied.");
            money += 5; // Earn money for correct denial
        }
        else
        {
            Debug.Log("Wrong decision: Denied valid document.");
            money -= 10; // Lose money for incorrect denial
        }
        NextDocument();
    }

    private void NextDocument()
    {
        if (documentGenerator == null)
        {
            Debug.LogError("DocumentGenerator is not assigned!");
            return;
        }

        if (documentViewer == null)
        {
            Debug.LogError("DocumentViewer is not assigned!");
            return;
        }

        currentDocument = documentGenerator.GetRandomDocument();

        if (currentDocument == null)
        {
            Debug.LogError("No documents available in DocumentGenerator!");
            return;
        }

        documentViewer.DisplayDocument(currentDocument);
        UpdateMoneyDisplay();
    }

    private void UpdateMoneyDisplay()
    {
        moneyText.text = "Money: $" + money;
    }
}