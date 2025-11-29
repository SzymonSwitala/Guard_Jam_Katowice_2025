using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] Item item;
    void Update()
    {

       
        if (Input.GetMouseButtonDown(0))
        {
            if (InventoryManager.Instance.HasItem(item.name))
            {
                InventoryManager.Instance.RemoveItemByName(item.name);

            }
        }

     
    }
}
