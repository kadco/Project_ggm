using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class ShopScrollItem
{
    public long uid;
    public string itemName;
    public int item_index = 0;
    public int item_value = 0;
    public string price_type = "";
    public int price_value = 0;
}

//ScrollView 에 추가해서 풀링하기
//동적 추가를 위해서는 //하위 폴더 Content에 Content Size  Filter , Vertical Layout Group 추가

public class ShopScrollList : MonoBehaviour
{
	public List<ShopScrollItem> itemList;
	public Transform contentPanel;
	public GameObject element;
	ShopScrollObjectPool ObjectPool;

	public delegate void EventCallback(long _uid, string _order); //kdw add
	public EventCallback OnEventCallback;

    //public float gold = 20f;

    //Player kPlayer;

    private void Awake()
    {
        //kPlayer = CGame.Instance.kPlayer;
        //CGame.Instance.Root_ui = GameObject.Find("Canvas_window");

		ObjectPool = gameObject.AddComponent<ShopScrollObjectPool>();
		ObjectPool.prefab = element;
	}

    // Use this for initialization
    void Start()
    {
        //CGameTable.Instance.kInfo_shop

        
    }

    //------------------------------------------------------------
    public void Setup(EventCallback _callback, int _mode)
    {
        OnEventCallback = _callback;

        //add item
        itemList.Clear();
        ShopScrollItem item1 = new ShopScrollItem(); item1.uid = 1; item1.itemName = "test1"; item1.item_value = 100;
        itemList.Add(item1);
/*
        // 목록 초기화.
        itemList.Clear();
        for (int i = 0; i < CGameTable.Instance.kInfo_shop.Length; i++)
        {
            TableInfo_shop table = CGameTable.Instance.kInfo_shop[i];
            if (table == null) continue;
            if (_mode == 1) if (table.index < 7200 || table.index > 7299) continue;    //hero
            if (_mode == 2) if (table.index < 7100 || table.index > 7199) continue;    //coin
            if (_mode == 3) if (table.index < 7000 || table.index > 7099) continue;    //cash

            ShopScrollItem item = new ShopScrollItem();
                item.uid = table.index; //상품목록
                item.itemName = table.name;
                item.item_index = table.item_index;
                item.item_value = table.item_value;
                item.price_type = table.price_type;
                item.price_value = table.price_value;
            itemList.Add(item);
        }
*/


        RefreshDisplay(); //init
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            //Sort();

            RefreshDisplay();
        }
    }

    void RefreshDisplay()
    {
        //myGoldDisplay.text = "Gold: " + gold.ToString();
        RemoveButtons();
        AddButtons();
    }

    private void RemoveButtons()
    {
        while (contentPanel.childCount > 0)
        {
            GameObject toRemove = contentPanel.GetChild(0).gameObject;
            ObjectPool.ReturnObject(toRemove);
        }
    }

    private void AddButtons()
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            ShopScrollItem item = itemList[i];

            GameObject newButton = ObjectPool.GetObject(); //Pool에서 가져온다.
            newButton.transform.SetParent(contentPanel);
            newButton.transform.localScale = new Vector3(1, 1, 1);

            ShopScrollElement element = newButton.GetComponent<ShopScrollElement>();
            element.Setup(item, this); // 초기화.
        }
    }

    public void TryTransferItemToOtherShop(ShopScrollElement item)
    {
/*
        if (otherShop.gold >= item.price)
        {
            gold += item.price;
            otherShop.gold -= item.price;

            AddItem(item, otherShop);
            RemoveItem(item, this);

            RefreshDisplay();
            otherShop.RefreshDisplay();
            Debug.Log("enough gold");
        }
*/
        Debug.Log("attempted");
    }

    void AddItem(ShopScrollItem itemToAdd, ShopScrollList shopList)
    {
        shopList.itemList.Add(itemToAdd);
    }

    private void RemoveItem(ShopScrollItem itemToRemove, ShopScrollList shopList)
    {
        for (int i = shopList.itemList.Count - 1; i >= 0; i--)
        {
            if (shopList.itemList[i] == itemToRemove)
            {
                shopList.itemList.RemoveAt(i);
            }
        }
    }

    void Sort()
    {
        int count = itemList.Count;
        long[] _uid_list = new long[count];

        // 현재 리스트의 정렬할 대상 아이디 추가.
        for (int i = 0; i < count; i++) _uid_list[i] = itemList[i].uid;

        // 특정 기준으로 아이디 정렬.
        SortByOrder(0, _uid_list);
        //for (int i = 0; i < count; i++)  print("" + _uid_list[i]);

        // 정렬된 _uid_list 순서대로 리스트 추가 작업.
        itemList.Clear();
        for (int i = 0; i < count; i++)
        {
            long uid = _uid_list[i];
            ShopScrollItem item = new ShopScrollItem();
                item.uid = uid;
                //todo

            AddItem(item, this);
        }
    }

    // sort card -------------------------------------------------------------------------------------------
    void SortByOrder(int _sort, long[] _uid_list)
    {
        ArrayList SortArray = new ArrayList();

        for (int i = 0; i < _uid_list.Length; i++)
        {
            long uid = _uid_list[i];    //

            // 정렬할 대상을 소트목록에 추가.
            int iValue1 = (int)uid;
            int iValue2 = (int)uid;
            SortArray.Add(new SortunitClass() { m_value1 = iValue1, m_value2 = iValue2, m_uid = uid });

            /*
                        ItemInfo kCard = CGame.Instance.kDef.FindItem(uid); if (kCard == null) continue;
                        TableInfo_card kCardT = CGameTable.instance.Get_TableInfo_card(kCard.iCardIndex);

                        // insert in sort array
                        int iValue1 = kCard.iItem_star;
                        int iValue2 = kCard.iItem_star; //m_value 이 같을땐 m_value2 순서로.

                        // iSortType
                        if (_sort == 0) { iValue = kCard.iItem_star; iValue2 = kCard.iLevel_cur; }      //금은동.star.
                        if (_sort == 1) { iValue = CGame.Instance.kDef.GetCard_ap(kCard); }
                        if (_sort == 2) { iValue = CGame.Instance.kDef.GetCard_hp(kCard); }
                        if (_sort == 3) { iValue = kCard.iLevel_cur; }
                        if (_sort == 4) { iValue = kCard.iItem_attr; }
                        if (_sort == 5) { iValue = kCard.iItem_affi; }

                        SortArray.Add(new SortunitClass() { m_value1 = iValue1, m_value2 = iValue2, m_uid = uid });
            */
        }
        // 정렬한 아이디 목록 갱신.
        if (SortArray.Count > 0)
        {
            SortArray.Sort(new SortunitClassCompare());

            int count = 0;
            foreach (SortunitClass sort in SortArray)
            {
                _uid_list[count] = sort.m_uid; count++; //
                //print( sort.m_uid  + " " + sort.m_value1 );
            }
        }
    }

    public class SortunitClass
    {
        public int m_value1 { get; set; }
        public int m_value2 { get; set; }
        public long m_uid { get; set; }
    }

    public class SortunitClassCompare : IComparer
    {
        public int Compare(object x, object y)
        {
            return Compare((SortunitClass)x, (SortunitClass)y);
        }
        public int Compare(SortunitClass x, SortunitClass y)
        {
            //return x.m_value.CompareTo( y.m_value ); // 작은 순서대로 정렬.
            //return y.m_value.CompareTo( x.m_value ); // 큰 순서대로 정렬.

            // 큰 순서대로 정렬.
            int v = y.m_value1.CompareTo(x.m_value1);
            if (v == 0)
                v = y.m_value2.CompareTo(x.m_value2);   //m_value 이 같을땐 	m_value2.
            return v;
        }
    }
}

// A very simple object pooling class
public class ShopScrollObjectPool : MonoBehaviour
{
	// the prefab that this object pool returns instances of
	public GameObject prefab;

	// collection of currently inactive instances of the prefab
	private Stack<GameObject> inactiveInstances = new Stack<GameObject>();

	// Returns an instance of the prefab
	public GameObject GetObject()
	{
		GameObject spawnedGameObject;

		// if there is an inactive instance of the prefab ready to return, return that
		if (inactiveInstances.Count > 0)
		{
			// remove the instance from teh collection of inactive instances
			spawnedGameObject = inactiveInstances.Pop();
		}
		// otherwise, create a new instance
		else
		{
			spawnedGameObject = (GameObject)GameObject.Instantiate(prefab);

			// add the PooledObject component to the prefab so we know it came from this pool
			ShopScrollObject_pool pooledObject = spawnedGameObject.AddComponent<ShopScrollObject_pool>();
			pooledObject.pool = this;
		}

		// put the instance in the root of the scene and enable it
		spawnedGameObject.transform.SetParent(null);
		spawnedGameObject.SetActive(true);

		// return a reference to the instance
		//Debug.LogWarning(" spawned GameObject - " + spawnedGameObject.name);
		return spawnedGameObject;
	}

	// Return an instance of the prefab to the pool
	public void ReturnObject(GameObject toReturn)
	{
		ShopScrollObject_pool pooledObject = toReturn.GetComponent<ShopScrollObject_pool>();

		// if the instance came from this pool, return it to the pool
		if (pooledObject != null && pooledObject.pool == this)
		{
			// make the instance a child of this and disable it
			toReturn.transform.SetParent(transform);
			toReturn.SetActive(false);

			// add the instance to the collection of inactive instances
			inactiveInstances.Push(toReturn);
			//Debug.LogWarning(" return GameObject - " + toReturn.name);
		}
		// otherwise, just destroy it
		else
		{
			Debug.LogWarning(toReturn.name + " was returned to a pool it wasn't spawned from! Destroying.");
			DestroyImmediate(toReturn);
		}
	}
}

// a component that simply identifies the pool that a GameObject came from
public class ShopScrollObject_pool : MonoBehaviour
{
	public ShopScrollObjectPool pool;
}



/*
    // 아래부터 추가하기
    content 의 pivot 을 0 으로 조정

    // 해당 위치로 이동하기  
    // scrollRect.verticalNormalizedPosition =  컨테츠 위치 / ( 컨텐츠 전체 높이 - 보여지는 영역 높이 )   

Ex) float scrollValue = ( 보여주고 싶은 위치 ) / (scrollRect.content.rect.height -  scrollRect.GetComponent<RectTransform>().rect.height);
    scrollRect.verticalNormalizedPosition = scrollValue; 
 */