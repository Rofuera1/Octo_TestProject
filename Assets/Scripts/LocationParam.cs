using UnityEngine;

[RequireComponent(typeof(UnityEngine.UI.Button))]
public class LocationParam : MonoBehaviour
{
    public string Id;
    private UnityEngine.UI.Button ButtonSelf;

    private void Awake()
    {
        ButtonSelf = GetComponent<UnityEngine.UI.Button>();
        ButtonSelf.onClick.AddListener(() => Map.GoToLocation(Id));
    }

    public void ChangeAvailible(bool Availible)
    {
        ButtonSelf.interactable = Availible;
    }
}
