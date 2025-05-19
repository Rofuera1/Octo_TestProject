using Naninovel;
using Naninovel.Commands;

[CommandAlias("questUpdate")]
public class QuestUpdate : Command
{
    public StringParameter Id;
    public StringParameter Text;
    public IntegerParameter Stage;

    public override UniTask ExecuteAsync(AsyncToken _ = default)
    {
        var id = Id?.Value;
        var text = Text?.Value;
        var stage = Stage.HasValue ? Stage.Value : -1;

        QuestManager.AddTask(id, text, stage);
        return UniTask.CompletedTask;
    }
}
