using TMPro;
using UnityEngine;

public static class NumberFormatter
{
    private static readonly string[] Suffixes = { "", "K", "M", "B", "T", "Qa", "Qi" };

    public static string ToFormattedString(this float value)
    {
        if (value < 0)
            return "-" + (-value).ToFormattedString();

        if (value < 1000f)
            return value.ToString("0.#");

        int index = 0;
        double number = value;

        while (number >= 1000.0 && index < Suffixes.Length - 1)
        {
            number /= 1000.0;
            index++;
        }

        return $"{number:0.##}{Suffixes[index]}";
    }
}

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
        _balance.text = _clicker.Money.ToFormattedString();
        _autoIncome.text = $"+{_autoClicker.AutoIncomePower.ToFormattedString()} в сек.";
        _clickPowerText.text = $"+{_clicker.ClickPower.ToFormattedString()} за клик";
    }
}