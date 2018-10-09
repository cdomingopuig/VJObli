using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public static Inventory instance;
    private static bool created = false;

    void Awake()
    {
        if (!created)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
    }

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    public List<Item> items = new List<Item>();

    public void Add(Item item)
    {
        items.Add(item);
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

    public bool HasItem(Item item)
    {
        if (items.Contains(item))
            return true;
        return false;
    }

}
