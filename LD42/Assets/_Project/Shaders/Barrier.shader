// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Barrier"
{
	Properties
	{
		_Texture("Texture", 2D) = "white" {}
		_BarrierColor("Color", Color) = (0,0,0,0)
		_Speed("Speed", Range( 0 , 0.5)) = 0
		_X("X", Range( 1 , 200)) = 0
		_Y("Y", Range( 1 , 200)) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Off
		AlphaToMask On
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma only_renderers d3d11 glcore gles gles3 d3d11_9x 
		#pragma surface surf Unlit alpha:fade keepalpha noshadow novertexlights nofog nometa noforwardadd 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform half4 _BarrierColor;
		uniform sampler2D _Texture;
		uniform float _X;
		uniform float _Y;
		uniform float _Speed;

		inline half4 LightingUnlit( SurfaceOutput s, half3 lightDir, half atten )
		{
			return half4 ( 0, 0, 0, s.Alpha );
		}

		void surf( Input i , inout SurfaceOutput o )
		{
			float2 appendResult19 = (float2(_X , _Y));
			float2 uv_TexCoord10 = i.uv_texcoord * appendResult19;
			float2 temp_cast_1 = (_Speed).xx;
			float2 temp_cast_2 = (uv_TexCoord10.y).xx;
			float2 panner9 = ( 1.0 * _Time.y * temp_cast_1 + temp_cast_2);
			float2 appendResult13 = (float2(uv_TexCoord10.x , panner9.x));
			float4 tex2DNode1 = tex2D( _Texture, appendResult13 );
			o.Emission = ( _BarrierColor * tex2DNode1 ).rgb;
			o.Alpha = tex2DNode1.a;
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=15401
633;1035;1906;1103;1048.978;309.9382;1;True;False
Node;AmplifyShaderEditor.RangedFloatNode;17;-1969.101,-113.8356;Float;False;Property;_X;X;3;0;Create;True;0;0;False;0;0;1;1;200;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;18;-1979.101,34.1644;Float;False;Property;_Y;Y;4;0;Create;True;0;0;False;0;0;32.5;1;200;0;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;19;-1698.101,-8.835602;Float;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;11;-1196.618,187.2579;Float;False;Property;_Speed;Speed;2;0;Create;True;0;0;False;0;0;0.039;0;0.5;0;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;10;-1548.006,-32.5094;Float;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.PannerNode;9;-926.0056,100.4906;Float;False;3;0;FLOAT2;0,0;False;2;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.DynamicAppendNode;13;-582.7883,86.99658;Float;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SamplerNode;1;-348,77;Float;True;Property;_Texture;Texture;0;0;Create;True;0;0;False;0;None;34af65cb80134fa4bbb31e106debc9cc;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;4;-316,-174;Half;False;Property;_BarrierColor;Color;1;0;Create;False;0;0;False;0;0,0,0,0;0.3372549,0.6980392,0.3882352,0;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;3;151,-114;Float;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;620,-129;Float;False;True;2;Float;ASEMaterialInspector;0;0;Unlit;Barrier;False;False;False;False;False;True;False;False;False;True;True;True;False;False;True;False;False;False;False;False;Off;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Transparent;0.5;True;False;0;True;Transparent;;Transparent;All;False;True;True;True;True;False;True;False;False;False;False;False;False;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;-1;False;-1;-1;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;0;-1;-1;-1;0;True;0;0;False;-1;-1;0;False;-1;0;0;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;19;0;17;0
WireConnection;19;1;18;0
WireConnection;10;0;19;0
WireConnection;9;0;10;2
WireConnection;9;2;11;0
WireConnection;13;0;10;0
WireConnection;13;1;9;0
WireConnection;1;1;13;0
WireConnection;3;0;4;0
WireConnection;3;1;1;0
WireConnection;0;2;3;0
WireConnection;0;9;1;4
ASEEND*/
//CHKSM=872C8E092EB9F52E116FD6B1FD31981A57D0E7D2