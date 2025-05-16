Shader "Unlit/WaterAlphaMove"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _WaterTex("WaterTex",2D) = "white" {}
        _Amplitude("Amplitude",Range(0,0.1))=0.01 //振幅
        _Cycle("Cycle",Range(0,29))=10 //周期
        _VibrationRange("VibrationRange",Range(0,10))=0.2 //水波范围
        _AmplitudeWater("AmplitudeWater",Range(0,0.1))=0.01 
        _CycleWater("CycleWater",Range(0,29))=10 
        _VibrationRangeWater("VibrationRangeWater",Range(0,10))=0.2 
        _LightAlpha("LightAlpha",float)= 1 
        _LightPower("LightPower",float)= 1


    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float2 uv1 :TEXCOORD1;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            sampler2D _WaterTex;
            float4 _WaterTex_ST;
            float _Cycle;
            float _Amplitude;
            float _VibrationRange;
            float _LightAlpha;
            float _LightPower;
            float _VibrationRangeWater;
            float _CycleWater;
            float _AmplitudeWater;
            
          

            v2f vert (appdata_full v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
                o.uv1 = TRANSFORM_TEX(v.texcoord1, _WaterTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float dis = distance(i.uv,float2(0.5f,1));
                float f = saturate(1-dis/_VibrationRange);
                i.uv += f*_Amplitude*sin(dis*3.14*_Cycle+_Time.y);
                float disWater = distance(i.uv1,float2(0.5f,1));
                float fWater = saturate(1-disWater/_VibrationRangeWater);
                i.uv1 += fWater *_AmplitudeWater*sin(disWater*3.14*_CycleWater+_Time.y);
                fixed4 col = tex2D(_MainTex, i.uv);
                fixed4 Watercol = tex2D(_WaterTex, i.uv1);
                Watercol.rgb *= _LightPower;
                Watercol.rgb *= col.rgb;
                Watercol.rgb *= 1-i.uv1.y/_WaterTex_ST.y+_LightAlpha;
                col += Watercol;
                return col;
            }
            ENDCG
        }
    }
}
