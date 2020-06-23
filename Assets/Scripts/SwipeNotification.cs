using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeNotification : MonoBehaviour
{
    public GameObject Notification;

    public void Delete()
    {
        Destroy(Notification);
    }
}
