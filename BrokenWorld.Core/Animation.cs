namespace BrokenWorld.Core;

internal sealed class Animation
{
    private readonly Sprite[] _frames;
    private readonly float _frameTime;
    private readonly bool _loop;

    private float _timer;
    private int _index;

    public Animation(Sprite[] frames, float time, bool loop = true)
    {
        _frames = (Sprite[])frames.Clone();
        _frameTime = time;
        _loop = loop;

        _timer = time;
        _index = 0;
    }

    public Sprite CurrentSprite => _frames.Length > 0 ? _frames[_index] : new();

    public Vector2 Position
    {
        get => _frames.Length > 0 ? _frames[_index].Position : new();
        set
        {
            for (int i = 0; i < _frames.Length; i++)
            {
                _frames[i] = _frames[i] with { Position = value };
            }
        }
    }

    public void Update()
    {
        if (_frames.Length == 0) return;
        if (!_loop && _index == _frames.Length - 1) return;

        _timer -= Raylib.GetFrameTime();
        if (_timer < 0)
        {
            _index++;
            if (_index >= _frames.Length) _index = 0;
            _timer = _frameTime;
        }
    }

    public void Draw()
    {
        CurrentSprite.Draw();
    }
}
