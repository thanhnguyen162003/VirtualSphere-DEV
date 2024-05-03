Shader "Softspace/AudioAmplitudeRing" {
	Properties {
		_InnerRadius ("Inner Radius", Float) = 0.5
		_OuterRadius ("Outer Radius", Float) = 0.6
		_Color ("Color", Vector) = (1,1,1,1)
		_Amplitude ("Amplitude", Float) = 0.5
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