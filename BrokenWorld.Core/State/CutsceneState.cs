using BrokenWorld.Core.Ui;

namespace BrokenWorld.Core.State;

internal sealed class CutsceneState
{
    private Frame[] _frames;
    private int _index;

    public CutsceneState(Frame[] frames)
    {
        Raylib.SeekMusicStream(Assets.Music.Cutscene, 0);
        Raylib.PlayMusicStream(Assets.Music.Cutscene);

        _frames = frames;
        _index = 0;
    }

    public bool Frame()
    {
        var cutscene = new Cutscene
        {
            Frames = _frames,
            Index = _index,
        };

        var result = cutscene.Interact();

        if (result.Skip || (result.Next && _index == _frames.Length - 1))
        {
            Raylib.StopMusicStream(Assets.Music.Cutscene);
            return true;
        }
        else if (result.Next)
        {
            _index += 1;
        }

        Raylib.UpdateMusicStream(Assets.Music.Cutscene);
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.RayWhite);
        cutscene.Present();
        Raylib.EndDrawing();

        return false;
    }
}
