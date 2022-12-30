using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera cam;

    [SerializeField]
    private Interactable focus;

    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: убрать хардкод ЛКМ
        if (Input.GetMouseButtonDown(0))
        {
            var ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100)) {
                var interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                }

                else UnsetFocus();
            }
        }
    }

    void SetFocus(Interactable interactable)
    {
        if (interactable != focus) {
            if (focus != null)
                focus.onDefocused();
            focus = interactable;
        }

        focus.onFocused(this.gameObject);
    }

    void UnsetFocus()
    {
        if (focus != null)
            focus.onDefocused();
        focus = null;
    }
}
