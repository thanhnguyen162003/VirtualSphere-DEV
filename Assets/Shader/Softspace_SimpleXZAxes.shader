Shader "Softspace/SimpleXZAxes" {
	Properties {
		_Origin ("Origin (set in code)", Vector) = (0,0,0,1)
		_CamPos ("Cam Position (set in code)", Vector) = (0,0,0,1)
		_CamScale ("Cam Scale (set in code)", Range(0.1, 100)) = 1
		[Space] _ClearNearOrigin ("Clear Distance Around Origin", Range(0, 1)) = 0.05
		_LineHalfThickness ("Line Half-Thickness", Range(0.001, 0.1)) = 0.01
		_LineColor ("Line Color", Vector) = (0.5,0.5,0.5,0.5)
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