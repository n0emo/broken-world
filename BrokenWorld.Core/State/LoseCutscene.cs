namespace BrokenWorld.Core.State;

internal sealed class LoseCutscene : IState
{
    private readonly CutsceneState _s = new([
        new(Assets.Textures.CutsceneDeath, "They broke us before dawn.\nThe Church will call this salvation."),
        new(Assets.Textures.CutsceneDeath, "There's no one left to call it anything else."),
    ]);

    public IState Frame()
    {
        if (_s.Frame()) return new MainMenu();
        return this;
    }
}
