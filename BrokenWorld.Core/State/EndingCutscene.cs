namespace BrokenWorld.Core.State;

internal sealed class EndingCutscene : IState
{
    private readonly CutsceneState _s = new([
        new(Assets.Textures.CutsceneWin, "We didn't win the war.\nWe just stole back enough sky\nto keep the truth alive."),
        new(Assets.Textures.CutsceneWin, "And flew where their swords couldn't reach us."),
    ]);

    public IState Frame()
    {
        if (_s.Frame()) return new MainMenu();
        return this;
    }
}
