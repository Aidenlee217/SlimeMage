using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRInventory : MonoBehaviour{

    #region Singleton

    public static VRInventory instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of inventory found!");
        }
        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 30;

    public List<Item> items = new List<Item>();

    public bool Add (Item item)
    {
        if (!item.isDefaultItem)
        {
            if(items.Count >= space)
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

    public void Remove (Item item)
    {
        items.Remove(item);
    }

}