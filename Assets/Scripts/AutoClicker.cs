using System.Collections;
using System.Xml.Serialization;
using UnityEngine;

public class AutoClicker : MonoBehaviour
{
    [SerializeField] private Clicker _clicker;
    [SerializeField] private float _autoIncomePower;

    public float AutoIncomePower => _autoIncomePower;

    private void Awake()
    {
        StartCoroutine(AutoIncome());
    }

    private IEnumerator AutoIncome()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            _clicker.Money += _autoIncomePower;
        }
    }

    public void UpgradeAutoIncomePower(float bonus)
    {
        _autoIncomePower += bonus;
    }
}
