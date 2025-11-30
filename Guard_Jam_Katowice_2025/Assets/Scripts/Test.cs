using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] public DialogueController dialogueController;
    [SerializeField] Dialogue dialogue;
    void Update()
    {

     
        if (Input.GetMouseButtonDown(1))
        {
            // StatisticsManager.Instance.ChangeHunger(-10);
            // StatisticsManager.Instance.ChangeMorale(-40);

            dialogueController.GenerateNewDialogue(dialogue);
          
        }
   
     
    }
}
