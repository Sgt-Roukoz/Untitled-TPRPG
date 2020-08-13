using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius =3f;
    bool interacted = false;

    void OnDrawGizmosSelected() {
        Gizmos.color =  Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public virtual void Interact()
    {
        Debug.Log("Picking Up");
        interacted = false;
    }

    private void Update() 
    {
        if (interacted){ // run interact commands
            Interact();
        }
    }

    public void interactRange() // if item is being interacted
    {
        interacted = true;
    }
}
