// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

Shader "Custom/SpriteShadow"
{
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
		_Cutoff ("Shadow alpha cutoff", Range(0,1)) = 0.5
        _Color ("Main Color", Color) = (0,0,0,0)
        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
        [HideInInspector] _RendererColor ("RendererColor", Color) = (1,1,1,1)
        [HideInInspector] _Flip ("Flip", Vector) = (1,1,1,1)
        [PerRendererData] _AlphaTex ("External Alpha", 2D) = "white" {}
        [PerRendererData] _EnableExternalAlpha ("Enable External Alpha", Float) = 0
    }

    SubShader
    {
        Tags
        {
            "Queue"="Transparent"
            "IgnoreProjector"="True"
            "RenderType"="Opaque"
            "PreviewType"="Plane"
			"SHADOWSUPPORT"="True"
            "CanUseSpriteAtlas"="True"
        }

		

		LOD 400
        Cull Off
        Lighting Off
        ZWrite On
        Blend One OneMinusSrcAlpha

		CGPROGRAM
		 //#pragma surface surf Standard fullforwardshadows
         #pragma surface surf Lambert alpha alphatest:_Cutouff fullforwardshadows
		 //#pragma surface surf Lambert addShadow
 
		#pragma target 3.0

		sampler2D _MainTex;

         struct Input {
             float2 uv_MainTex;
         };
 
		half _Glossiness;
		half _Metallic;
		fixed4 _Color;
		
         void surf (Input IN, inout SurfaceOutput o) {
			//fixed4 c = tex2D(_MainTex, IN.uv_MainTex)* _Color;
             //o.Albedo = c.rgb;
			 o.Alpha = 0;

         }
         ENDCG


        Pass
        {
		Blend SrcAlpha OneMinusSrcAlpha 
			Name "ShadowPass"
			Tags {"LightMode" = "ForwardBase"}


        CGPROGRAM
            #pragma vertex SpriteVert
            #pragma fragment SpriteFrag
            #pragma target 2.0
            #pragma multi_compile_instancing
            #pragma multi_compile _ PIXELSNAP_ON
            #pragma multi_compile _ ETC1_EXTERNAL_ALPHA
            #include "UnitySprites.cginc"
        ENDCG
        }

    }
	Fallback "Legacy Shaders/Transparent/Cutout/Diffuse"
}
