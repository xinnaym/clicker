using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopButton : MonoBehaviour, IPointerClickHandler
{
    public event Action OnPurchased;

    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _infoText;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private GameObject _hidePanel;

    private ProductItem _item;
    private float _price;
    private float _bonus;

    [Space, SerializeField] private Clicker _clicker;
    [SerializeField] private AutoClicker _autoClicker;

    public void Initialize(ProductItem item, float price, float bonus, Clicker clicker, AutoClicker autoClicker)
    {
        _item = item;
        _price = price;
        _bonus = bonus;
        _clicker = clicker;
        _autoClicker = autoClicker;

        UpdateInfo();
    }

    public void SetLockState(bool isLocked)
    {
        _hidePanel.SetActive(isLocked);
    }

    private void UpdateInfo()
    {
        _icon.sprite = _item.Icon;
        _nameText.text = _item.RuName;

        // "F0" гарантирует вывод строго целым числом (или используй _bonus.ToFormattedString() если число больше 1000)
        if (_item.Type == ProductType.click)
            _infoText.text = $"+{_bonus.ToFormattedString()} силы клика";
        else
            _infoText.text = $"+{_bonus.ToFormattedString()} силы авто клика";

        _priceText.text = $"Цена: {_price.ToFormattedString()}";
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_clicker.Money >= _price)
        {
            if (_item.Type == ProductType.click)
            {
                _clicker.UpgradeClickPower(_bonus);
            }
            else
            {
                _autoClicker.UpgradeAutoIncomePower(_bonus);
            }

            _clicker.Money -= _price;

            AudioManager.Instance.PlayPurchase();

            OnPurchased?.Invoke();
        }
    }
}