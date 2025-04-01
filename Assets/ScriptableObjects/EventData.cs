using UnityEngine;

[CreateAssetMenu(fileName = "NewEvent", menuName = "Customs/Event")]
public class EventData : ScriptableObject
{
    public string description;
    public bool requiresSpecialApproval;
}