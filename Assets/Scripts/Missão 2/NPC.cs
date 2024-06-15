using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public float interactionDistance = 3.0f;
    public GameObject interactionUI;
    public string itemName;

    private bool isInteracting = false;
    private bool playerInRange = false;

    void Update()
    {
        if (playerInRange && !isInteracting)
        {
            interactionUI.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                Interact();
            }
        }
        else
        {
            interactionUI.SetActive(false);
        }
    }

    void Interact()
    {
        isInteracting = true;
        PlayerInventory.Instance.AddItem(itemName);
        interactionUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
