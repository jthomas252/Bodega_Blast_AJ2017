Shader "Sprites/Billboard" {
	Properties {
		_MainTex ("Sprite Texture", 2D) = "white" {}
		_Color ("Tint", Color) = (1,1,1,1)
		_ScaleX ("Scale X", Float) = 1.0
		_ScaleY ("Scale Y", Float) = 1.0
	}

	SubShader {
		Tags { 
			"Queue"="Transparent"
			"RenderType"="Transparent" 
			"PreviewType"="Plane"
			"IgnoreProjector"="True"
			"DisableBatching"="True"
		}
		LOD 200

		Cull Off
		ZWrite Off
		ZTest Always
		Blend One OneMinusSrcAlpha

		Pass {
			ZWrite On
			ColorMask 0
		}

		Pass {
		CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			
			struct appdata_t {
				float4 vertex   : POSITION;
				float4 color    : COLOR;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f {
				float4 vertex   : SV_POSITION;
				fixed4 color    : COLOR;
				float2 texcoord  : TEXCOORD0;
			};
			
			uniform float  _ScaleX; 
			uniform float  _ScaleY;
			uniform fixed4 _Color;

			v2f vert(appdata_t IN) {
				v2f OUT;

				OUT.texcoord = IN.texcoord;
				OUT.color    = IN.color * _Color; 
				OUT.vertex   = mul(UNITY_MATRIX_P, 
					mul(UNITY_MATRIX_MV, float4(0,0,0,1)) 
					+ float4(IN.vertex.x, IN.vertex.y, IN.vertex.z, 1.0)
					* float4(_ScaleX, _ScaleY, 1.0, 1.0)); 
				return OUT;
			}

			sampler2D _MainTex;
			sampler2D _AlphaTex;

			fixed4 SampleSpriteTexture (float2 uv) {
				fixed4 color = tex2D (_MainTex, uv);

				return color;
			}

			fixed4 frag(v2f IN) : SV_Target {
				fixed4 c = SampleSpriteTexture (IN.texcoord) * IN.color;
				c.rgb *= c.a;
				return c;
			}
		ENDCG
		}
	}
}