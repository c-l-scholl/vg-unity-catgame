using UnityEngine;
using Image = UnityEngine.UI.Image;

public class UIItem : MonoBehaviour
{

    public InventoryItemData item;

    private Image spriteImage;
    
    private void Awake() {
        spriteImage = GetComponent<Image>();
        UpdateItem(null);
    }

    public void UpdateItem(InventoryItemData item) {
        this.item = item;
        if (this.item != null) {
            spriteImage.color = Color.white;
            spriteImage.sprite = this.item.icon;

        } else {
            spriteImage.color = Color.clear;
        }
    }
}
