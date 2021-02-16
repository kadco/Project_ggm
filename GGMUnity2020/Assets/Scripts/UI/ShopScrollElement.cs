using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShopScrollElement : MonoBehaviour
{

    public Button buttonComponent;

	public Image 	iconImage;
    public Text 	nameLabel;    
	public Image 	priceImage;
    public Text 	priceText;
    public Button   buy_button;


    private ShopScrollItem item;
    private ShopScrollList scrollList;

    // Use this for initialization
    void Start()
    {
        buttonComponent.onClick.AddListener(HandleClick);

        buy_button.onClick.AddListener(onClick_buy);
    }

    public void Setup(ShopScrollItem currentItem, ShopScrollList currentScrollList )
    {
        item = currentItem;
        scrollList = currentScrollList;
        
        //ui
        //CGame.Instance.Icon_set_by_item_index(item.item_index, iconImage);        
        //nameLabel.text = item.itemName;
        //CGame.Instance.Icon_set_by_price_type(item.price_type, priceImage);
        //priceText.text = item.price_value.ToString();        
    }



    public void HandleClick()
    {
        //print("click" + nameLabel.text);
        //scrollList.TryTransferItemToOtherShop(item);
    }

    public void onClick_buy()
    {
        print("buy" + item.uid);

        if (scrollList.OnEventCallback != null)
            scrollList.OnEventCallback(item.uid, "buy");
    }    
}