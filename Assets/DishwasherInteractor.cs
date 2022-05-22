using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishwasherInteractor : MonoBehaviour
{
    [SerializeField]
    private ObjectManipulator dishwasherManipulator;
    [SerializeField]
    private ObjectManipulator middleTrayManipulator;
    [SerializeField]
    private ObjectManipulator upperTrayManipulator;
    [SerializeField]
    private BoxCollider dishwasherCollider;
    [SerializeField]
    private BoxCollider dishwasherDoor;
    [SerializeField]
    private BoxCollider middleTray;
    [SerializeField]
    private BoxCollider upperTray;
    [SerializeField]
    private GameObject[] trayArrayColliderObjects;
    [SerializeField]
    private GameObject plate;
    [SerializeField]
    private GameObject table;
    [SerializeField]
    private GameObject sceneObjects;
    [SerializeField]
    private Camera holoLens;
    [SerializeField]
    private Animator anim;
    private bool opened = false;
    private bool locked = false;

    public void LockDishwasher()
    {
        if(!locked)
        {
            locked = true;
            dishwasherManipulator.enabled = false;
            dishwasherCollider.enabled = false;
            dishwasherDoor.enabled = false;
            middleTray.enabled = true;
            upperTray.enabled = true;

            foreach (GameObject go in trayArrayColliderObjects)
            {
                go.SetActive(true);
            }
        }
        else if(locked)
        {
            locked = false;
            dishwasherManipulator.enabled = true;
            dishwasherCollider.enabled = true;
            dishwasherDoor.enabled = true;
            middleTray.enabled = false;
            upperTray.enabled = false;

            foreach (GameObject go in trayArrayColliderObjects)
            {
                go.SetActive(false);
            }
        }
    }

    public void ToggleDoor()
    {
        if(opened)
        {
            CloseDoor();
        }
        else
        {
            OpenDoor();
        }
    }

    public void OpenDoor() 
    {
        opened = true;
        anim.SetBool("closed", false);
        anim.SetBool("open", true);
    }

    public void CloseDoor()
    {
        opened = false;
        anim.SetBool("open", false);
    }

    public void DoorClosed()
    {
        anim.SetBool("closed", true);
    }

    public void ResetPositions()
    {
        plate.transform.localPosition = new Vector3(0.15f, 0.065f, 0);

        sceneObjects.transform.position = holoLens.transform.position;

    }

    public void ToggleTable()
    {
        table.SetActive(!table.activeSelf);
    }
}
