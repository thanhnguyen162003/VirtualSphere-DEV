Shader "Softspace/Skybox_Passthru_Cubemap_HDR" {
	Properties {
		[NoScaleOffset] _Tex ("Cubemap (HDR)", Cube) = "grey" {}
		_Rotation ("Rotation", Range(0, 360)) = 0
		[Space] _Color ("Color for Alpha", Vector) = (1,1,1,1)
		_BaseAlpha ("Base Alpha", Range(0, 1)) = 1
		[Gamma] _Exposure ("Exposure", Range(0, 8)) = 1
		[Space] _DirectionAlpha1 ("Direction Alpha = 1", Vector) = (0,0,0,0)
		_RadiusAlpha1 ("Radius Alpha = 1", Range(0, 1)) = 0.5
		_RadiusAlpha0 ("Radius Alpha = 0", Range(0, 1)) = 0.5
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType"="Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		fixed4 _Color;
		struct Input
		{
			float2 uv_MainTex;
		};
		
		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			o.Albedo = _Color.rgb;
			o.Alpha = _Color.a;
		}
		ENDCG
	}
}