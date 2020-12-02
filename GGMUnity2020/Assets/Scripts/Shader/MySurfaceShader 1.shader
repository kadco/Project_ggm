Shader "Custom/MySurfaceShader1"
{
    Properties
    {
        _MainTex("Albedo (RGB)", 2D) = "white" {}
    }
    SubShader
    {
        CGPROGRAM
            #pragma surface surf Standard fullforwardshadows
            #pragma target 3.0

            sampler2D _MainTex;

            struct Input
            {
                float2 uv_MainTex;
            };

            void surf(Input IN, inout SurfaceOutputStandard o)
            {
                fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
                o.Albedo = c.rgb;
                o.Alpha = c.a;
            }
        ENDCG
    }
}
