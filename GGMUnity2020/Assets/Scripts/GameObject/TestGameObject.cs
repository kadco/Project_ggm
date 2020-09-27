using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGameObject : MonoBehaviour
{
    GameObject go;

    void Start()
    {
        //객체 생성
        GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);

        //지정된 객체 생성하기
        //GameObject obj = Instantiate(player);

        //객체에 컴포넌트 추가하기
        //obj.AddComponent<Player>();

        //객체에서 컴포넌트 찾기
        //Player p = player.GetComponent<Player>();
        //print(p.nickname);

        //만들어진 게임 오브젝트 불러오기 (프리팹)
        go = GameObject.Instantiate(Resources.Load<GameObject>("cube"));
        go.transform.position = Vector3.zero;

        //객체 제거
        //Destroy(go);
        //Destroy(go, 2.0f);
    }

    void Update()
    {
        
    }
}

/*      
    // List 사용하기      
    List<GameObject> objList = new List<GameObject>();
    for (int i = 0; i < 5; i++)
    {
        GameObject obj = Instantiate(player);
        objList.Add(obj);
    }
    print(objList.Count);
*/

/*
    //FindObjectsOfType 사용하기.
 
    public class Player : MonoBehaviour
    {
    }

    public class Test : MonoBehaviour
    {
        Player[] players = GameObject.FindObjectsOfType<Player>() as Player[];
    }     
*/

/*

    // GameObject에 prefab을 로드
    public GameObject GameObject_from_prefab(string _prefab_name)
    {
        GameObject go = (GameObject)Instantiate(Resources.Load(_prefab_name, typeof(GameObject)));
        return go;
    }
    // GameObject에 prefab을 로드하여 어태치하기
    public GameObject GameObject_from_prefab(string _prefab_name, GameObject _parent)
    {
        GameObject go = (GameObject)Instantiate(Resources.Load(_prefab_name, typeof(GameObject)));
        if (_parent != null) go.transform.SetParent(_parent.transform);
        go.transform.localScale = Vector3.one;
        go.transform.localPosition = Vector3.zero;
        return go;
    }

    // 객체의 이름을 통하여 자식 요소를 찾아서 리턴하는 함수 
    //UILabel _label = CGame.Instance.GameObject_get_child(obj, "_label").GetComponent<UILabel>();
    public GameObject GameObject_get_child(GameObject source, string strName)
    {
        Transform[] AllData = source.GetComponentsInChildren<Transform>(true); //비활성포함.

        GameObject target = null;

        foreach (Transform Obj in AllData)
        {
            if (Obj.name == strName)
            {
                target = Obj.gameObject;
                break;
            }
        }
        return target;
    }

    //객체에 붙은 Child를 제거
    public void GameObject_del_child(GameObject source)
    {
        Transform[] AllData = source.GetComponentsInChildren<Transform>(true); //비활성포함.
        foreach (Transform Obj in AllData)
        {
            if (Obj.gameObject != source) //자신 제외. 
            {
                Destroy(Obj.gameObject);
            }
        }
    }
*/
