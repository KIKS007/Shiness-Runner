// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:False,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:5446,x:32719,y:32712,varname:node_5446,prsc:2|diff-2193-RGB,emission-2193-RGB,alpha-3081-OUT;n:type:ShaderForge.SFN_DepthBlend,id:9846,x:31895,y:33230,varname:node_9846,prsc:2|DIST-8033-OUT;n:type:ShaderForge.SFN_Color,id:2193,x:32146,y:32683,ptovrint:False,ptlb:node_2193,ptin:_node_2193,varname:node_2193,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:1348,x:32151,y:33101,varname:node_1348,prsc:2|A-6818-OUT,B-9846-OUT;n:type:ShaderForge.SFN_Vector1,id:6818,x:31902,y:33146,varname:node_6818,prsc:2,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:8033,x:31707,y:33230,ptovrint:False,ptlb:Depth,ptin:_Depth,varname:node_8033,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Tex2d,id:6341,x:31502,y:32832,ptovrint:False,ptlb:Cloud,ptin:_Cloud,varname:node_6341,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-481-UVOUT;n:type:ShaderForge.SFN_Multiply,id:3081,x:32382,y:32917,varname:node_3081,prsc:2|A-5931-OUT,B-1348-OUT;n:type:ShaderForge.SFN_Lerp,id:5931,x:32151,y:32941,varname:node_5931,prsc:2|A-3140-OUT,B-5259-OUT,T-1348-OUT;n:type:ShaderForge.SFN_Vector1,id:3140,x:31671,y:32992,varname:node_3140,prsc:2,v1:0;n:type:ShaderForge.SFN_Multiply,id:1603,x:31702,y:32849,varname:node_1603,prsc:2|A-6341-R,B-5735-OUT;n:type:ShaderForge.SFN_Vector1,id:5735,x:31502,y:32747,varname:node_5735,prsc:2,v1:0.2;n:type:ShaderForge.SFN_OneMinus,id:6545,x:31873,y:32849,varname:node_6545,prsc:2|IN-1603-OUT;n:type:ShaderForge.SFN_Panner,id:481,x:31322,y:32839,varname:node_481,prsc:2,spu:0,spv:0.04|UVIN-7086-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:7086,x:31143,y:32839,varname:node_7086,prsc:2,uv:0;n:type:ShaderForge.SFN_Tex2d,id:4801,x:31502,y:32516,ptovrint:False,ptlb:Cloud2,ptin:_Cloud2,varname:node_4801,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-869-UVOUT;n:type:ShaderForge.SFN_Panner,id:869,x:31317,y:32516,varname:node_869,prsc:2,spu:0,spv:0.02|UVIN-7086-UVOUT;n:type:ShaderForge.SFN_Multiply,id:2761,x:31694,y:32516,varname:node_2761,prsc:2|A-4801-R,B-2939-OUT;n:type:ShaderForge.SFN_OneMinus,id:8920,x:31875,y:32516,varname:node_8920,prsc:2|IN-2761-OUT;n:type:ShaderForge.SFN_Vector1,id:2939,x:31502,y:32434,varname:node_2939,prsc:2,v1:0.6;n:type:ShaderForge.SFN_Blend,id:5259,x:32140,y:32376,varname:node_5259,prsc:2,blmd:2,clmp:True|SRC-8920-OUT,DST-6545-OUT;proporder:2193-8033-6341-4801;pass:END;sub:END;*/

Shader "Custom/Void" {
    Properties {
        _node_2193 ("node_2193", Color) = (0.5,0.5,0.5,1)
        _Depth ("Depth", Float ) = 0
        _Cloud ("Cloud", 2D) = "white" {}
        _Cloud2 ("Cloud2", 2D) = "white" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        LOD 200
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _CameraDepthTexture;
            uniform float4 _TimeEditor;
            uniform float4 _node_2193;
            uniform float _Depth;
            uniform sampler2D _Cloud; uniform float4 _Cloud_ST;
            uniform sampler2D _Cloud2; uniform float4 _Cloud2_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 projPos : TEXCOORD1;
                UNITY_FOG_COORDS(2)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
////// Lighting:
////// Emissive:
                float3 emissive = _node_2193.rgb;
                float3 finalColor = emissive;
                float4 node_348 = _Time + _TimeEditor;
                float2 node_869 = (i.uv0+node_348.g*float2(0,0.02));
                float4 _Cloud2_var = tex2D(_Cloud2,TRANSFORM_TEX(node_869, _Cloud2));
                float2 node_481 = (i.uv0+node_348.g*float2(0,0.04));
                float4 _Cloud_var = tex2D(_Cloud,TRANSFORM_TEX(node_481, _Cloud));
                float node_1348 = (1.0*saturate((sceneZ-partZ)/_Depth));
                fixed4 finalRGBA = fixed4(finalColor,(lerp(0.0,saturate((1.0-((1.0-(1.0 - (_Cloud_var.r*0.2)))/(1.0 - (_Cloud2_var.r*0.6))))),node_1348)*node_1348));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
