using UI;
using Market;
using System;
using System.Collections.Generic;
using System.Linq;
using Zenject;

public class ScoreCounter : IInitializable, IDisposable
{
    private readonly UIElements _uiElements;
    private readonly CashRegister[] _cashRegisters;

    private Dictionary<GoodsType, int> _scoreData = new();

    public ScoreCounter(UIElements uiElements, CashRegister[] cashRegister)
    {
        _uiElements = uiElements;
        _cashRegisters = cashRegister;
    }
    public void Initialize()
    {
        foreach (var cashRegister in _cashRegisters)
        {
            cashRegister.GoodsPurchased += OnGoodsAdded;
        }

        var values = Enum.GetValues(typeof(GoodsType)).Cast<GoodsType>();
        foreach (var value in values)
        {
            _scoreData.Add(value, 0);
        }

        RefreshLabels();
    }

    private void RefreshLabels()
    {
        _uiElements.bagsValueLabel.text = $"Bags {_scoreData[GoodsType.Bag]}";
        _uiElements.bottlesValueLabel.text = $"Bottles {_scoreData[GoodsType.Bottle]}";
        _uiElements.boxesValueLabel.text = $"Boxes {_scoreData[GoodsType.Box]}";
    }

    private void OnGoodsAdded(GoodsType goodsType)
    {
        _scoreData[goodsType]++;
        RefreshLabels();
    }


    public void Dispose()
    {
        foreach (var cashRegister in _cashRegisters)
        {
            cashRegister.GoodsPurchased -= OnGoodsAdded;
        }
    }
}
