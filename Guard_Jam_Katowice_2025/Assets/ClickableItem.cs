using UnityEngine;

public class ClickableItem : MonoBehaviour
{
    [SerializeField] private Item item;
    private void OnMouseDown()
    {
        InventoryManager.Instance.AddItemToList(item);
    }
}
