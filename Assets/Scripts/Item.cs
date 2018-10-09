using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {

    new public string name = "New Item";
    public Sprite icon = null;

    public virtual void Use() { }

    public override bool Equals(object other)
    {
        return ((Item)other).name == name;
    }

}
