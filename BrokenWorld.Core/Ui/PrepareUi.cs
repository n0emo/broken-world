using BrokenWorld.Core.Buildings;

namespace BrokenWorld.Core.Ui;

internal sealed class PrepareUi
{
    private record NewBuildingButton(Button Button, BuildingKind Kind);

    private Rectangle _topPanelRec;
    private readonly List<NewBuildingButton> _buildingButtons = [];
    private readonly Button _demolishButton;
    private readonly Button _startWaveButton;
    private readonly Balance _balance;

    public PrepareUi(Building? selectedBuilding, Money balance)
    {
        (string Text, BuildingKind Kind)[] buildings = [
            ("Mage\nTower", BuildingKind.MageTower),
            ("Wall", BuildingKind.Wall),
        ];
        var size = Constants.TopPanelItemSize;
        var fullWidth = size * buildings.Length + Constants.TopPanelBorderSize * (buildings.Length + 1);
        var height = size + Constants.TopPanelBorderSize * 2;
        var panelY = 0;
        var panelX = (Raylib.GetScreenWidth() - fullWidth) / 2;

        _topPanelRec = new Rectangle(panelX, panelY, fullWidth, height);


        for (int i = 0; i < buildings.Length; i++)
        {
            var x = panelX + (i * size) + i * Constants.TopPanelBorderSize;
            var button = new Button
            {
                Bounds = new Rectangle
                {
                    X = x,
                    Y = panelY,
                    Width = size + Constants.TopPanelBorderSize * 2,
                    Height = height,
                },
                Text = buildings[i].Text,
            };
            _buildingButtons.Add(new NewBuildingButton(button, buildings[i].Kind));
        }

        _demolishButton = new()
        {
            Bounds = new()
            {
                X = panelX + fullWidth + 16,
                Y = panelY,
                Width = height,
                Height = height,
            },
            Text = "Demolish",
            IsActive = selectedBuilding is not null && selectedBuilding.Kind != BuildingKind.TawnHall,
        };

        _startWaveButton = new()
        {
            Bounds = new()
            {
                X = 0,
                Y = 0,
                Width = 100,
                Height = 50,
            },
            Text = "Start Wave",
            Style = new()
            {
                FontSize = 16,
            }
        };

        _balance = new()
        {
            Bounds = new()
            {
                Y = 0,
                X = Raylib.GetScreenWidth() - 150,
                Width = 150,
                Height = 50
            },
            Money = balance,
        };
    }

    public PrepareUiResult Interact()
    {
        BuildingKind? placeNewBuilding = null;
        bool demolishRequested = false;
        bool startWaveRequested = false;

        foreach (var b in _buildingButtons)
        {
            if (b.Button.Interact())
            {
                placeNewBuilding = b.Kind;
                break;
            }
        }

        if (_demolishButton.Interact()) demolishRequested = true;
        if (_startWaveButton.Interact()) startWaveRequested = true;

        return new PrepareUiResult(
            PlaceNewBuilding: placeNewBuilding,
            DemolishRequested: demolishRequested,
            StartWaveRequested: startWaveRequested
        );
    }

    public void Present()
    {
        Raylib.DrawRectangleRec(_topPanelRec, Constants.TopPanelBackgroundColor);
        foreach (var b in _buildingButtons)
        {
            b.Button.Present();
        }
        _demolishButton.Present();
        _startWaveButton.Present();
        _balance.Present();
    }
}

//     private void TopPanel()
//     {
//         var mousePosition = Raylib.GetMousePosition();
//         var buildingCount = BuildingKind.GetValues().Length;
//         var size = Constants.TopPanelItemSize;
//         var fullWidth = size * buildingCount + Constants.TopPanelBorderSize * (buildingCount + 1);
//         var height = size + Constants.TopPanelBorderSize * 2;
//         var panelY = 0;
//         var panelX = (Raylib.GetScreenWidth() - fullWidth) / 2;
//         Raylib.DrawRectangle(panelX, panelY, fullWidth, height, Constants.TopPanelBackgroundColor);
//
//         var names = BuildingKind.GetNames();
//         var kinds = BuildingKind.GetValues();
//
//         for (int i = 0; i < buildingCount; i++)
//         {
//             var x = panelX + (i * size) + i * Constants.TopPanelBorderSize;
//             var button = new Button
//             {
//                 Bounds = new Rectangle
//                 {
//                     X = x,
//                     Y = panelY,
//                     Width = size + Constants.TopPanelBorderSize * 2,
//                     Height = height,
//                 },
//                 Text = names[i],
//             };
//             if (button.Interact())
//             {
//                 _placingNewBuilding = kinds[i];
//             }
//         }
//
//         if (_selectedBuilding is BuildingSelection sel)
//         {
//             if (BuildingDeleteButton(new()
//             {
//                 X = panelX + fullWidth + 16,
//                 Y = panelY,
//                 Width = height,
//                 Height = height,
//             }))
//             {
//                 _map.TryRemoveBuilding(sel.Id);
//                 _selectedBuilding = null;
//             }
//         }
//     }
//
//     private bool BuildingDeleteButton(Rectangle bounds)
//     {
//         Button button = new()
//         {
//             Bounds = bounds,
//         };
//         return button.Interact();
//     }
//
