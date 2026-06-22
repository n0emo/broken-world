using BrokenWorld.Core.Ui;

namespace BrokenWorld.Core.State;

internal sealed class OpeningCutscene : IState
{
    public OpeningCutscene()
    {
        Raylib.SeekMusicStream(Assets.Music.Cutscene, 0);
        Raylib.PlayMusicStream(Assets.Music.Cutscene);
    }

    public IState Frame()
    {
        Raylib.UpdateMusicStream(Assets.Music.Cutscene);
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.RayWhite);
        var b = new Button
        {
            Bounds = new(100, 100, 100, 100),
            Text = "Skip",
        };

        if (b.Interact())
        {
            Raylib.StopMusicStream(Assets.Music.Cutscene);
            Raylib.EndDrawing();
            return new PreparePhase();
        }

        b.Present();
        Raylib.EndDrawing();

        return this;
    }
}
