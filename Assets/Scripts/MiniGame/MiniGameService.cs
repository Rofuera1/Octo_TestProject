using Naninovel;

[InitializeAtRuntime]
public class MiniGameService : IEngineService
{
    private UniTaskCompletionSource<bool> finishTcs;

    public UniTask WaitForFinishAsync(AsyncToken token = default)
        => finishTcs?.Task ?? UniTask.CompletedTask;

    public void CompleteMiniGame()
        => finishTcs?.TrySetResult(true);

    public UniTask InitializeServiceAsync() { finishTcs = new UniTaskCompletionSource<bool>(); return UniTask.CompletedTask; }
    public void DestroyService() { }

    public void ResetService()
    {
    }
}
