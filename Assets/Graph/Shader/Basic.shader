// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:9973,x:32993,y:32863,varname:node_9973,prsc:2|normal-1462-RGB,emission-6756-OUT,custl-7320-OUT,clip-353-A,olwid-858-OUT;n:type:ShaderForge.SFN_NormalVector,id:9175,x:29895,y:33030,prsc:2,pt:True;n:type:ShaderForge.SFN_ViewReflectionVector,id:9437,x:29895,y:33330,varname:node_9437,prsc:2;n:type:ShaderForge.SFN_LightVector,id:7744,x:29895,y:33182,varname:node_7744,prsc:2;n:type:ShaderForge.SFN_Dot,id:4216,x:30109,y:33097,varname:node_4216,prsc:2,dt:1|A-9175-OUT,B-7744-OUT;n:type:ShaderForge.SFN_Dot,id:5495,x:30109,y:33261,varname:node_5495,prsc:2,dt:1|A-7744-OUT,B-9437-OUT;n:type:ShaderForge.SFN_Power,id:4353,x:30874,y:33066,varname:node_4353,prsc:2|VAL-5495-OUT,EXP-2036-OUT;n:type:ShaderForge.SFN_Multiply,id:4640,x:31696,y:33103,varname:node_4640,prsc:2|A-9445-OUT,B-8697-RGB;n:type:ShaderForge.SFN_Exp,id:2036,x:30705,y:33223,varname:node_2036,prsc:2,et:1|IN-4622-OUT;n:type:ShaderForge.SFN_RemapRange,id:4622,x:30540,y:33223,varname:node_4622,prsc:2,frmn:0,frmx:1,tomn:1,tomx:11|IN-7238-OUT;n:type:ShaderForge.SFN_Slider,id:7238,x:30540,y:33426,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:node_7238,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:1;n:type:ShaderForge.SFN_Color,id:8697,x:31459,y:33230,ptovrint:False,ptlb:Specular,ptin:_Specular,varname:node_8697,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Add,id:8968,x:31929,y:33012,varname:node_8968,prsc:2|A-4378-OUT,B-4640-OUT;n:type:ShaderForge.SFN_Multiply,id:4378,x:31696,y:32914,varname:node_4378,prsc:2|A-5714-OUT,B-9574-OUT;n:type:ShaderForge.SFN_Multiply,id:6756,x:31696,y:32674,varname:node_6756,prsc:2|A-9797-RGB,B-5714-OUT;n:type:ShaderForge.SFN_Multiply,id:5714,x:31468,y:32693,varname:node_5714,prsc:2|A-9047-RGB,B-353-RGB;n:type:ShaderForge.SFN_AmbientLight,id:9797,x:31468,y:32540,varname:node_9797,prsc:2;n:type:ShaderForge.SFN_Color,id:9047,x:31258,y:32530,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_9047,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Tex2d,id:353,x:31258,y:32712,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:node_353,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:b66bceaf0cc0ace4e9bdc92f14bba709,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:1462,x:31696,y:32434,ptovrint:False,ptlb:Normal,ptin:_Normal,varname:node_1462,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:bbab0a6f7bae9cf42bf057d8ee2755f6,ntxv:3,isnm:True;n:type:ShaderForge.SFN_LightColor,id:6372,x:31929,y:33169,varname:node_6372,prsc:2;n:type:ShaderForge.SFN_LightAttenuation,id:7338,x:30109,y:32746,varname:node_7338,prsc:2;n:type:ShaderForge.SFN_Multiply,id:7320,x:32235,y:33014,varname:node_7320,prsc:2|A-8968-OUT,B-6372-RGB;n:type:ShaderForge.SFN_Step,id:4270,x:31050,y:33066,varname:node_4270,prsc:2|A-944-OUT,B-4353-OUT;n:type:ShaderForge.SFN_Vector1,id:944,x:30874,y:33012,varname:node_944,prsc:2,v1:0.3;n:type:ShaderForge.SFN_Multiply,id:411,x:31249,y:33066,varname:node_411,prsc:2|A-4270-OUT,B-4424-OUT;n:type:ShaderForge.SFN_Vector1,id:2098,x:30825,y:32714,varname:node_2098,prsc:2,v1:0.2;n:type:ShaderForge.SFN_If,id:9574,x:31062,y:32848,varname:node_9574,prsc:2|A-6105-OUT,B-2098-OUT,GT-3537-OUT,EQ-5914-OUT,LT-5914-OUT;n:type:ShaderForge.SFN_Vector1,id:3537,x:30825,y:32791,varname:node_3537,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:6105,x:30678,y:32849,varname:node_6105,prsc:2|A-816-OUT,B-6685-OUT;n:type:ShaderForge.SFN_OneMinus,id:5914,x:30825,y:32564,varname:node_5914,prsc:2|IN-391-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9704,x:32292,y:33602,ptovrint:False,ptlb:Outline_standard,ptin:_Outline_standard,varname:node_9704,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_ToggleProperty,id:2343,x:31249,y:32998,ptovrint:False,ptlb:Use_light,ptin:_Use_light,varname:node_2343,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True;n:type:ShaderForge.SFN_Multiply,id:9445,x:31459,y:33044,varname:node_9445,prsc:2|A-2343-OUT,B-411-OUT;n:type:ShaderForge.SFN_Slider,id:4424,x:30893,y:33226,ptovrint:False,ptlb:Light_intensity,ptin:_Light_intensity,varname:node_4424,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.4,max:1;n:type:ShaderForge.SFN_Slider,id:391,x:30466,y:32526,ptovrint:False,ptlb:Shadow_intensity,ptin:_Shadow_intensity,varname:node_391,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:1;n:type:ShaderForge.SFN_ToggleProperty,id:5388,x:30109,y:32964,ptovrint:False,ptlb:Use_Shadowself,ptin:_Use_Shadowself,varname:node_5388,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True;n:type:ShaderForge.SFN_ToggleProperty,id:8622,x:30109,y:32680,ptovrint:False,ptlb:Use_Shadowother,ptin:_Use_Shadowother,varname:node_8622,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True;n:type:ShaderForge.SFN_If,id:816,x:30488,y:32721,varname:node_816,prsc:2|A-5437-OUT,B-8622-OUT,GT-5437-OUT,EQ-7338-OUT,LT-5437-OUT;n:type:ShaderForge.SFN_Vector1,id:5437,x:30109,y:32602,varname:node_5437,prsc:2,v1:1;n:type:ShaderForge.SFN_If,id:6685,x:30488,y:32868,varname:node_6685,prsc:2|A-5437-OUT,B-5388-OUT,GT-9889-OUT,EQ-4216-OUT,LT-9889-OUT;n:type:ShaderForge.SFN_Vector1,id:9889,x:30109,y:32879,varname:node_9889,prsc:2,v1:1;n:type:ShaderForge.SFN_RemapRange,id:6363,x:32508,y:33602,varname:node_6363,prsc:2,frmn:0,frmx:1,tomn:0,tomx:0.1|IN-9704-OUT;n:type:ShaderForge.SFN_ViewPosition,id:2330,x:31290,y:33563,varname:node_2330,prsc:2;n:type:ShaderForge.SFN_ObjectPosition,id:4455,x:31289,y:33848,varname:node_4455,prsc:2;n:type:ShaderForge.SFN_Subtract,id:145,x:31585,y:33641,varname:node_145,prsc:2|A-2330-X,B-4455-X;n:type:ShaderForge.SFN_Multiply,id:8971,x:31790,y:33641,varname:node_8971,prsc:2|A-145-OUT,B-145-OUT;n:type:ShaderForge.SFN_Subtract,id:6818,x:31540,y:33789,varname:node_6818,prsc:2|A-2330-Y,B-4455-Y;n:type:ShaderForge.SFN_Subtract,id:5732,x:31551,y:33949,varname:node_5732,prsc:2|A-2330-Z,B-4455-Z;n:type:ShaderForge.SFN_Multiply,id:1509,x:31833,y:33806,varname:node_1509,prsc:2|A-6818-OUT,B-6818-OUT;n:type:ShaderForge.SFN_Multiply,id:1194,x:31807,y:33964,varname:node_1194,prsc:2|A-5732-OUT,B-5732-OUT;n:type:ShaderForge.SFN_Add,id:4241,x:32072,y:33806,varname:node_4241,prsc:2|A-8971-OUT,B-1509-OUT,C-1194-OUT;n:type:ShaderForge.SFN_Sqrt,id:2471,x:32271,y:33806,varname:node_2471,prsc:2|IN-4241-OUT;n:type:ShaderForge.SFN_Slider,id:9650,x:32072,y:33989,ptovrint:False,ptlb:Outline_dynamic,ptin:_Outline_dynamic,varname:node_9650,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:0.002;n:type:ShaderForge.SFN_Multiply,id:1548,x:32508,y:33806,varname:node_1548,prsc:2|A-2471-OUT,B-9650-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:858,x:32865,y:33709,ptovrint:False,ptlb:Dynamic_Outline,ptin:_Dynamic_Outline,varname:node_858,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-6363-OUT,B-1548-OUT;proporder:9047-353-1462-7238-8697-2343-4424-391-8622-5388-858-9704-9650;pass:END;sub:END;*/

Shader "Custom/Basic" {
    Properties {
        _Color ("Color", Color) = (0.5,0.5,0.5,1)
        _Diffuse ("Diffuse", 2D) = "white" {}
        _Normal ("Normal", 2D) = "bump" {}
        _Gloss ("Gloss", Range(0, 1)) = 0.5
        _Specular ("Specular", Color) = (0.5,0.5,0.5,1)
        [MaterialToggle] _Use_light ("Use_light", Float ) = 1
        _Light_intensity ("Light_intensity", Range(0, 1)) = 0.4
        _Shadow_intensity ("Shadow_intensity", Range(0, 1)) = 0.5
        [MaterialToggle] _Use_Shadowother ("Use_Shadowother", Float ) = 1
        [MaterialToggle] _Use_Shadowself ("Use_Shadowself", Float ) = 1
        [MaterialToggle] _Dynamic_Outline ("Dynamic_Outline", Float ) = 0
        _Outline_standard ("Outline_standard", Float ) = 0
        _Outline_dynamic ("Outline_dynamic", Range(0, 0.002)) = 0
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        LOD 200
        Pass {
            Name "Outline"
            Tags {
            }
            Cull Front
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float _Outline_standard;
            uniform float _Outline_dynamic;
            uniform fixed _Dynamic_Outline;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                float node_145 = (_WorldSpaceCameraPos.r-objPos.r);
                float node_6818 = (_WorldSpaceCameraPos.g-objPos.g);
                float node_5732 = (_WorldSpaceCameraPos.b-objPos.b);
                o.pos = mul(UNITY_MATRIX_MVP, float4(v.vertex.xyz + v.normal*lerp( (_Outline_standard*0.1+0.0), (sqrt(((node_145*node_145)+(node_6818*node_6818)+(node_5732*node_5732)))*_Outline_dynamic), _Dynamic_Outline ),1) );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                clip(_Diffuse_var.a - 0.5);
                return fixed4(float3(0,0,0),0);
            }
            ENDCG
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float _Gloss;
            uniform float4 _Specular;
            uniform float4 _Color;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform fixed _Use_light;
            uniform float _Light_intensity;
            uniform float _Shadow_intensity;
            uniform fixed _Use_Shadowself;
            uniform fixed _Use_Shadowother;
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
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
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
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normal_var = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal)));
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                clip(_Diffuse_var.a - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
////// Emissive:
                float3 node_5714 = (_Color.rgb*_Diffuse_var.rgb);
                float3 emissive = (UNITY_LIGHTMODEL_AMBIENT.rgb*node_5714);
                float node_5437 = 1.0;
                float node_816_if_leA = step(node_5437,_Use_Shadowother);
                float node_816_if_leB = step(_Use_Shadowother,node_5437);
                float node_6685_if_leA = step(node_5437,_Use_Shadowself);
                float node_6685_if_leB = step(_Use_Shadowself,node_5437);
                float node_9889 = 1.0;
                float node_9574_if_leA = step((lerp((node_816_if_leA*node_5437)+(node_816_if_leB*node_5437),attenuation,node_816_if_leA*node_816_if_leB)*lerp((node_6685_if_leA*node_9889)+(node_6685_if_leB*node_9889),max(0,dot(normalDirection,lightDirection)),node_6685_if_leA*node_6685_if_leB)),0.2);
                float node_9574_if_leB = step(0.2,(lerp((node_816_if_leA*node_5437)+(node_816_if_leB*node_5437),attenuation,node_816_if_leA*node_816_if_leB)*lerp((node_6685_if_leA*node_9889)+(node_6685_if_leB*node_9889),max(0,dot(normalDirection,lightDirection)),node_6685_if_leA*node_6685_if_leB)));
                float node_5914 = (1.0 - _Shadow_intensity);
                float3 finalColor = emissive + (((node_5714*lerp((node_9574_if_leA*node_5914)+(node_9574_if_leB*1.0),node_5914,node_9574_if_leA*node_9574_if_leB))+((_Use_light*(step(0.3,pow(max(0,dot(lightDirection,viewReflectDirection)),exp2((_Gloss*10.0+1.0))))*_Light_intensity))*_Specular.rgb))*_LightColor0.rgb);
                fixed4 finalRGBA = fixed4(finalColor,1);
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
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float _Gloss;
            uniform float4 _Specular;
            uniform float4 _Color;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform fixed _Use_light;
            uniform float _Light_intensity;
            uniform float _Shadow_intensity;
            uniform fixed _Use_Shadowself;
            uniform fixed _Use_Shadowother;
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
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
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
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normal_var = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal)));
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                clip(_Diffuse_var.a - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 node_5714 = (_Color.rgb*_Diffuse_var.rgb);
                float node_5437 = 1.0;
                float node_816_if_leA = step(node_5437,_Use_Shadowother);
                float node_816_if_leB = step(_Use_Shadowother,node_5437);
                float node_6685_if_leA = step(node_5437,_Use_Shadowself);
                float node_6685_if_leB = step(_Use_Shadowself,node_5437);
                float node_9889 = 1.0;
                float node_9574_if_leA = step((lerp((node_816_if_leA*node_5437)+(node_816_if_leB*node_5437),attenuation,node_816_if_leA*node_816_if_leB)*lerp((node_6685_if_leA*node_9889)+(node_6685_if_leB*node_9889),max(0,dot(normalDirection,lightDirection)),node_6685_if_leA*node_6685_if_leB)),0.2);
                float node_9574_if_leB = step(0.2,(lerp((node_816_if_leA*node_5437)+(node_816_if_leB*node_5437),attenuation,node_816_if_leA*node_816_if_leB)*lerp((node_6685_if_leA*node_9889)+(node_6685_if_leB*node_9889),max(0,dot(normalDirection,lightDirection)),node_6685_if_leA*node_6685_if_leB)));
                float node_5914 = (1.0 - _Shadow_intensity);
                float3 finalColor = (((node_5714*lerp((node_9574_if_leA*node_5914)+(node_9574_if_leB*1.0),node_5914,node_9574_if_leA*node_9574_if_leB))+((_Use_light*(step(0.3,pow(max(0,dot(lightDirection,viewReflectDirection)),exp2((_Gloss*10.0+1.0))))*_Light_intensity))*_Specular.rgb))*_LightColor0.rgb);
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                clip(_Diffuse_var.a - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
