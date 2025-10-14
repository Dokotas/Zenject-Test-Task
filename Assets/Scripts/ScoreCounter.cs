using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bagsValueLabel, bottlesValueLabel, boxesValueLabel;
    [SerializeField] private ShopCart shopCart;

    private int _bagsValue, _bottlesValue, _boxesValue;

    private void Start()
    {
        shopCart.OnBagAdded += BagAdded;
        shopCart.OnBottleAdded += BottleAdded;
        shopCart.OnBoxAdded += BoxAdded;

        RefreshLabels();
    }

    private void RefreshLabels()
    {
        bagsValueLabel.text = $"Bags {_bagsValue}";
        bottlesValueLabel.text = $"Bottles {_bottlesValue}";
        boxesValueLabel.text = $"Boxes {_boxesValue}";
    }

    private void BagAdded()
    {
        _bagsValue++;
        RefreshLabels();
    }

    private void BottleAdded()
    {
        _bottlesValue++;
        RefreshLabels();
    }

    private void BoxAdded()
    {
        _boxesValue++;
        RefreshLabels();
    }
}
