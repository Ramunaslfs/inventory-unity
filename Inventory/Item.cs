using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class Item : MonoBehaviour
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    public string Description { get; set; }
    public int Size { get; set; }
    
    
    [Tooltip("Item ID")] 
    public int ItemId;

    [Tooltip("Item name")] 
    public string ItemName;
    
    [Tooltip("Description")] 
    public string ItemDescription;
    
    [Tooltip("Size")] 
    public int ItemSize;
    

    public Item(int Id, string Name, string Description, int Size)
    {
        this.Id = Id;
        this.Name = Name;
        this.Description = Description;
        this.Size = Size;
    }

    void Start()
    {
        Name = ItemName;
        Description = ItemDescription;
        Size = ItemSize;
		Id = ItemId;


 		// Subscribe to pickup action
        Debug.Log("Item has been created" + Name);
    }
    
	void OnTriggerEnter (Collider other) {
         Inventory inventory = other.GetComponent<Inventory>();
         if (inventory) {
    		 bool Added = inventory.AddItem(this);
			 if (Added) {
	             Destroy(gameObject);
	        }
        }
    }
}
