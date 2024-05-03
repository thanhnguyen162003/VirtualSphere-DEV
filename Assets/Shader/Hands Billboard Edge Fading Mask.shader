Shader "Hands Billboard Edge Fading Mask" {
	Properties {
		_Intensity ("Intensity", Range(0, 1)) = 1
		[Space(5)] [Header(PARAMETRIC GLOW)] _Scale ("Scale", Range(0, 0.1)) = 0.055
		_Falloff ("Falloff", Float) = 4
		_Power ("Power", Float) = 15
		[Space(5)] [Header(EDGE FADING)] [Toggle] _EdgeFading ("Enable", Float) = 1
		_KeyboardPosition ("Keyboard Position", Vector) = (0,0,0,0)
		_KeyboardRotation ("Keyboard Rotation", Vector) = (0,0,0,0)
		_KeyboardScale ("Keyboard Scale", Vector) = (1,1,1,0)
		_FadingFalloff ("Falloff", Range(0, 0.1)) = 0.05
		_ColorMultiply ("Color multiply", Range(0, 3)) = 2
		[Enum(UnityEngine.Rendering.BlendMode)] _SrcBlendMode ("Src Blend Factor", Float) = 0
		[Enum(UnityEngine.Rendering.BlendMode)] _DstBlendMode ("Dst Blend Factor", Float) = 4
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType" = "Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		struct Input
		{
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			o.Albedo = 1;
		}
		ENDCG
	}
}