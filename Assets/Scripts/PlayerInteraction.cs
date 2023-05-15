using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public Camera mainCam;
    public float interactionDistance;

    public TextMeshProUGUI interactionText;

    [SerializeField]
    private InputActionReference actionReference;

    private IInteractable interactable = null;

    void Start()
    {
        actionReference.action.started += ctx => {
            if (interactable != null) {
              interactable.Interact();
            }
        };
    }

    void Update()
    {
        InteractionRay();
    }

    void InteractionRay()
    {
        Ray ray = mainCam.ViewportPointToRay  (Vector3.one / 2f);
        RaycastHit hit;

        bool hitSomething = false;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
          interactable = hit.collider.GetComponent<IInteractable>();

          if (interactable != null)
          {
            hitSomething = true;
            interactionText.text = interactable.GetDescription();
            /*
            if (actionReference.action.IsPressed())
            {
              interactable.Interact()
            };*/
          }
          interactionText.enabled = hitSomething;
          //interactionUI.SetActive(hitSomething);
        }
    }
}
