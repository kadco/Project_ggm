﻿using System.Collections;

using UnityEngine;

// You need to "SndInfo.cs"
// 'SoundObject' Tags must be declared in the tag manager before using them

//GameSnd.Instance.PlaySound("snd_ui_click");  //사용법
public enum eSound : int
{
    bgm_main = 101,
    bgm_battle = 102,

    ui_click = 1000,
    ui_alarm = 1001,
    ui_beep = 1002,
    ui_popup = 1003,

    start = 2000,
    battle_shot = 2001,
    battle_hit = 2002,
    battle_dead = 2003,

    snd_end
};
public class GameSnd : MonoBehaviour 
{				
	//GameObject kRoot = null;	
	//public float fVolume = 1.0f;
	float fVolume_bgm = 1.0f;
	float fVolume_fx = 1.0f;
	
	public GameObject kBgm = null;
	
	ArrayList SourceArray = new ArrayList();
	ArrayList CloneArray = new ArrayList();


	private static GameSnd s_instance = null;	
	public static GameSnd Instance {
		get {
	    	if (s_instance == null) {
				//s_instance = new GameSnd(); //.Net
				s_instance = FindObjectOfType(typeof(GameSnd)) as GameSnd;
	        }
	        return s_instance;
	    }
	}
	
	void Awake () 
	{
		if(s_instance != null) {
			//Debug.LogError("Cannot have two instances of GameSnd."); 
			return; 
		}
		s_instance = this;

		DontDestroyOnLoad(this);
		//Debug.Log("GameSnd Awake");		
	}

	void Start ()
	{
		//kRoot = GameObject.Find("root_sound");				
		//kRoot.transform.position = Camera.mainCamera.transform.position;
		
		//LoadSoundSource();
	}

    /*
	void Update () 
	{
		if( Input.GetKeyDown(KeyCode.Alpha1) )		
		{	
			//PlayBGM( (int)eSound.eBgm_Title );			
		}
		
		if( Input.GetKeyDown(KeyCode.Alpha2) )
		{			
			//PlaySound((int)eSound.eSnd_Attack);
		}

		if( Input.GetKeyDown(KeyCode.R) )
		{	
			RemoveAllClone();			
		}
	}
*/

    //----------------------------------------------
    public void LoadSoundSource()
	{
        AddSource("bgm_main");
    }   
	
	// Add Source ----------------------------------------------------------------
	GameObject AddSource(string _sound_name)
	{
		GameObject kGO = new GameObject();
        //kGO.tag = "SoundObject";	
        kGO.transform.parent = gameObject.transform;
        kGO.transform.position = new Vector3(0, 0, 0);
		kGO.name = _sound_name;
		
		string szPrefab = "";        
        szPrefab = _sound_name;

        // AudioSource
        //if( kGO.audio == null) 
        kGO.AddComponent(typeof(AudioSource));                

        AudioClip audio = (AudioClip)Resources.Load("Sound/" + szPrefab, typeof(AudioClip)); //사운드 폴더
        if (audio == null)
        {
            Debug.Log("ERROR: CGameSound AddSource Load Failed : " + szPrefab);
            Destroy(kGO);
            return null;
        }

		kGO.GetComponent<AudioSource>().clip = audio;
		kGO.GetComponent<AudioSource>().playOnAwake = false;		
		//kGO.audio.volume = 1.0f;
					
		// CSndInfo
		CSndInfo kInfo = (CSndInfo)kGO.GetComponent("CSndInfo");
		if( kInfo == null )	kInfo = (CSndInfo)kGO.AddComponent<CSndInfo>();		
		kInfo.iID 			= kGO.GetInstanceID();			
		kInfo.audiolength 	= kGO.GetComponent<AudioSource>().clip.length;
        kInfo.Index         = (int)0;

        // Add List
        SourceArray.Add( kGO );
		
		return kGO;
			
	}

	GameObject GetSource(string _sound_name)
	{
		foreach ( GameObject kGO in SourceArray )			
		{
            if (kGO == null) continue;
			CSndInfo kObject = (CSndInfo)kGO.GetComponent("CSndInfo");			
			if( kObject.name == _sound_name)
			{
				return kGO;
			}
		}	
		return null;
	}
	
	int GetID( GameObject kGO)
	{
		CSndInfo kInfo = (CSndInfo)kGO.GetComponent("CSndInfo");
		return kInfo.iID;
	}	
	
	// Add Fx Clone	
	GameObject AddClone(string _sound_name, Vector3 pos )
	{
		GameObject kGO = GetSource(_sound_name);
		if( kGO == null) {	
			kGO = AddSource(_sound_name); //없으면 추가
		}
		if( kGO ) {					
			GameObject kGOClone = (GameObject)Instantiate( kGO );
			kGOClone.transform.position = pos;
			
			CSndInfo kInfo = (CSndInfo)kGOClone.GetComponent("CSndInfo");
			kInfo.iID 		= kGOClone.GetInstanceID();
			kInfo.bRemove 	= false;
            kInfo.Index     = 0;

            CloneArray.Add( kGOClone );
			
			return kGOClone;
		}
		return null;
	}
	
	public void RemoveClone( GameObject kGO )
	{	
		CloneArray.Remove( kGO );
		Destroy (kGO); 		
	}
	
	public void RemoveAllClone()
	{
		foreach ( Object obj in CloneArray )
			Destroy (obj); 
		CloneArray.Clear();
	}

	public void RemoveAll()
	{
		//GameObject[] kGOs = GameObject.FindGameObjectsWithTag ("SoundObject");
		//foreach ( Object obj in kGOs ) Destroy (obj); 	
		
		foreach ( Object obj in CloneArray )		
		{
			if(obj) Destroy (obj); 
		}
		CloneArray.Clear();
		
		foreach ( Object obj in SourceArray )
		{
			if(obj) Destroy (obj); 
		}
		SourceArray.Clear();
		
	}	
	
	// Play BGM ----------------------------------------------------------------
	
	public void PlayBGM(string _sound_name)
	{
		if( kBgm != null)
		{
			CSndInfo kInfo = (CSndInfo)kBgm.GetComponent("CSndInfo");
            //print (kInfo._index + " " + _index);
			if( kInfo.name == _sound_name)
				return;
			
			StopBGM();
		}
		
		kBgm = PlaySound(_sound_name, Vector3.zero, true, fVolume_bgm );
		kBgm.transform.parent = gameObject.transform;
		//print("PlayBGM " + _index);
	}

	public void StopBGM()
	{
		GameSnd.Instance.RemoveClone( kBgm );
		//Destroy ( kBgm );
	}

	public void SetVolumeBGM()
	{
		if (kBgm != null)
		{
			kBgm.GetComponent<AudioSource>().volume = fVolume_bgm;
			//kBgm.audio.Play();
		}
	}

	// PlaySound  ---------------------------------------------------------------

	public GameObject PlaySound(string _sound_name)
    {
        return PlaySound(_sound_name, Vector3.zero, false, fVolume_fx);
    }

    public GameObject PlaySound(string _sound_name, Vector3 _pos, bool _loop, float _volume )
	{		
		GameObject kGO = AddClone(_sound_name, _pos);
		if(kGO == null)	return null;
		
		kGO.transform.parent = gameObject.transform; // AudioListener
		kGO.transform.position = new Vector3(0,0,-10);		
				
		if(_loop)
		{			
			kGO.GetComponent<AudioSource>().loop = true;
		}
		else
		{
			kGO.GetComponent<AudioSource>().loop = false;

			CSndInfo kInfo = (CSndInfo)kGO.GetComponent("CSndInfo");
			kInfo.DeathTime = kInfo.audiolength; // 끝나면 삭제.
			kInfo.bRemove = true;
		}
				
		kGO.GetComponent<AudioSource>().playOnAwake = true;
		kGO.GetComponent<AudioSource>().volume = _volume; 		
		kGO.GetComponent<AudioSource>().Play();
        //kGO.audio.PlayOneShot( kGO.audio.clip );

        //print("sound: " + _index + "  _volume: " + _volume);

        return kGO;
	}

    public void StopSound(GameObject go)
    {
        GameSnd.Instance.RemoveClone(go);
    }

	// 간편 사용 //GameSnd.Instance.Sound_play("snd_ui_click");
	public void Sound_play(string _name)
	{
		AudioClip audioClip = Resources.Load("Sound/" + _name) as AudioClip;
		//AudioSource audioSource = new AudioSource();
		AudioSource audioSource = GetComponent<AudioSource>();
		if (audioSource == null) audioSource = gameObject.AddComponent<AudioSource>();
		//audioSource.PlayOneShot(audioClip);
		audioSource.clip = audioClip;
		audioSource.loop = false;
		audioSource.Play();
	}
}

public class CSndInfo : MonoBehaviour
{
    public int      iID = 0; //고유번호
	public int		Index = 0; //사운드 인덱스
	public float	audiolength = 0.0f;
	public bool     bLoop = false;
    public bool     bRemove = false;
    public float    DeathTime = 0.0f;

    void Update()
    {
        if (bRemove)
        {
            DeathTime -= Time.deltaTime;
            if (DeathTime <= 0.0f) {
				//Destroy( gameObject );
				GameSnd.Instance.RemoveClone(gameObject);                
            }
        }

		//// playOneShot
		//if(audio != null && !bLoop) 
		//	if(!audio.isPlaying)
		//	{
		//		Destroy( gameObject );
		//	}
	}

}


