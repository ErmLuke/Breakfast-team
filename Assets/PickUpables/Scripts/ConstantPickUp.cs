using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantPickUp : MonoBehaviour
{
    public bool hasItem;
    public bool nearItem;
    public bool canPickUp;
    public GameObject eToInteract;
    // Start is called before the first frame update
    void Start()
    {
        eToInteract = GameObject.Find("Interact");
        canPickUp = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (nearItem && !hasItem)
        {
            eToInteract.SetActive(true);
        }
        if (!nearItem)
        {
            eToInteract.SetActive(false);
        }
    }
    IEnumerator PickUpDelay()
    {
        canPickUp = false;
        yield return new WaitForSeconds(0.5f);
        canPickUp = true;
    }
}
