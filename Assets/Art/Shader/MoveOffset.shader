Shader "Unlit/MoveOffset"
{
    Properties
    {
		_MoveOffset("MoveOffset",Range(-10,10))=1
        _MainTex ("Texture", 2D) = "white" {}
        _LerpScope("LerpScope",Range(-10,10)) = 1 
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
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
			float _MoveOffset;
            float _LerpScope;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
			    col.w *=  (i.uv.y *_LerpScope) + _MoveOffset;
                
                
                return col;
            }
            ENDCG
        }
    }
}
                
                
            
				