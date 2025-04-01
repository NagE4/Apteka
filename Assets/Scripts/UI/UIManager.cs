using UnityEngine;

public class UIManager : MonoBehaviour
{
    public DecisionManager decisionManager;

    public void OnApproveButtonClicked()
    {
        decisionManager.Approve();
    }

    public void OnDenyButtonClicked()
    {
        decisionManager.Deny();
    }
}