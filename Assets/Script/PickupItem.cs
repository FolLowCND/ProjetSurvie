using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField]
    private float pickupRange = 2.6f;

    public PickupBehavior playerPickupBehavior;


    [SerializeField]
    private GameObject messageRammassage;


    [SerializeField]
    private LayerMask layerMask;

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, pickupRange, layerMask))
        {
            if (hit.transform.CompareTag("Item"))
            {
                messageRammassage.SetActive(true);


                if (Input.GetKeyDown(KeyCode.E))
                {
                    playerPickupBehavior.DoPickup(hit.transform.gameObject.GetComponent<Item>());
                }
            }
        }
        else 
        {
            messageRammassage.SetActive(false);
        }
    }
}
