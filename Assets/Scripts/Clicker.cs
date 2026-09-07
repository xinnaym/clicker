using System;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    [SerializeField] private float _clickPower;
    [SerializeField] private Transform _clickerImage;
    public float ClickPower => _clickPower;

    private float _money;
    public float Money
    {
        get => _money;
        set
        {
            _money = value;
            OnChangeMoneyValue?.Invoke();
        }
    }
    public event Action OnChangeMoneyValue;
    public void OnClickDown()
    {
        Money += _clickPower;
        _clickerImage.localScale = Vector2.one * .9f;

        AudioManager.Instance.PlayClick();
    }

    public void OnClickUp()
    {
        _clickerImage.localScale = Vector2.one;
    }

    public void UpgradeClickPower(float bonus)
    {
        _clickPower += bonus;
    }
}
