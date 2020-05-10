using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Inventory: MonoBehaviour
{
    public List<Item> Items = new List<Item>();

    public int MaximumCapacity;
    public bool ShowInventory = false;
    
    private void start()
    {
        Debug.Log("Created inventory");
        MaximumCapacity = 100000;
    }

    public void AddInitialGun()
    {
        Item MainGun = new Item(1, "Rail Gun", "Amazing Railgun", 2);
        bool Added = AddItem(MainGun);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ShowInventory = !ShowInventory;
            Debug.Log("State of inventory " + ShowInventory);
        }
    }

    private void OnGUI()
    {
        if (ShowInventory)
        {
            GUI.Box(new Rect(80, 50, 400, 200), "Inventory");
            ShowItems();
        }
        
    }

    public void ShowItems()
    {
        if (Items.Count > 0 && ShowInventory)
        {
            int StartingXPosition = 90;
            int StartingYPosition = 60;
            Items.ForEach(item =>
            {
                StartingYPosition = StartingYPosition + 20;
                GUI.TextArea(new Rect(StartingXPosition, StartingYPosition, 100, 20), item.Name, 200);
            });
        }
    }

    public bool AddItem(Item item)
    {
        if (item.Size + GetCurrentUsedSpace() > MaximumCapacity) {
            Debug.Log("You can not carry more, please remove some of the items. This item can not be added " + item.Name);
            return false;
        }

        Items.Add(item);
        return true;
    }

    public int FindDroppedItemIndex(int Id)
    {
        if (Items.Count > 0) {
            return Items.FindIndex(item => item.Id == Id);
        }

        return -1;
    }

    public Item DropItem(int Id)
    {
        var index = FindDroppedItemIndex(Id);
        Item ItemToDrop = Items.Find(item => item.Id == Id);
        Items.RemoveAt(index);
        Debug.Log("Dropped the item " + ItemToDrop.Name);

        return ItemToDrop;
    }


    private int GetCurrentUsedSpace()
    {
        if (Items.Count == 0) return 0;
        
        int total = Items.Sum(item => item.Size);
        return total;
    }

    public Item GetItem(int Id)
    {
        Debug.Log("Retrieving weapon: " + Id);
        Item SelectedItem = Items.Find(item => item.Id == Id);

        Debug.Log("Item retrieved " + SelectedItem.Name);

        return SelectedItem;
    }
}
