Shader "Unlit/Matcap"
{
    //属性面板设置
	Properties
	{
		_NormalMap("法线贴图", 2D) = "white" {}
		_Matcap("Matcap",2D) = "gray"{}
		_FresnelPow("菲涅尔",Range(0.5,1)) = 1
		_EnvSpecInt("环境镜面反射强度",Range(0,5)) = 1
	}

		SubShader
		{
			//定义渲染模式
			Tags { "RenderType" = "Opaque" }
			LOD 100

			Pass
			{
				//应用哪些unity自带的方法
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				// make fog work
				#pragma multi_compile_fog
				#pragma target 3.0
				#include "UnityCG.cginc"

				//输入结构体(你需要哪些输入信息)
				struct appdata
				{
					float4 vertex   : POSITION;		//顶点信息
					float2 uv0       : TEXCOORD0;	//uv纹理
					float3 normal   : NORMAL;		//法线信息
					float4 tangent :TANGENT;		//切线信息
				};

				//输出结构体(你希望输出哪些信息)
				struct v2f
				{
					float2 uv0       : TEXCOORD0;  //uv纹理
					float3 posWS     : TEXCOORD1;  //世界坐标
					float4 vertex   : SV_POSITION; //顶点坐标(同顶点信息)
					float3 ndirWS     : TEXCOORD2; //世界空间下的法线方向
					float3 tdirWS     : TEXCOORD3; //世界空间下的切线方向
					float3 bdirWS     : TEXCOORD4; //世界空间下的副切线方向
				};

				//声明变量(同属性设置)
				sampler2D _NormalMap;				//法线贴图
				sampler2D _Matcap;					//材质贴图
				float _FresnelPow;					//菲涅尔强度
				float _EnvSpecInt;					//环境镜面反射强度


				//顶点计算(从自身坐标系计算到世界坐标)
				v2f vert(appdata v)
				{
					v2f o;
					o.vertex = UnityObjectToClipPos(v.vertex);			
					o.uv0 = v.uv0;										
					o.posWS = mul(unity_ObjectToWorld,v.vertex);									//计算世界坐标	
					o.ndirWS = UnityObjectToWorldNormal(v.normal);									//计算世界空间下的法线方向
					o.tdirWS = normalize(mul(unity_ObjectToWorld,float4(v.tangent.xyz,0.0)).xyz);	//计算世界空间下的切线方向
					o.bdirWS = normalize(cross(o.ndirWS,o.tdirWS)* v.tangent.w);					//计算世界空间下的副切线方向
					return o;
				}

				fixed4 frag(v2f i) : SV_Target
				{
					//向量准备//
					float3 ndirTS = UnpackNormal(tex2D(_NormalMap,i.uv0)).rgb;				//切线空间下的法线方向
					float3x3 TBN = float3x3(i.tdirWS,i.bdirWS,i.ndirWS);					//由世界空间下的法线，切线，副切线方向可得到TBN矩阵
					float3 ndirWS = normalize(mul(ndirTS,TBN));								//切线空间下的法线方向乘TBN矩阵可得到世界空间下的法线方向
					float3 ndirVS = mul(UNITY_MATRIX_V,float4(ndirWS,0.0));					//由世界空间下的法线方向可得到观察者空间下的法线方向
					float3 vdirWS = normalize(_WorldSpaceCameraPos.xyz - i.posWS.xyz);		//由摄像机坐标减去当前像素坐标可得到世界空间下的观察方向
					float3 vrdirWS = reflect(-vdirWS,ndirWS);								//可能会用到(观察者方向以法线方向为对称轴的反方向)
					//中间量准备//
					float2 matcapUV = ndirVS.rg * 0.5 + 0.5;								//环境光的漫反射
					float ndotv = dot(ndirWS,vdirWS);										//phong光照模型
					//光照模型//
					float3 matcap = tex2D(_Matcap,matcapUV);								//matcap采样	
					float fresnel = pow(1.0 - ndotv,_FresnelPow);							//菲涅尔计算
					float3 envSpecLighting = matcap * fresnel * _EnvSpecInt;				//最终混合
					//返回值//
					return float4(envSpecLighting,1.0);										// 输出
				}
				ENDCG
			}
		}
}