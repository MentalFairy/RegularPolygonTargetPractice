Shader "Custom/TrippyBackground"
{
    Properties
    {
        _Speed ("Speed", Range(0, 10)) = 3
        _Intensity ("Color Intensity", Range(0, 5)) = 2
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            float _Speed;
            float _Intensity;

            v2f vert(appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float time = _Time.y * _Speed;

                // Create shifting RGB channels based on sine waves
                float r = sin(i.uv.x * 10.0 + time) * 0.5 + 0.5;
                float g = sin(i.uv.y * 10.0 + time * 1.2) * 0.5 + 0.5;
                float b = cos((i.uv.x + i.uv.y) * 10.0 + time * 1.5) * 0.5 + 0.5;

                // Add warping effect
                float warpX = sin(i.uv.y * 10.0 + time) * 0.05;
                float warpY = cos(i.uv.x * 10.0 + time * 0.8) * 0.05;
                float2 warpedUV = i.uv + float2(warpX, warpY);

                // Random noise flickering effect
                float noise = frac(sin(dot(warpedUV * 50.0, float2(12.9898, 78.233))) * 43758.5453);
                float flicker = lerp(0.5, 1.5, noise * sin(time * 3.0));

                return fixed4(r, g, b, 1.0) * _Intensity * flicker;
            }
            ENDCG
        }
    }
}
