using UnityEngine;
using System.Collections;


//[ExecuteInEditMode]
public class TileAnimation : MonoBehaviour
{
	[Range(1, 32)]
	public int tileX = 1;
	[Range(1, 32)]
	public int tileY = 1;
	public int maxTileCount = 10;
	[Range(1, 30)]
	public int frame = 10;
	public bool loop = false;

	private float tileSizeX;
	private float tileSizeY;

	private Mesh mesh;
	private Vector3[] vertices;
	private Vector2[] defUV;
	private Vector2[] newUV;

	private float changeTime;
	private int tileIndex;


	void Start ()
	{
		InitVariable ();
	}


	private void InitVariable ()
	{
		tileSizeX = 1.0f / tileX;
		tileSizeY = 1.0f / tileY;
		
		mesh = GetComponent<MeshFilter>().mesh;

		vertices = mesh.vertices;
		defUV = new Vector2[vertices.Length];
		for (int i = 0; i < vertices.Length; ++i)
		{
			defUV[i] = new Vector2(mesh.uv[i].x*tileSizeX, mesh.uv[i].y*tileSizeY + tileSizeY*(tileY-1));
		}
		newUV = new Vector2[vertices.Length];
	}


	void OnEnable ()
	{
		tileIndex = 0;
		changeTime = 1.0f/(float)frame;
		Invoke("UpdateRepeat", changeTime);
	}


	void OnDisable()
	{
		CancelInvoke ();
	}


	void UpdateRepeat ()
	{
		int uIndex = tileIndex % tileX;
		int vIndex = (int)(tileIndex * tileSizeX);
		float offset_u = uIndex * tileSizeX;
		float offset_v = vIndex * tileSizeY;

		for (int i = 0; i < vertices.Length; ++i)
		{
			newUV[i].Set (defUV[i].x + offset_u, defUV[i].y - offset_v);
		}
		mesh.uv = newUV;

		tileIndex++;
		if (tileIndex == maxTileCount)
		{
			if (loop)
				tileIndex = 0;
			else
				return;
		}

		Invoke("UpdateRepeat", changeTime);
	}
}