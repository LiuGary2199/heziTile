Shader "Unlit/BGMove"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Cycle("Cycle",Range(0,29))=10 //周期
        _Amplitude("Amplitude",Range(0,0.1))=0.01 //振幅
        _VibrationRange("VibrationRange",Range(0,10))=0.2 //水波范围
    }
    SubShader
    {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
            "LightMode"="ForwardBase"
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
            float _Cycle;
            float _Amplitude;
            float _VibrationRange;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float dis = distance(i.uv,float2(0.5f,1));
                float f = saturate(1-dis/_VibrationRange);
                i.uv += f*_Amplitude*sin(-dis*3.14*_Cycle+_Time.y);
                fixed4 col = tex2D(_MainTex, i.uv);
                return col;
            }
            ENDCG
        }
    }
}
