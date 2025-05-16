Shader "Unlit/ShellFlash"
{
    Properties
    {
        _MainTex    ("Texture", 2D)             = "white" {}
        _LightTex   ("LightTex",2D)             = "while" {}
        _LightPower ("LIghtPower",Range(0,1))   = 1
    }
    SubShader
    {
        Tags 
        {
            "Queue" = "Transparent"
			"IgnoreProjector" = "True"
			"RenderType" = "Transparent" 
        }

             Cull Off
             Lighting Off
             ZWrite Off
             ZTest [unity_GUIZTestMode]
             Fog { Mode Off }
             Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex   : POSITION;
                float2 uv       : TEXCOORD0;
                float2 uv1      : TEXCOORD1;
                float4 color    : COLOR;
            };

            struct v2f
            {
                float2 uv       : TEXCOORD0;
                float2 uv1      : TEXCOORD1;
                float4 vertex   : SV_POSITION;
                float4 diff     : COLOR0;
            };

            sampler2D _MainTex;
            sampler2D _LightTex;
            float4 _MainTex_ST;
            float4 _LightTex_ST;
            float _LightPower;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex    = UnityObjectToClipPos(v.vertex);
                o.uv1       = TRANSFORM_TEX(v.uv1,_LightTex);
                o.uv        = TRANSFORM_TEX(v.uv, _MainTex);
                o.diff      =  v.color;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
            /* ------------------向量准备------------------ */
                fixed4 col      = tex2D(_MainTex, i.uv);
                fixed4 Lightcol = tex2D(_LightTex,sin(i.uv1 + _Time.y));
            /* ------------------渲染步骤------------------ */
                Lightcol        *= _LightPower;
                Lightcol        *= col;
                col             += Lightcol;
                col.a           *=  i.diff.a;
                return col;
            }
            ENDCG
        }
    }
}
