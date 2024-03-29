using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<ItemData> content = new List<ItemData>();


    [SerializeField]
    private GameObject inventoryPanel;


    [SerializeField]
    private Transform inventorySlotsParent;

    const int InventorySize = 24;


    [Header("Action Panel References")]


    [SerializeField]
    private GameObject actionPanel;
    [SerializeField]
    private GameObject useItemButton;
    [SerializeField]
    private GameObject equipItemButton;
    [SerializeField]
    private GameObject dropItemButton;
    [SerializeField]
    private GameObject destroyItemButton;

    [SerializeField]
    private Sprite emptySlotVisual;

    private ItemData itemCurrentlySelected;

    [SerializeField]
    private Transform dropPoint;

    public static Inventory instance;


    private void Awake()
    {
        instance = this;
    }





    private void Start()
    {
        RefreshContent();
    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        }
    }


    public void AddItem(ItemData item)
    {
        content.Add(item);
        RefreshContent();
    }


    public void CloseButtonInventory()
    {
        inventoryPanel.SetActive(false);
    }

    private void RefreshContent()
    {
        // on vide tous les slots / visuels
        for (int i = 0; i < inventorySlotsParent.childCount; i++)
        {
            Slot currentSlot = inventorySlotsParent.GetChild(i).GetComponent<Slot>();

            currentSlot.item = null;
            currentSlot.itemVisual.sprite = emptySlotVisual;
        }


        // on peuple le visuel des slots selon l'inventaire
        for (int i = 0; i < content.Count; i++)
        {
            Slot currentSlot = inventorySlotsParent.GetChild(i).GetComponent<Slot>();

            currentSlot.item = content[i];
            currentSlot.itemVisual.sprite = content[i].visual;
        }
    }


    public bool IsFull()
    {
        return InventorySize == content.Count;
    }

    public void OpenActionPanel(ItemData item, Vector3 slotPosition)
    {

        itemCurrentlySelected = item;

        if (item == null)
        {
            actionPanel.SetActive(false);
            return;
        }

        switch (item.itemType)
        {
            case ItemType.Ressource:
                useItemButton.SetActive(false);
                equipItemButton.SetActive(false);
                break;

            case ItemType.Equipement:
                useItemButton.SetActive(false);
                equipItemButton.SetActive(true);
                break;

            case ItemType.Consumable:
                useItemButton.SetActive(true);
                equipItemButton.SetActive(false);
                break;
        }

        actionPanel.transform.position = slotPosition;
        actionPanel.SetActive(true);
    }


    public void CloseActionPanel()
    {

        actionPanel.SetActive(false);
        itemCurrentlySelected = null;
    }

    public void UseActionButton()
    {

        CloseActionPanel();
    }

    public void EquipActionButton()
    {

        CloseActionPanel();
    }

    public void DropActionButton()
    {
        GameObject instantiatedItem = Instantiate(itemCurrentlySelected.prefab);
        instantiatedItem.transform.position = dropPoint.position;
        content.Remove(itemCurrentlySelected);
        RefreshContent();
        CloseActionPanel();
    }

    public void DestroyActionButton()
    {
        content.Remove(itemCurrentlySelected);
        RefreshContent();
        CloseActionPanel();
    }
}
