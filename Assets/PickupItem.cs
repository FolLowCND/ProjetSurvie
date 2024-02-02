using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField]
    private float pickupRange = 2.6f;
    public PickupBehavior playerPickupBehavior;


    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, pickupRange))
        {
            if (hit.transform.CompareTag("Item"))
            {
                Debug.Log("Item vu");


                if (Input.GetKeyDown(KeyCode.E))
                {
                    playerPickupBehavior.DoPickup(hit.transform.gameObject.GetComponent<Item>());
                }
            }
        }
    }
}
