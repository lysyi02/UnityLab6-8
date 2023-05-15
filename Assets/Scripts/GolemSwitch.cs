using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemSwitch : MonoBehaviour, IInteractable
{
    public GameObject golem, fire;
    public float offset = 0.2f;
    void Start()
    {
    }

    public string GetDescription()
    {
      return "Rage the Golem";
    }

    public void Interact()
    {
      golem.GetComponent<Animator>().Play("Rage");
      Invoke("FireOn", offset);
      Invoke("FireOff", 1.3f);
    }

    private void FireOn() {
      fire.SetActive(true);
    }

    private void FireOff() {
      fire.SetActive(false);
    }
}
