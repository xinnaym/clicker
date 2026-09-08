using System;
using System.Collections.Generic;
using UnityEngine;

public enum ProductType
{
    click, autoClick
}

[System.Serializable]
public struct ProductItem
{
    public ProductType Type;
    public string RuName;
    public Sprite Icon;
}

[CreateAssetMenu(fileName = "ProductsCatalog", menuName = "Scriptable Object/Products Catalog")]
public class ProductInfo : ScriptableObject
{
    [SerializeField] private List<ProductItem> _items = new List<ProductItem>();

    public IReadOnlyList<ProductItem> Items => _items;
}