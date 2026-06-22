using BrokenWorld.Core.Buildings;

namespace BrokenWorld.Core.Ui;

internal sealed class PrepareUi
{
    public record NewBuildingDesc(BuildingKind Kind, bool CanBuild, string Tooltip, Money Cost);

    private readonly BuildingButton[] _buildingButtons = [];
    private readonly Button _upgradeButton;
    private readonly Button _demolishButton;
    private readonly Button _startWaveButton;
    private readonly Balance _balance;
    private readonly Money? _upgradeCost;

    public PrepareUi(Building? selectedBuilding, Money balance, NewBuildingDesc[] buildings)
    {
        var buildingsWidth = BuildingsPanelWidth(buildings);
        var buttonSize = Constants.BuildingButtonSize;
        var panelSpacing = 2;

        _buildingButtons = BuildBuildingButtons(buildings);
        _upgradeButton = BuildUpgradeButton(selectedBuilding, balance, buildingsWidth + panelSpacing + 0 * buttonSize);
        _demolishButton = BuildDemolishButton(selectedBuilding, buildingsWidth + panelSpacing + 1 * buttonSize);
        _startWaveButton = BuildStartWaveButton(buildingsWidth + panelSpacing + 2 * buttonSize);
        _balance = BuildBalance(balance);

        if (selectedBuilding is not null && selectedBuilding.CurrentLevel < selectedBuilding.UpgradeCost.Length)
        {
            _upgradeCost = selectedBuilding.UpgradeCost[selectedBuilding.CurrentLevel];
        }
    }

    public PrepareUiResult Interact()
    {
        BuildingKind? placeNewBuilding = null;

        foreach (var b in _buildingButtons)
        {
            if (b.Interact())
            {
                placeNewBuilding = b.Kind;
                break;
            }
        }

        bool upgradeRequested = _upgradeButton.Interact();
        bool demolishRequested = _demolishButton.Interact();
        bool startWaveRequested = _startWaveButton.Interact();

        return new PrepareUiResult(
            PlaceNewBuilding: placeNewBuilding,
            UpgradeRequested: upgradeRequested,
            DemolishRequested: demolishRequested,
            StartWaveRequested: startWaveRequested
        );
    }

    public void Present()
    {
        Raylib.DrawRectangle(
            posX: 0,
            posY: 0,
            width: Raylib.GetScreenWidth(),
            height: 80,
            color: Color.LightGray
        );
        Raylib.DrawRectangle(
            posX: 0,
            posY: 80 - (int)Constants.BorderSize,
            width: Raylib.GetScreenWidth(),
            height: (int)Constants.BorderSize,
            color: Constants.BorderColor
        );

        foreach (var b in _buildingButtons)
        {
            b.Present();
        }
        _upgradeButton.Present();
        _demolishButton.Present();
        _startWaveButton.Present();
        _balance.Present();

        if (_upgradeCost is not null)
        {
            Raylib.DrawText(
                text: $"Upgrade cost: {_upgradeCost}",
                posX: Raylib.GetScreenWidth() - 390,
                posY: Constants.BuildingButtonSize,
                fontSize: (int)Constants.SmallFontSize,
                color: Color.Black
            );
        }
    }

    private static int BuildingsPanelWidth(NewBuildingDesc[] buildings) => buildings.Length * Constants.BuildingButtonSize;
    private static int BuildingsPanelHeight(NewBuildingDesc[] buildings) => buildings.Length * Constants.BuildingButtonSize;

    private static BuildingButton[] BuildBuildingButtons(NewBuildingDesc[] buildings)
    {
        var buttons = new BuildingButton[buildings.Length];

        for (int i = 0; i < buildings.Length; i++)
        {
            var position = new Vector2(
                x: i * Constants.BuildingButtonSize,
                y: 0
            );
            var sprite = buildings[i].Kind.GetSprite();
            var scale = Constants.TileSize / sprite.Source.Width * 1.5f;


            buttons[i] = new()
            {
                Kind = buildings[i].Kind,
                Bounds = new()
                {
                    X = position.X,
                    Y = position.Y,
                    Width = Constants.BuildingButtonSize,
                    Height = Constants.BuildingButtonSize,
                },
                IsActive = buildings[i].CanBuild,
                Icon = sprite with { Position = position, Scale = scale },
                Cost = buildings[i].Cost,
                Tooltip = buildings[i].Tooltip,
            };
        }

        return buttons;
    }

    private static Button BuildUpgradeButton(Building? selectedBuilding, Money balance, int x)
    {
        return new()
        {
            Bounds = new()
            {
                X = x,
                Y = 0,
                Width = Constants.BuildingButtonSize,
                Height = Constants.BuildingButtonSize,
            },
            Text = "Level\nUp",
            IsActive = selectedBuilding?.CanUpgrade(balance) ?? false,
        };
    }

    private static Button BuildDemolishButton(Building? selectedBuilding, int x)
    {
        return new()
        {
            Bounds = new()
            {
                X = x,
                Y = 0,
                Width = Constants.BuildingButtonSize,
                Height = Constants.BuildingButtonSize,
            },
            Text = "Sell",
            IsActive = selectedBuilding is not null && selectedBuilding.Kind != BuildingKind.TawnHall,
        };
    }

    private static Button BuildStartWaveButton(int x)
    {
        return new()
        {
            Bounds = new()
            {
                X = x,
                Y = 0,
                Width = Constants.BuildingButtonSize,
                Height = Constants.BuildingButtonSize,
            },
            Text = "Next\nWave",
        };
    }

    private static Balance BuildBalance(Money money)
    {
        return new()
        {
            Bounds = new()
            {
                Y = 0,
                X = Raylib.GetScreenWidth() - 130,
                Width = 130,
                Height = Constants.BuildingButtonSize,
            },
            Money = money,
        };
    }
}
