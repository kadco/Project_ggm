using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public string ID = "Game";

    private static GameMgr instance = null;
    public static GameMgr Instance { ///게임 매니저 인스턴스에 접근할 수 있는 프로퍼티
        get {
            if (null == instance) return null;
            return instance;
        }
    }

    void Awake()
    {
        if(instance == null) //이 클래스 인스턴스가 탄생했을 때 전역변수 instance
        { 
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else //만약 씬 이동이 되었는데 그 씬에도 GameMgr이 존재할 수도 있다.
        {
            //Destroy(this.gameObject);
            return;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}


/*
 
// Monobehaviour를 상속받지 않고 싱글톤 만들기
 
public class GameMgr
{
    //게임매니저의 인스턴스를 담는 static 변수 //보안을 위해 private으로.
    //이 게임 내에서 게임매니저 인스턴스는 이 instance에 담긴 녀석만 존재하게 할 것이다.
    private static GameMgr instance;

    //게임 매니저 인스턴스에 접근할 수 있는 프로퍼티. static이므로 다른 클래스에서 맘껏 호출할 수 있다.
    public static GameMgr Instance
    {
        get
        {
            if(null == instance)
            {                
                instance = new GameMgr(); //게임 인스턴스가 없다면 하나 생성해서 넣어준다.
            }
            return instance;
        }
    }

    //생성자를 하나 만들어줘서 원하는 세팅을 해주면 좋다.
    public GameMgr()
    {

    }
}
*/
