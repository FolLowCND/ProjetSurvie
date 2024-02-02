using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PickupBehavior : MonoBehaviour
{
    [SerializeField]
    private MoveBehaviour playerMoveBehaviour;

    [SerializeField]
    private Animator playerAnimator;


    [SerializeField]
    private Inventory inventory;
    private Item currentItem;

    public void DoPickup(Item item)
    {
        currentItem = item;

        // jouer animation de ramassage
        playerAnimator.SetTrigger("Pickup");

        // bloquer le deplacement du joueur
        playerMoveBehaviour.canMove = false;



    }


    public void AddItemToInventory()
    {
        // Ajouter objet
        inventory.AddItem(currentItem.itemData);

        // Detruire l'item une fois récupéré
        Destroy(currentItem.gameObject);

        currentItem = null;
    }

    public void ReEnablePlayerMove()
    {
        playerMoveBehaviour.canMove = true;
    }

}
