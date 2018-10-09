using UnityEngine;

public class ItemPickup : Interactable {

    public Item item;

    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    void Awake()
    {
        if (Inventory.instance.HasItem(item))
        {
            Destroy(gameObject);
        }
    }

    void PickUp()
    {
        Debug.Log(" --> agarra el alfiler? ");

        Inventory.instance.Add(item);
        Debug.Log(Inventory.instance.items);
        Destroy(gameObject);
    }

    public override void Grab()
    {
        base.Grab();
        // Se agrega al inventario
        Inventory.instance.Add(item);
        // Se borra de la escena
        Destroy(gameObject);
    }
    
    public override void Talk()
    {
        base.Talk();
    }

    public override void View()
    {
        base.View();
    }
}
