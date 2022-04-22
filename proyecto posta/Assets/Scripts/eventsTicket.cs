using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventsTicket : MonoBehaviour
{
    public void TicketFell()
    {
        GameEvents.current.TicketFell();
    }
}
