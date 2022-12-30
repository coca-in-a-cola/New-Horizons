using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    private float radius = 3f;

    private bool isFocused = false;
    private GameObject player = null;

    public virtual void OnInteract(GameObject player)
    {
        Debug.Log(player.name + "is Interacting with " + transform.name);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFocused)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance <= radius)
            {
                Debug.Log("Interact");
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    
    public void onFocused(GameObject player)
    {
        isFocused = true;
        this.player = player;
        OnInteract(player);
    }

    public void onDefocused()
    {
        isFocused = false;
        player = null;
    }
}
