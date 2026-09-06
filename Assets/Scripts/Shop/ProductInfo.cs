using UnityEngine;

public enum ProductType
{
    click, autoClick
}

[CreateAssetMenu(fileName = "productInfo", menuName = "Scriptable Object/Product Info")]
public class ProductInfo : ScriptableObject
{
    [SerializeField] private ProductType _type;
    [Space, SerializeField] private float _price;
    [SerializeField] private float _bonusValue;

    [Space, SerializeField] private Sprite _icon;
    [Space, SerializeField] private string _ruName;
    [Space, SerializeField] private string _enName;

    public ProductType Type => _type;
    public float Price => _price;
    public float BonusValue => _bonusValue;
    public Sprite Icon => _icon;
    public string RuName => _ruName;
    public string EnName => _enName;
}
