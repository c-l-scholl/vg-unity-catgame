using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkToNPC : MonoBehaviour
{
    private bool startedConversation = false;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.TryGetComponent(out NpcInteraction npc))
        {
            if (Input.GetKey(KeyCode.Space) && !startedConversation)
            {
                npc.TalkToCat();
                startedConversation = true;
            }
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out NpcInteraction npc))
        {
            startedConversation = false;
        }
    }
}
