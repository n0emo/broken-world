namespace BrokenWorld.Core.State;

internal sealed class OpeningCutscene : IState
{
    private readonly CutsceneState _s = new([
        new(Assets.Textures.CutsceneOpening1, "They called it mercy, but in reality\nit was the beginning of the end."),
        new(Assets.Textures.CutsceneOpening2, "His sword opened the ground like a wound."),
        new(Assets.Textures.CutsceneOpening2, "I just watched the world start to break."),
        new(Assets.Textures.CutsceneOpening3, "They wanted our silence more than our\nsurrender. We gave them neither."),
        new(Assets.Textures.CutsceneOpening4, "This shard of rock is all we have left."),
        new(Assets.Textures.CutsceneOpening4, "No tower. No Collegium. Just us - and a truth\nno one else is alive to tell."),
    ]);

    public IState Frame()
    {
        if (_s.Frame()) return new PreparePhase();
        return this;
    }
}
