Shader "Vuplex/Viewport Shader" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		[Toggle(FLIP_X)] _FlipX ("Flip X", Float) = 0
		[Toggle(FLIP_Y)] _FlipY ("Flip Y", Float) = 0
		[Header(Properties set programmatically)] _VideoCutoutRect ("Video Cutout Rect", Vector) = (0,0,0,0)
		_CropRect ("Crop Rect", Vector) = (0,0,0,0)
		_StencilComp ("Stencil Comparison", Float) = 8
		_Stencil ("Stencil ID", Float) = 0
		_StencilOp ("Stencil Operation", Float) = 0
		_StencilWriteMask ("Stencil Write Mask", Float) = 255
		_StencilReadMask ("Stencil Read Mask", Float) = 255
		_ColorMask ("Color Mask", Float) = 15
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType"="Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		sampler2D _MainTex;
		struct Input
		{
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
	Fallback "Unlit/Texture"
}