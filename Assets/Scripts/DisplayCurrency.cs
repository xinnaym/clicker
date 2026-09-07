using TMPro;
using UnityEngine;

public class DisplayCurrency : MonoBehaviour
{
    [SerializeField] private Clicker _clicker;
    [SerializeField] private AutoClicker _autoClicker;
    [SerializeField] private TMP_Text _balance;
    [SerializeField] private TMP_Text _autoIncome;
    [SerializeField] private TMP_Text _clickPowerText;


    private void Start()
    {
        _clicker.OnChangeMoneyValue += UpdateTextValue;
        UpdateTextValue();
    }
    
    private void UpdateTextValue()
    {
        _balance.text = _clicker.Money.ToString();
        _autoIncome.text = $"+{_autoClicker.AutoIncomePower} в сек.";
        _clickPowerText.text = $"+{_clicker.ClickPower} за клик";
    }

}
