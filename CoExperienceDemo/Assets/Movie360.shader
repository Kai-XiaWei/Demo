// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/Movie360"
{
	Properties{
				 _MainTex("Main Tex", 2D) = "white" {}
	}
		SubShader{
				Tags { "RenderType" = "Opaque" "Queue" = "Geometry"}

				Pass {
						CGPROGRAM

						#pragma vertex vert
						#pragma fragment frag

						sampler2D _MainTex;

						struct a2v {
								float4 vertex : POSITION;
								float3 texcoord : TEXCOORD0;
						};

						struct v2f {
								float4 pos : SV_POSITION;
								float2 uv : TEXCOORD0;
						};

						v2f vert(a2v v) {
								v2f o;
								o.pos = UnityObjectToClipPos(v.vertex);
								o.uv = v.texcoord;
								return o;
						}

						fixed4 frag(v2f i) : SV_Target {
								i.uv.x = 1 - i.uv.x;
								return tex2D(_MainTex, i.uv);
						}

						ENDCG
				}
	}
		FallBack Off
}