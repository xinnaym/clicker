using System;
using System.Collections;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    [SerializeField] private float _clickPower;
    [SerializeField] private Transform _clickerImage;
    [SerializeField] private float _rotationAngle = 5f;
    [SerializeField] private float _rotationSpeed = 1.5f;
    [SerializeField] private float _scaleResetSpeed = 10f;

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
        _clickerImage.localScale = Vector2.one * 0.9f;

        AudioManager.Instance.PlayClick();
    }

    public void OnClickUp()
    {
        _clickerImage.localScale = Vector2.one;
    }

    public void TriggerRewardClick()
    {
        Money += _clickPower;
        _clickerImage.localScale = Vector2.one * 0.9f;

        AudioManager.Instance.PlayClick();
    }

    public void UpgradeClickPower(float bonus)
    {
        _clickPower += bonus;
    }

    private void Update()
    {
        float angle = Mathf.Sin(Time.time * _rotationSpeed) * _rotationAngle;
        _clickerImage.localRotation = Quaternion.Euler(0f, 0f, angle);

        _clickerImage.localScale = Vector3.Lerp(_clickerImage.localScale, Vector3.one, Time.deltaTime * _scaleResetSpeed);
    }
}