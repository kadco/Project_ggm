// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/SilhouetteOutline"
{
	Properties
	{
		_Color("Tint Color", Color) = (.5,.5,.5,1)
		_MainTex("Base (RGB)", 2D) = "white" {}
		_Intensity("Intensity", Range(0.0, 3.0)) = 1
		_OutlineColor("Outline Color", Color) = (0,0,0,1)
		_Outline("Outline Width", Range(.001, 0.05)) = .005
	}

	SubShader
	{
		Tags{ "Queue" = "Geometry+1" "RenderType" = "Opaque" }

		// Silhouette Outline
		Pass
		{
			Tags{ "LightMode" = "Always" }
			Name "Silhouette"

			Cull Front
			ZTest Always
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			uniform float _Outline;
			uniform float4 _OutlineColor;

			// Vertex Input
			struct appdata
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
			};

			// Vertex Output
			struct v2f
			{
				float4 pos : POSITION;
				float4 color : COLOR;
			};

			// Vertex Shader
			v2f vert(appdata v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);

				float3 norm = mul((float3x3)UNITY_MATRIX_IT_MV, v.normal);
				float2 offset = TransformViewToProjection(norm.xy);

				//o.pos.xy += offset * o.pos.z * _Outline;
				o.pos.xy += offset * _Outline;
				o.color = _OutlineColor;

				return o;
			}

			// Fragment Shader
			half4 frag(v2f i) :COLOR{ return i.color; }
			ENDCG
		}

		Tags{ "Queue" = "Geometry+2" "RenderType" = "Opaque" }

		// Base
		Pass
		{
			Name "BASE"
			Cull Off
			ZWrite On

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma fragmentoption ARB_precision_hint_fastest 

			#include "UnityCG.cginc"

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float4 _Color;
			float _Intensity;

			struct appdata
			{
				float4 vertex : POSITION;
				float2 texcoord : TEXCOORD0;
				float3 normal : NORMAL;
			};

			struct v2f
			{
				float4 pos : POSITION;
				float2 texcoord : TEXCOORD0;
			};

			v2f vert(appdata v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
				return o;
			}

			float4 frag(v2f i) : COLOR
			{
				float4 col = _Color * tex2D(_MainTex, i.texcoord);
				return float4(2.0f * _Intensity * col.rgb, col.a);
			}

			ENDCG
		}

	} FallBack "Diffuse"
}