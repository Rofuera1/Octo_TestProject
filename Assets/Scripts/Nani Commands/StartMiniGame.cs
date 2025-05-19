using Naninovel;
using UnityEngine.SceneManagement;

[CommandAlias("startMiniGame")]
public class StartMiniGame : Command
{
    [ParameterAlias("scene")] public StringParameter SceneName;

    public override async UniTask ExecuteAsync(AsyncToken token = default)
    {
        var scene = SceneName?.Value;

        var ui = Engine.GetService<IUIManager>();
        var input = Engine.GetService<IInputManager>();
        input.ProcessInput = false;

        await SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive).ToUniTask();

        var miniGame = Engine.GetService<MiniGameService>();
        await miniGame.WaitForFinishAsync(token);

        await SceneManager.UnloadSceneAsync(scene).ToUniTask();

        input.ProcessInput = true;
    }
}
