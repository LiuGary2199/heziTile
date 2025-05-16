Shader "Unlit/Circular gradient"
{
    Properties
    {
		_Offset("Offset",Range(0,1))=1
		_LightPower("_LightPower",Range(0,1))=1
        _MainTex ("Texture", 2D) = "white" {}
        _LIghtTex("_LIghtTex",2D) = "white"{}
    }
    SubShader
    {
		Tags {
			"IgnoreProjector" = "True"
			"Queue" = "Transparent"
			"RenderType" = "Transparent"
			"LightMode" = "ForwardBase"
		}
		Blend SrcAlpha OneMinusSrcAlpha
		Cull Back

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex   : POSITION;
                float2 uv       : TEXCOORD0;
                float2 uv1      : TEXCOORD1;
            };

            struct v2f
            {
                float2 uv       : TEXCOORD0;
                float2 uv1      : TEXCOORD1;
                UNITY_FOG_COORDS(1)
                float4 vertex   : SV_POSITION;
            };

            sampler2D _MainTex;
            sampler2D _LIghtTex;
            float4 _LIghtTex_ST;
            float4 _MainTex_ST;
			float _Offset;
			float _LightPower;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex     = UnityObjectToClipPos(v.vertex);
                o.uv         = TRANSFORM_TEX(v.uv, _MainTex);
                o.uv1        = TRANSFORM_TEX(v.uv1, _LIghtTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float4 col = tex2D(_MainTex, i.uv);
                float2 uvLight = i.uv1;
                uvLight /= 2;
                uvLight *= _Offset;
                float4 LightCol = tex2D(_LIghtTex,uvLight) * _LightPower; 
                LightCol.rgb *= col.rgb;
                col.rgb += LightCol.rgb;
                
				
                return col;
            }
            ENDCG
        }
    }
}
                
                
                
             
