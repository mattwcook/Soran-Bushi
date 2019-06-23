 Shader "Custom/Texture Blend" {
         Properties {
             _Color ("Color", Color) = (1,1,1,1)
             _Blend ("Texture Blend", Range(0,1)) = 0.0
             _MainTex ("Albedo (RGB)", 2D) = "white" {}
             _MainTex2 ("Albedo 2 (RGB)", 2D) = "white" {}
             _Glossiness ("Smoothness", Range(0,1)) = 0.5
             _Metallic ("Metallic", Range(0,1)) = 0.0
			 _BumpMap ("Bumpmap" , 2D) = "bump" {}
			 _RimColor ("Rim Color", Color) = (0.26,0.19,0.16,0.0)
			 _RimPower ("Rim Power", Range(0.5,8.0)) = 3.0
			 [ToggleOff] _SpecularHighlights("Specular Highlights", Float) = 1.0
             [ToggleOff] _GlossyReflections("Glossy Reflections", Float) = 1.0

			 

         }
         SubShader {
             Tags { "RenderType"="Opaque" }
             LOD 200
            
             CGPROGRAM
             // Physically based Standard lighting model, and enable shadows on all light types
             #pragma surface surf Standard fullforwardshadows 

             // Use shader model 3.0 target, to get nicer looking lighting
             #pragma target 3.0
			 #pragma shader_feature _ _SPECULARHIGHLIGHTS_OFF
             #pragma shader_feature _ _GLOSSYREFLECTIONS_OFF
      
             sampler2D _MainTex;
             sampler2D _MainTex2;
			 sampler2D _BumpMap;
			 float4 _RimColor;
			 float _RimPower;

             struct Input {
                 float2 uv_MainTex;
                 float2 uv_MainTex2;
				 float2 uv_BumpMap;
				 float3 viewDir;
             };
      
             half _Blend;
             half _Glossiness;
             half _Metallic;
             fixed4 _Color;
      
             void surf (Input IN, inout SurfaceOutputStandard o) {
                 fixed4 c = lerp (tex2D (_MainTex, IN.uv_MainTex), tex2D (_MainTex2, IN.uv_MainTex2), _Blend) * _Color;
                 o.Albedo = c.rgb;
                 o.Metallic = _Metallic;
                 o.Smoothness = _Glossiness;
                 o.Alpha = c.a;
				 o.Normal = UnpackNormal (tex2D (_BumpMap, IN.uv_BumpMap));
				 half rim = 1.0 - saturate(dot (normalize(IN.viewDir), o.Normal));
				 o.Emission = _RimColor.rgb * pow (rim, _RimPower);
             }
             ENDCG
         }
         FallBack "Diffuse"
     }