using System.Collections.Generic;
using UnityEngine;

public class ShopSpawner : MonoBehaviour
{
    [SerializeField] private ShopButton _buttonPrefab;
    [SerializeField] private Transform _parentForButtons;
    [SerializeField] private List<ProductInfo> _productsInfo = new List<ProductInfo>();

    [Space, SerializeField] private Clicker _clicker;
    [SerializeField] private AutoClicker _autoClicker;

    private void Start()
    {
        SpawnButtons();
    }

    private void SpawnButtons()
    {
        ShopButton previousButton = null;

        for (int i = 0; i < _productsInfo.Count; i++)
        {
            ShopButton currentButton = Instantiate(_buttonPrefab, _parentForButtons);
            currentButton.Initialize(_productsInfo[i], _clicker, _autoClicker);

            if (i == 0)
            {
                currentButton.SetLockState(false);
            }
            else
            {
                currentButton.SetLockState(true);

                if (previousButton != null)
                {
                    ShopButton targetButton = currentButton;
                    ShopButton sourceButton = previousButton;

                    void OnPreviousPurchased()
                    {
                        targetButton.SetLockState(false);
                        sourceButton.OnPurchased -= OnPreviousPurchased;
                    }

                    previousButton.OnPurchased += OnPreviousPurchased;
                }
            }

            previousButton = currentButton;
        }
    }
}