using System.Collections.Generic;
using UnityEngine;

public static class QuestManager // Для такого задания намного легче это сделать статикой
{
    private static HashSet<int> Tasks = new HashSet<int>();

    public static void AddTask(string Id, string Text, int Stage) // Предполагается, что одинаковых тасков не будет
    {
        if (Tasks.Contains(Stage)) return;

        Tasks.Add(Stage);
        UIManager.UpdateQuest(Text);
    }
}
