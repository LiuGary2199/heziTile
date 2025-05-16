Shader "Unlit/Flash"
{
    Properties
    {
        //高光贴图
        _LightTex("Light Texture",2D) = "white"{}
        //流光强度
        _LightPower("LightPower",float) = 1
        //开关,0关，1开
        _SwitchLight("SwitchLight",float) = 0
        //流光偏移量
        _LightOffset("LightOffset",float) = 0
        //底图
        _MainTex ("Texture", 2D) = "white" {}
        //流光颜色
        _LightColor("LightColor", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags { 
            "Queue" = "Transparent"
            "IgnoreProjector" = "True"
            "RenderType" = "Transparent"
              }
        LOD 100

            Cull Off
            Lighting Off
            ZWrite Off
            Fog { Mode Off }
            Offset -1, -1
            Blend SrcAlpha OneMinusSrcAlpha
            AlphaTest Greater 0.1
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
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _LightPower;
            float _SwitchLight;
            float _LightOffset;
            sampler2D _LightTex;
            float4 _LightTex_ST;
            float4 _LightColor;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.uv1 = TRANSFORM_TEX(v.uv1, _LightTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
              fixed4 colorMain = tex2D(_MainTex,i.uv);
            if (_SwitchLight > 0.5)
               {
                float2 uvLight = i.uv1;
                uvLight.x /= 2;
                uvLight.x -= _LightOffset;
                fixed4 colorFlowLight = tex2D(_LightTex, uvLight) * _LightPower * _LightColor;
                colorFlowLight.rgb *= colorMain.rgb;
                colorMain.rgb += colorFlowLight.rgb;
                colorMain.rgb *= colorMain.a;
                }
            return colorMain;
            }
            ENDCG
        }
    }
}
