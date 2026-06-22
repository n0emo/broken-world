namespace BrokenWorld.Core.Ui;

internal readonly record struct DefenseUiResult(
    int? ChangeGameSpeed,
    bool RestartRequested
);
