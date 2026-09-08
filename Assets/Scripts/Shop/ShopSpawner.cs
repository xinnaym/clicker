using UnityEngine;

public class ShopSpawner : MonoBehaviour
{
    [SerializeField] private ShopButton _buttonPrefab;
    [SerializeField] private Transform _parentForButtons;
    [SerializeField] private ProductInfo _catalog;

    [Space, SerializeField] private Clicker _clicker;
    [SerializeField] private AutoClicker _autoClicker;

    private void Start()
    {
        SpawnButtons();
    }

    private void SpawnButtons()
    {
        ShopButton previousButton = null;

        int clickIndex = 0;
        int autoClickIndex = 0;

        for (int i = 0; i < _catalog.Items.Count; i++)
        {
            ProductItem item = _catalog.Items[i];

            float price;
            float bonus;

            // Расчет экономики
            if (item.Type == ProductType.click)
            {
                price = 15f * Mathf.Pow(3.0f, clickIndex);
                bonus = (float)System.Math.Round(1f * Mathf.Pow(2.5f, clickIndex));
                clickIndex++;
            }
            else
            {
                price = 45f * Mathf.Pow(3.0f, autoClickIndex);
                bonus = (float)System.Math.Round(1f * Mathf.Pow(2.5f, autoClickIndex));
                autoClickIndex++;
            }

            ShopButton currentButton = Instantiate(_buttonPrefab, _parentForButtons);
            currentButton.Initialize(item, price, bonus, _clicker, _autoClicker);

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