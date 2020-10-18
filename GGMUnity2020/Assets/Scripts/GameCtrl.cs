using UnityEngine;
using System.Collections;

public enum GameCtrl_End
{
	Do_Nothing,
	Pos_org,
	Scale_org,
	Destroy,
};

public class GameCtrl : MonoBehaviour 
{		
	//public Color fColor = Color.clear;
	//public float fAlpha;

	float	fAlphaFrom;
	float	fAlphaTo;
	
	bool 	bFade = false;
	float	fFadeTime;
	float	fFadeDuration = 1.0F;	
	Color	fColorFrom;
	Color	fColorTo;

	bool 	bFlick = false;
	float	fFlickTime;
	float	fFlickDuration = 1.0F;	
	float	fFlickDelay = 1.0f;
	int 	iFlickMode = 0;

	bool 	bScale = false;
	float	fScaleTime;
	float	fScaleFr_x;
	float	fScaleTo_x;	
	float	fScaleFr_y;
	float	fScaleTo_y;		
	float	fScaleDuration = 1.0F;
	Vector3	kScale_org;

	bool 	bMove = false;
	float	fMoveTime;
	Vector3	kMoveFrom;
	Vector3	kMoveTo;	
	float	fMoveDuration = 1.0F;	
	Vector3	kMovePos_org;
	
	bool 	bMoveFire = false;
	bool 	bMoveAfter = false;

	GameCtrl_End kEndAction_fade;
	GameCtrl_End kEndAction_move;
	GameCtrl_End kEndAction_scale;	
		
	void Awake() 
	{
        //if (GetComponent<Renderer>().material.HasProperty("_Color"))
        //GetComponent<Renderer>().material.ColorSet("_Color", Color.clear);
    }

    void Start()
	{
		//FadeIn(2.0f, GameCtrl_End.Destory);
	}

	void Update()
	{
		if( bMove )
		{
			fMoveTime += Time.deltaTime;

			float lerp =  Mathf.Clamp01( fMoveTime / fMoveDuration );
			Vector3 lerpedMove = Vector3.Lerp( kMoveFrom, kMoveTo, lerp);

			gameObject.transform.position = lerpedMove;

			if( bMoveFire )
			{
				float fV = lerp; if(lerp > 0.5f ) fV = 1 - lerp;	//jump
				gameObject.transform.position += new Vector3( 0, fV * 8.0f, 0);
			}

			if( lerp == 1.0f)
			{
				bMove = false;
				bMoveFire = false;
				fMoveTime = 0.0f;
				
				if(kEndAction_move == GameCtrl_End.Pos_org)
				{
					gameObject.transform.position = kMovePos_org;
				}
				
				if(kEndAction_move == GameCtrl_End.Destroy)
					Destroy( gameObject );
			}
		}
		
		if( bMoveAfter)
		{
			fMoveTime += Time.deltaTime;
			float lerp =  Mathf.Clamp01( fMoveTime / fMoveDuration );
			if( lerp == 1.0f)
			{
				bMoveAfter = false;
				fMoveTime = 0.0f;

				gameObject.transform.position = kMoveTo;
				
				if(kEndAction_move == GameCtrl_End.Destroy)
					Destroy( gameObject );
			}			
		}

		if( bScale )
		{
			fScaleTime += Time.deltaTime;
			
			float lerp =  Mathf.Clamp01( fScaleTime / fScaleDuration );			
			float lerpedScale_x = Mathf.Lerp( fScaleFr_x, fScaleTo_x, lerp);
			float lerpedScale_y = Mathf.Lerp( fScaleFr_y, fScaleTo_y, lerp);
			gameObject.transform.localScale = new Vector3 (lerpedScale_x,lerpedScale_y,1.0f );

			if( lerp == 1.0f)
			{
				bScale = false;
				fScaleTime = 0.0f;

				if(kEndAction_scale == GameCtrl_End.Scale_org)
					gameObject.transform.localScale = kScale_org;

				if(kEndAction_scale == GameCtrl_End.Destroy)
					Destroy( gameObject );
			}
		}

		if( bFade )
		{
			fFadeTime += Time.deltaTime;
			
			float lerp =  Mathf.Clamp01( fFadeTime / fFadeDuration );			
			Color lerpedColor = Color.Lerp( fColorFrom, fColorTo, lerp);

            ColorSet(lerpedColor);

            if ( lerp == 1.0f)
			{
				bFade = false;
				fFadeTime = 0.0f;

				if(kEndAction_fade == GameCtrl_End.Destroy)
					Destroy( gameObject );
			}
		}

		if( bFlick )
		{
			if( iFlickMode == 0)
			{
				fFlickTime += Time.deltaTime;

				float lerp =  Mathf.Clamp01( fFlickTime / fFlickDuration );			
				Color lerpedColor = Color.Lerp( fColorFrom, fColorTo, lerp);

                ColorSet(lerpedColor);

                if ( lerp == 1.0f)
				{
					fFlickTime = 0.0f;
					iFlickMode++;
				}
				
			}
			else if( iFlickMode == 1)
			{
				fFlickTime += Time.deltaTime;

				float lerp =  Mathf.Clamp01( fFlickTime / fFlickDuration );			
				Color lerpedColor = Color.Lerp( fColorTo, fColorFrom, lerp);

                ColorSet(lerpedColor);

                if ( lerp == 1.0f)
				{
					fFlickTime = 0.0f;
					iFlickMode++;
				}
			}
			else
			{
				fFlickTime += Time.deltaTime;

				if( fFlickTime >= fFlickDelay)
				{
					fFlickTime = 0.0f;
					iFlickMode = 0;
				}
			}
		}
	}

	public void AlpaSet( float fValue)
	{

		if(!GetComponent<Renderer>())	return;
		if(!GetComponent<Renderer>().material)	return;
				
		Color c = GetComponent<Renderer>().material.color;
		c.a = fValue;
        GetComponent<Renderer>().material.color = c;
	}
	
	public void ColorSet(Color _color)
	{
		if(!GetComponent<Renderer>())	return;
		if(!GetComponent<Renderer>().material)	return;

        GetComponent<Renderer>().material.SetColor("_Color", _color);

        foreach (Transform child in transform)
        {
            if (!child.gameObject.GetComponent<Renderer>()) continue;
            if (!child.gameObject.GetComponent<Renderer>().material) continue;

            child.gameObject.GetComponent<Renderer>().material.SetColor("_Color", _color);
        }

	}


	public void ScaleSet(float _value)
	{
		gameObject.transform.localScale = new Vector3 (_value,_value,1.0f );
	}	
	public void ScaleSet(Vector3 _value)
	{
		gameObject.transform.localScale = _value;
	}		
	
	public void Move(float _duration, Vector3 _from, Vector3 _to, GameCtrl_End _end)
	{	
		bMove = true;
		fMoveTime = 0.0f;	
		fMoveDuration = _duration;
		kMoveFrom = _from;
		kMoveTo = _to;
		kEndAction_move = _end;
		
		kMovePos_org = gameObject.transform.position;
	}
	
	public void MoveAfter(float _duration, Vector3 _from, Vector3 _to, GameCtrl_End _end)
	{	
		bMoveAfter = true;
		fMoveTime = 0.0f;
		fMoveDuration = _duration;
		kMoveFrom = _from;
		kMoveTo = _to;
		kEndAction_move = _end;
		
		gameObject.transform.position = kMoveFrom;		
	}	

	public void MoveFire(float _duration, Vector3 _from, Vector3 _to, GameCtrl_End _end)
	{	
		bMoveFire = true;
		Move( _duration, _from, _to, _end );
	}	

	public void Scale(float _duration, float _from, float _to, GameCtrl_End _end)
	{	
		bScale = true;
		fScaleTime = 0.0f;
		fScaleDuration = _duration;
		fScaleFr_x = _from;
		fScaleTo_x = _to;	
		fScaleFr_y = _from;
		fScaleTo_y = _to;
		
		kEndAction_scale = _end;
		
		kScale_org = gameObject.transform.localScale;
	}
	public void Scale(float _duration, Vector3 _from, Vector3 _to, GameCtrl_End _end)
	{	
		bScale = true;
		fScaleTime = 0.0f;	
		fScaleDuration = _duration;
		fScaleFr_x = _from.x;
		fScaleTo_x = _to.x;	
		fScaleFr_y = _from.y;
		fScaleTo_y = _to.y;
		
		kEndAction_scale = _end;
		
		kScale_org = gameObject.transform.localScale;
	}	
	
	public void Fade(float _duration, Color _from, Color _to, GameCtrl_End _end)
	{	
		bFade = true;
		fFadeTime = 0.0f;
		fFadeDuration = _duration;		
		fColorFrom = _from;
		fColorTo = _to;		
		kEndAction_fade = _end;
	}
	public void FadeIn(float _duration, GameCtrl_End _end)
	{
		fColorFrom = Color.black;
		fColorTo = Color.clear;
		Fade(_duration, fColorFrom, fColorTo, _end);
	}
	public void FadeOut(float _duration, GameCtrl_End _end)
	{
		fColorFrom = Color.clear;
		fColorTo = Color.black;
		Fade(_duration, fColorFrom, fColorTo, _end);
	}

	public void Flick(float _duration, float _delay, Color _from, Color _to )
	{	
		bFlick= true;
		fFlickTime = 0.0f;		
		fFlickDuration = _duration;		
		fFlickDelay = _delay;
		fColorFrom = _from;
		fColorTo = _to;
		iFlickMode = 0;
	}

	public void FlickOff( Color _color )
	{	
		bFlick= false;
		ColorSet (_color);
	}

/*		
    void OnEZDragDrop(EZDragDropParams parms)
    {
        if(parms.evt == EZDragDropEvent.Dropped)
        {
            parms.dragObj.DropHandled = true;
            Debug.Log(parms.dragObj.name + " was dropped!");

            // Do something to/with the object
            // that was just dropped here.
        }
    }
*/

}


//	Component[] fxs = transform.GetComponentsInChildren(typeof(EffectControl), true);			
//	for(int i=0; i<fxs.Length; ++i)


/*	

// 셰이더의 속성 인자를 제어한다.

public class TestShader : MonoBehaviour {

	float	fColorR;
		
	void Awake() 
	{
		if (renderer.material.HasProperty("_Color"))
		renderer.material.ColorSet("_Color", Color.red);
	}
	
	void Update()
	{
		fColorR = Mathf.PingPong(Time.time, 1.0f);			
		Color color = new Color( fColorR, 0.0F, 0.0F, 1.0F);
		renderer.material.ColorSet("_Color", color);
	}
}
*/

// 특정 칼라에서 특정 칼라로 변경..
/*
public class TestShader : MonoBehaviour 
{
	public Color colorStart = Color.red;
	public Color colorEnd = Color.yellow;
	public float duration = 1.0F;
		
	void Update() 
		{
			float lerp = Mathf.PingPong(Time.time, duration) / duration;
		
			for (int i = 0; i < renderer.materials.Length; i++) 
			{
				renderer.materials[i].color = Color.Lerp(colorStart, colorEnd, lerp);		
			}
		}
	
}
*/
