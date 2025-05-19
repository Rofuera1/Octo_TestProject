using Naninovel;
using Naninovel.Commands;

[CommandAlias("lockLocation")]
public class MapCommand : Command
{
    public StringParameter Id;

    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        Map.ChangeLocationAvailibility(Id, false);

        return UniTask.CompletedTask;
    }
}
