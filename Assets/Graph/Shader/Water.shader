// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:340,x:32876,y:32779,varname:node_340,prsc:2|diff-8006-OUT,spec-6151-OUT,gloss-5338-OUT,normal-1196-OUT,emission-7166-OUT,alpha-7916-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5877,x:31935,y:33105,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:node_5877,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;n:type:ShaderForge.SFN_Color,id:17,x:31971,y:32594,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_17,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.2202638,c2:0.6520388,c3:0.7132353,c4:1;n:type:ShaderForge.SFN_DepthBlend,id:4119,x:31768,y:32757,varname:node_4119,prsc:2|DIST-8201-OUT;n:type:ShaderForge.SFN_Lerp,id:9981,x:32216,y:32594,varname:node_9981,prsc:2|A-9622-OUT,B-17-RGB,T-9829-OUT;n:type:ShaderForge.SFN_Vector1,id:5348,x:31749,y:32462,varname:node_5348,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:3830,x:31959,y:32891,varname:node_3830,prsc:2,v1:5;n:type:ShaderForge.SFN_Power,id:9829,x:31971,y:32757,varname:node_9829,prsc:2|VAL-4119-OUT,EXP-3830-OUT;n:type:ShaderForge.SFN_Lerp,id:7916,x:32203,y:32952,varname:node_7916,prsc:2|A-5340-OUT,B-5877-OUT,T-9829-OUT;n:type:ShaderForge.SFN_DepthBlend,id:9414,x:32216,y:32264,varname:node_9414,prsc:2|DIST-3541-OUT;n:type:ShaderForge.SFN_Lerp,id:8006,x:32547,y:32502,varname:node_8006,prsc:2|A-9981-OUT,B-1255-RGB,T-9414-OUT;n:type:ShaderForge.SFN_Color,id:1255,x:32216,y:32416,ptovrint:False,ptlb:Color_copy,ptin:_Color_copy,varname:_Color_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.0999135,c2:0.2828899,c3:0.3088235,c4:1;n:type:ShaderForge.SFN_ValueProperty,id:3541,x:32039,y:32264,ptovrint:False,ptlb:Depth_low,ptin:_Depth_low,varname:node_3541,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:15;n:type:ShaderForge.SFN_ValueProperty,id:8201,x:31538,y:32757,ptovrint:False,ptlb:Depth_up,ptin:_Depth_up,varname:node_8201,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.8;n:type:ShaderForge.SFN_Tex2d,id:8658,x:30629,y:33115,ptovrint:False,ptlb:Cloud,ptin:_Cloud,varname:node_8658,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-6641-UVOUT;n:type:ShaderForge.SFN_ValueProperty,id:4219,x:31935,y:33026,ptovrint:False,ptlb:Opacity_foam,ptin:_Opacity_foam,varname:node_4219,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.7;n:type:ShaderForge.SFN_Power,id:387,x:31128,y:33182,varname:node_387,prsc:2|VAL-2950-OUT,EXP-3888-OUT;n:type:ShaderForge.SFN_Vector1,id:3888,x:30845,y:33256,varname:node_3888,prsc:2,v1:6;n:type:ShaderForge.SFN_OneMinus,id:7091,x:31344,y:33182,varname:node_7091,prsc:2|IN-387-OUT;n:type:ShaderForge.SFN_Lerp,id:5340,x:32203,y:33158,varname:node_5340,prsc:2|A-5877-OUT,B-4219-OUT,T-5539-OUT;n:type:ShaderForge.SFN_Lerp,id:9622,x:31971,y:32439,varname:node_9622,prsc:2|A-17-RGB,B-5348-OUT,T-5539-OUT;n:type:ShaderForge.SFN_Multiply,id:2950,x:30845,y:33132,varname:node_2950,prsc:2|A-8658-R,B-8784-OUT;n:type:ShaderForge.SFN_Vector1,id:8784,x:30629,y:33272,varname:node_8784,prsc:2,v1:1.5;n:type:ShaderForge.SFN_Clamp01,id:5539,x:31546,y:33182,varname:node_5539,prsc:2|IN-7091-OUT;n:type:ShaderForge.SFN_Panner,id:6641,x:30398,y:33099,varname:node_6641,prsc:2,spu:1,spv:1|UVIN-991-UVOUT,DIST-9137-OUT;n:type:ShaderForge.SFN_TexCoord,id:991,x:30218,y:33099,varname:node_991,prsc:2,uv:0;n:type:ShaderForge.SFN_Time,id:7095,x:30138,y:33299,varname:node_7095,prsc:2;n:type:ShaderForge.SFN_Multiply,id:9137,x:30363,y:33308,varname:node_9137,prsc:2|A-7095-T,B-5635-OUT;n:type:ShaderForge.SFN_Vector1,id:5635,x:30174,y:33437,varname:node_5635,prsc:2,v1:0.005;n:type:ShaderForge.SFN_Tex2d,id:4343,x:32387,y:33476,ptovrint:False,ptlb:Normal,ptin:_Normal,varname:node_4343,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:438632b9c3094fd40a3126780551481a,ntxv:3,isnm:True|UVIN-5711-UVOUT;n:type:ShaderForge.SFN_Lerp,id:1196,x:32667,y:33463,varname:node_1196,prsc:2|A-7246-OUT,B-4343-RGB,T-5926-OUT;n:type:ShaderForge.SFN_Vector3,id:7246,x:32386,y:33646,varname:node_7246,prsc:2,v1:0,v2:0,v3:1;n:type:ShaderForge.SFN_ValueProperty,id:5926,x:32386,y:33759,ptovrint:False,ptlb:Normal_intensity,ptin:_Normal_intensity,varname:node_5926,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Panner,id:5711,x:32158,y:33476,varname:node_5711,prsc:2,spu:0,spv:-0.01|UVIN-2906-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:2906,x:31979,y:33476,varname:node_2906,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:7166,x:32861,y:32487,varname:node_7166,prsc:2|A-8006-OUT,B-7496-OUT;n:type:ShaderForge.SFN_Vector1,id:7496,x:32651,y:32343,varname:node_7496,prsc:2,v1:0.3;n:type:ShaderForge.SFN_Slider,id:6151,x:33162,y:32790,ptovrint:False,ptlb:Specular,ptin:_Specular,varname:node_6151,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:5338,x:33162,y:32901,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:node_5338,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Tex2d,id:9674,x:32442,y:32784,ptovrint:False,ptlb:node_9674,ptin:_node_9674,varname:node_9674,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-6641-UVOUT;n:type:ShaderForge.SFN_Add,id:4629,x:32494,y:32933,varname:node_4629,prsc:2|A-9674-R,B-7916-OUT;proporder:5877-17-1255-3541-8201-8658-4219-4343-5926-6151-5338-9674;pass:END;sub:END;*/

Shader "Custom/Water" {
    Properties {
        _Opacity ("Opacity", Float ) = 0.5
        _Color ("Color", Color) = (0.2202638,0.6520388,0.7132353,1)
        _Color_copy ("Color_copy", Color) = (0.0999135,0.2828899,0.3088235,1)
        _Depth_low ("Depth_low", Float ) = 15
        _Depth_up ("Depth_up", Float ) = 0.8
        _Cloud ("Cloud", 2D) = "white" {}
        _Opacity_foam ("Opacity_foam", Float ) = 0.7
        _Normal ("Normal", 2D) = "bump" {}
        _Normal_intensity ("Normal_intensity", Float ) = 0
        _Specular ("Specular", Range(0, 1)) = 0
        _Gloss ("Gloss", Range(0, 1)) = 0
        _node_9674 ("node_9674", 2D) = "white" {}
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
            uniform float4 _LightColor0;
            uniform sampler2D _CameraDepthTexture;
            uniform float4 _TimeEditor;
            uniform float _Opacity;
            uniform float4 _Color;
            uniform float4 _Color_copy;
            uniform float _Depth_low;
            uniform float _Depth_up;
            uniform sampler2D _Cloud; uniform float4 _Cloud_ST;
            uniform float _Opacity_foam;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform float _Normal_intensity;
            uniform float _Specular;
            uniform float _Gloss;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                float4 projPos : TEXCOORD5;
                UNITY_FOG_COORDS(6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 node_1229 = _Time + _TimeEditor;
                float2 node_5711 = (i.uv0+node_1229.g*float2(0,-0.01));
                float3 _Normal_var = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(node_5711, _Normal)));
                float3 normalLocal = lerp(float3(0,0,1),_Normal_var.rgb,_Normal_intensity);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = _Gloss;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float3 specularColor = float3(_Specular,_Specular,_Specular);
                float3 directSpecular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float node_5348 = 1.0;
                float4 node_7095 = _Time + _TimeEditor;
                float2 node_6641 = (i.uv0+(node_7095.g*0.005)*float2(1,1));
                float4 _Cloud_var = tex2D(_Cloud,TRANSFORM_TEX(node_6641, _Cloud));
                float node_5539 = saturate((1.0 - pow((_Cloud_var.r*1.5),6.0)));
                float node_9829 = pow(saturate((sceneZ-partZ)/_Depth_up),5.0);
                float3 node_8006 = lerp(lerp(lerp(_Color.rgb,float3(node_5348,node_5348,node_5348),node_5539),_Color.rgb,node_9829),_Color_copy.rgb,saturate((sceneZ-partZ)/_Depth_low));
                float3 diffuseColor = node_8006;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float3 emissive = (node_8006*0.3);
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
                float node_7916 = lerp(lerp(_Opacity,_Opacity_foam,node_5539),_Opacity,node_9829);
                fixed4 finalRGBA = fixed4(finalColor,node_7916);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _CameraDepthTexture;
            uniform float4 _TimeEditor;
            uniform float _Opacity;
            uniform float4 _Color;
            uniform float4 _Color_copy;
            uniform float _Depth_low;
            uniform float _Depth_up;
            uniform sampler2D _Cloud; uniform float4 _Cloud_ST;
            uniform float _Opacity_foam;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform float _Normal_intensity;
            uniform float _Specular;
            uniform float _Gloss;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                float4 projPos : TEXCOORD5;
                LIGHTING_COORDS(6,7)
                UNITY_FOG_COORDS(8)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 node_8838 = _Time + _TimeEditor;
                float2 node_5711 = (i.uv0+node_8838.g*float2(0,-0.01));
                float3 _Normal_var = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(node_5711, _Normal)));
                float3 normalLocal = lerp(float3(0,0,1),_Normal_var.rgb,_Normal_intensity);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = _Gloss;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float3 specularColor = float3(_Specular,_Specular,_Specular);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float node_5348 = 1.0;
                float4 node_7095 = _Time + _TimeEditor;
                float2 node_6641 = (i.uv0+(node_7095.g*0.005)*float2(1,1));
                float4 _Cloud_var = tex2D(_Cloud,TRANSFORM_TEX(node_6641, _Cloud));
                float node_5539 = saturate((1.0 - pow((_Cloud_var.r*1.5),6.0)));
                float node_9829 = pow(saturate((sceneZ-partZ)/_Depth_up),5.0);
                float3 node_8006 = lerp(lerp(lerp(_Color.rgb,float3(node_5348,node_5348,node_5348),node_5539),_Color.rgb,node_9829),_Color_copy.rgb,saturate((sceneZ-partZ)/_Depth_low));
                float3 diffuseColor = node_8006;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                float node_7916 = lerp(lerp(_Opacity,_Opacity_foam,node_5539),_Opacity,node_9829);
                fixed4 finalRGBA = fixed4(finalColor * node_7916,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
