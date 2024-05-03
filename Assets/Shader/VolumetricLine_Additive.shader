Shader "VolumetricLine/Additive" {
	Properties {
		[NoScaleOffset] _MainTex ("Base (RGB)", 2D) = "white" {}
		_Color ("Main Color", Vector) = (1,1,1,1)
		_LineWidth ("Line Width", Range(0.01, 100)) = 1
		_LineScale ("Line Scale", Float) = 1
		_LightSaberFactor ("LightSaberFactor", Range(0, 1)) = 0.9
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType"="Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		sampler2D _MainTex;
		fixed4 _Color;
		struct Input
		{
			float2 uv_MainTex;
		};
		
		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
	Fallback "Diffuse"
}