using UnityEngine;

public class Interactable : MonoBehaviour {

    public bool selected = false;

    public virtual void Interact() { }

    void Update()
    {
        // Falta el codigo
        if (selected)
        {
            Debug.Log("---- llego al interactable ----");
            Interact();
            selected = false;
        }
    }

    void ShowMenu()
    {

    }

    void CloseMenu()
    {

    }

    public virtual void View() { }

    public virtual void Grab() { }

    public virtual void Talk() { }
}
