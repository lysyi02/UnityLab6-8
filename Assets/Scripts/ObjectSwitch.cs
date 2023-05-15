using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSwitch : MonoBehaviour, IInteractable
{
    public GameObject obj;
    public bool isActive = true;

    public string activateText = "Activate";
    public string deactivateText = "Deactivate";

    void Start()
    {
        obj.SetActive(isActive);
    }

    public string GetDescription()
    {
      if (!isActive) return activateText;
      return deactivateText;
    }

    public void Interact()
    {
      isActive = !isActive;
      obj.SetActive(isActive);
    }
}
