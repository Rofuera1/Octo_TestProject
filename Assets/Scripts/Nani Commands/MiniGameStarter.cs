using Naninovel;
using Naninovel.Commands;

[CommandAlias("startMiniGame")]
public class MiniGameStarter : Command
{
    public StringParameter Scene;
    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        return UniTask.CompletedTask;
    }
}
