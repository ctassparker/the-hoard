﻿Shader "Custom/FogShader" {
	Properties {
		_Color ("Main Color", Color) = (1,1,1,1)
		_MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
		_FogRadius ("FogRadius", float) = 1.0
		_FogMaxRadius ("FogMaxRadius", float) = 1.0
		_Player_Pos ("_Player_Pos", Vector) = (0,0,0,1)
	}
	SubShader {
		Tags {"Queue"="Transparent" "IgnoreProjector"= "True" "RenderType"="Transparent" }
		LOD 200
		Cull off
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard vertex:vert alpha:blend

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0


		sampler2D _MainTex;
		fixed4 _Color;
		float _FogRadius; 
		float _FogMaxRadius; 
		float _Player_Pos;

		struct Input {
			float2 uv_MainTex;
			float2 location;
		};

		float powerForPos(float4 pos, float2 nearVertex);

		void vert(inout appdata_full vertexData, out Input outData) {
			float4 pos = mul(UNITY_MATRIX_MVP, vertexData.vertex);
			float4 posWorld = mul(_Object2World, vertexData.vertex);
			outData.uv_MainTex = vertexData.texcoord;
			outData.location = posWorld.xz;
		}

		void surf (Input IN, inout SurfaceOutputStandard o) {
			fixed4 baseColor = tex2D (_MainTex, IN.uv_MainTex) * _Color;

			float alpha = 1.0 - (baseColor.a + powerForPos(_Player_Pos, IN.location));

			// Albedo comes from a texture tinted by color
			o.Albedo = baseColor.rgb;
			o.Alpha = alpha;
		}

		//return 0 if (pos - nearVertex) > _FogRadius
		float powerForPos(float4 pos, float2 nearVertex) {
			float atten = clamp(_FogRadius - length(pos.xz - nearVertex.xy), 0.0, _FogRadius);
			return (1.0 / _FogMaxRadius)*atten/_FogRadius;
		}

		ENDCG
	}

	FallBack "Diffuse"
}
