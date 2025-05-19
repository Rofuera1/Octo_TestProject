using Naninovel;
using Naninovel.Commands;

[CommandAlias("showUI")]
public class UICommand : Command
{
    public StringParameter Id;
    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        UIManager.SetActiveUI(Id);

        return UniTask.CompletedTask;
    }
}

[CommandAlias("hideUI")]
public class UIHideCommand : Command
{
    public StringParameter Id;
    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        UIManager.SetInactiveUI(Id);

        return UniTask.CompletedTask;
    }
}
