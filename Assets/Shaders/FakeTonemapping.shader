Shader "Custom/FakeTonemapping" {
	Properties {
		_Color ("Color", Color) = (.2,.2,.2,.2)
	}

    SubShader {
    
         Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
       
    	ZTest Off 
    	Blend One One
    	
        Pass {
            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            float4 vert(float4 v:POSITION) : SV_POSITION {
                return float4(v.x * 2f, v.y * 2f, 0.0, 1.0);
            }
            
            float4 _Color;

            fixed4 frag() : COLOR {
                return _Color;
            }

            ENDCG
        }
    }
}