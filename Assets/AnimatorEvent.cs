using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorEvent : MonoBehaviour
{
    [SerializeField]
    private DishwasherInteractor di;

    public void ClosedDoor()
    {
        di.DoorClosed();
    }
}
