using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialog;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<DialogManager>().StartDialog(dialog);
        }
    }
    /////
}
