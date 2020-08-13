using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    private void PickUp()
    {
        Debug.Log("Picking up " + item.name);
        bool wasPickedUp = Inventory.instance.Add(item); // add pickup item to inventory
        if(wasPickedUp) //if failed, do not destroy item
        {
            Destroy(gameObject);
        }
    }
}
