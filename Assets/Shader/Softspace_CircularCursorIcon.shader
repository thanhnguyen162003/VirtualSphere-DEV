Shader "Softspace/CircularCursorIcon" {
	Properties {
		_AlphaGlobal ("Alpha Global", Range(0, 1)) = 1
		[Space] _ColorInner ("Color Inner", Vector) = (1,1,1,1)
		_ColorOuter ("Color Outer", Vector) = (1,1,1,1)
		[Space] _RadiusRim ("Radius Rim", Range(0, 0.5)) = 0.4
		_RadiusInner ("Radius Inner", Range(0, 0.5)) = 0.1
		_RadiusOuter ("Radius Outer", Range(0, 0.5)) = 0.5
		[Space] _AlphaRim ("Alpha Rim", Range(0, 1)) = 0.5
		_AlphaInner ("Alpha Inner", Range(0, 1)) = 0.5
		[Space] _ShowCaret ("Show Caret", Range(0, 1)) = 0
		_HeightCaret ("Height Caret", Range(0, 1)) = 1
		_WidthCaret ("Width Caret", Range(0, 1)) = 0.1
		_OutlineCaret ("Outline Caret", Range(0, 1)) = 0.01
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