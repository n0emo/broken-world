namespace BrokenWorld.Core.State;

internal sealed class OpeningCutscene : IState
{
    public IState Frame()
    {
        return new PreparePhase();
    }
}
