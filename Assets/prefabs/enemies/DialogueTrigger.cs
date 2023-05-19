using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] DialogueController dialogueController;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            dialogueController.StartDialogue();
        }
    }
}
