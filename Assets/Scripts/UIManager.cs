using Naninovel;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    protected static UIManager Instance;
    [SerializeField]
    private GameObject Map;
    [SerializeField]
    private GameObject Quest;
    [Space]
    [SerializeField]
    private TMPro.TextMeshProUGUI QuestText;

    private void Awake()
    {
        Instance = this;
    }

    public static void SetActiveUI(string Id) => Instance.SetUI(Id, true);
    public static void SetInactiveUI(string Id) => Instance.SetUI(Id, false);
    public static void UpdateQuest(string Text) => Instance.AddQuestText(Text);

    private void AddQuestText(string Text)
    {
        QuestText.text += (Text + "\n");
    }

    private void SetUI(string Id, bool Active)
    {
        List<GameObject> UI = new List<GameObject>();

        switch(Id)
        {
            case "Map":
                UI.Add(Map);
                break;
            case "Quest":
                UI.Add(Quest);
                break;
            case "All":
                UI.Add(Map);
                UI.Add(Quest);
                break;
        }

        foreach(var el in UI)
            el.SetActive(Active);
    }
}
