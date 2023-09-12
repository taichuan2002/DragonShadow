Shader "Hidden/NewImageEffectShader"
{
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Tint Color", Color) = (1,1,1,1)
        _Center ("Center of Half Circle", Vector) = (0.5, 0.5, 0, 0)
    }

    SubShader {
        Tags {"Queue"="Transparent" "RenderType"="Transparent"}
        LOD 100

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _Color;
            float4 _Center;

            v2f vert (appdata_t v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target {
                // Calculate distance from center of half circle
                float2 centerToPixel = i.uv - _Center.xy;
                float distance = length(centerToPixel);
                
                // Calculate factor for yellow tint based on distance
                float yellowFactor = saturate(2.0 - 2.0 * distance);

                // Create final color with yellow tint
                fixed4 col = tex2D(_MainTex, i.uv) * _Color;
                col.rgb = lerp(col.rgb, float3(1.0, 1.0, 0.0), yellowFactor);

                return col;
            }
            ENDCG
        }
    }
}

