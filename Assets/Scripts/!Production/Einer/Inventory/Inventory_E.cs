using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_E : MonoBehaviour
{

    #region Singleton

    public static Inventory_E instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of inventory found!");
        }
        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 30;

    public List<Item_E> items = new List<Item_E>();

    public bool Add(Item_E item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("Not enough space.");
                return false;
            }
            items.Add(item);

            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }
        return true;
    }

    public void Remove(Item_E item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}