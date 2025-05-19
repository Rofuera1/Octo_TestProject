using System.Collections.Generic;
using UnityEngine;

public static class QuestManager // ��� ������ ������� ������� ����� ��� ������� ��������
{
    private static HashSet<int> Tasks = new HashSet<int>();

    public static void AddTask(string Id, string Text, int Stage) // ��������������, ��� ���������� ������ �� �����
    {
        if (Tasks.Contains(Stage)) return;

        Tasks.Add(Stage);
        UIManager.UpdateQuest(Text);
    }
}
