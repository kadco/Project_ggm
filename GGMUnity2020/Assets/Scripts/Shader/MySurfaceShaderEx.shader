Shader "Custom/MySurfaceShaderEx"
{
	Properties
	{
		_MainTex("Albedo (RGB)", 2D) = "white" {}

		_Color("Main Color", Color) = (1, 1, 1, 1) // 색상을 인자로 추가		
//		_BrightColor("Brightness Area Color", Color) = (1, 1, 1, 1)
//		_DarkColor("Darkness Area Color", Color) = (1, 1, 1, 1)					
	}
	SubShader
	{
		// 태그와 Blend Mode 추가
		Tags {"Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent"}
		Blend SrcAlpha OneMinusSrcAlpha
		CGPROGRAM
			#pragma surface surf Standard fullforwardshadows alpha:fade // alpha:fade 추가
			#pragma target 2.0

			sampler2D _MainTex;

			half4 _Color; // 색상값 선언
//			half4 _BrightColor, _DarkColor;
						
			struct Input
			{
				float2 uv_MainTex;
			};

			void surf(Input IN, inout SurfaceOutputStandard o)
			{
				fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color; // 색상 곱해주는 연산 추가
/*
					// 첫 번째 레이어의 물 색상 계산
					float2 waterUV = IN.uv_MainTex;
					waterUV.x += _Time;
					fixed4 c = tex2D(_MainTex, waterUV);
					// 두 번째 레이어의 물 색상 계산
					float2 waterUV2 = IN.uv_MainTex;
					waterUV2.y += _Time / 2;
					waterUV2.x += _Time / 3;
					fixed4 c2 = tex2D(_MainTex, waterUV2);
					// 두 레이어 병합
					c += c2;
					c = lerp(_DarkColor, _BrightColor, c.r);
*/
				o.Albedo = c.rgb;
				o.Alpha = c.a;
			}
		ENDCG
	}
	FallBack "Diffuse"
}