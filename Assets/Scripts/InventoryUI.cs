using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryUI : MonoBehaviour {

    public GameObject inventoryUI;
    public Transform itemsParent;
    private static bool created = false;

    Inventory inventory;

    // Use this for initialization
    void Start()
    {

    }

    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            inventory = Inventory.instance;
            inventory.onItemChangedCallback += UpdateUI;
            created = true;
            UpdateUI();
        }
    }

    // Update is called once per frame
    void Update () {
        
    }

    public void UpdateUI()
    {
        InventorySlot[] slots = GetComponentsInChildren<InventorySlot>();
        for (int i = 0; i < slots.Length; i++)
        {
            Debug.Log("UpdateUI " + i);
            if (i < inventory.items.Count)
                slots[i].AddItem(inventory.items[i]);
            else
                slots[i].ClearSlot();
        }
    }
}
