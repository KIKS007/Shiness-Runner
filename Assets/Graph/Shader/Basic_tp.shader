// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:9973,x:32993,y:32863,varname:node_9973,prsc:2|normal-1462-RGB,emission-6756-OUT,custl-7320-OUT,olwid-858-OUT;n:type:ShaderForge.SFN_NormalVector,id:9175,x:29895,y:33030,prsc:2,pt:True;n:type:ShaderForge.SFN_ViewReflectionVector,id:9437,x:29895,y:33330,varname:node_9437,prsc:2;n:type:ShaderForge.SFN_LightVector,id:7744,x:29895,y:33182,varname:node_7744,prsc:2;n:type:ShaderForge.SFN_Dot,id:4216,x:30109,y:33097,varname:node_4216,prsc:2,dt:1|A-9175-OUT,B-7744-OUT;n:type:ShaderForge.SFN_Dot,id:5495,x:30109,y:33261,varname:node_5495,prsc:2,dt:1|A-7744-OUT,B-9437-OUT;n:type:ShaderForge.SFN_Power,id:4353,x:30874,y:33066,varname:node_4353,prsc:2|VAL-5495-OUT,EXP-2036-OUT;n:type:ShaderForge.SFN_Multiply,id:4640,x:31696,y:33103,varname:node_4640,prsc:2|A-9445-OUT,B-8697-RGB;n:type:ShaderForge.SFN_Exp,id:2036,x:30705,y:33223,varname:node_2036,prsc:2,et:1|IN-4622-OUT;n:type:ShaderForge.SFN_RemapRange,id:4622,x:30540,y:33223,varname:node_4622,prsc:2,frmn:0,frmx:1,tomn:1,tomx:11|IN-7238-OUT;n:type:ShaderForge.SFN_Slider,id:7238,x:30540,y:33426,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:node_7238,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:1;n:type:ShaderForge.SFN_Color,id:8697,x:31459,y:33230,ptovrint:False,ptlb:Specular,ptin:_Specular,varname:node_8697,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Add,id:8968,x:31929,y:33012,varname:node_8968,prsc:2|A-4378-OUT,B-4640-OUT;n:type:ShaderForge.SFN_Multiply,id:4378,x:31696,y:32914,varname:node_4378,prsc:2|A-5714-OUT,B-9574-OUT;n:type:ShaderForge.SFN_Multiply,id:6756,x:32505,y:31929,varname:node_6756,prsc:2|A-9797-RGB,B-5714-OUT;n:type:ShaderForge.SFN_Multiply,id:5714,x:32116,y:31963,varname:node_5714,prsc:2|A-9047-RGB,B-7893-OUT;n:type:ShaderForge.SFN_AmbientLight,id:9797,x:32116,y:31834,varname:node_9797,prsc:2;n:type:ShaderForge.SFN_Color,id:9047,x:31630,y:31788,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_9047,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Tex2d,id:1462,x:32235,y:32834,ptovrint:False,ptlb:Normal,ptin:_Normal,varname:node_1462,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:bbab0a6f7bae9cf42bf057d8ee2755f6,ntxv:3,isnm:True;n:type:ShaderForge.SFN_LightColor,id:6372,x:31929,y:33169,varname:node_6372,prsc:2;n:type:ShaderForge.SFN_LightAttenuation,id:7338,x:30109,y:32746,varname:node_7338,prsc:2;n:type:ShaderForge.SFN_Multiply,id:7320,x:32235,y:33014,varname:node_7320,prsc:2|A-8968-OUT,B-6372-RGB;n:type:ShaderForge.SFN_Step,id:4270,x:31050,y:33066,varname:node_4270,prsc:2|A-944-OUT,B-4353-OUT;n:type:ShaderForge.SFN_Vector1,id:944,x:30874,y:33012,varname:node_944,prsc:2,v1:0.3;n:type:ShaderForge.SFN_Multiply,id:411,x:31249,y:33066,varname:node_411,prsc:2|A-4270-OUT,B-4424-OUT;n:type:ShaderForge.SFN_Vector1,id:2098,x:30825,y:32714,varname:node_2098,prsc:2,v1:0.2;n:type:ShaderForge.SFN_If,id:9574,x:31062,y:32848,varname:node_9574,prsc:2|A-6105-OUT,B-2098-OUT,GT-3537-OUT,EQ-5914-OUT,LT-5914-OUT;n:type:ShaderForge.SFN_Vector1,id:3537,x:30825,y:32791,varname:node_3537,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:6105,x:30678,y:32849,varname:node_6105,prsc:2|A-816-OUT,B-6685-OUT;n:type:ShaderForge.SFN_OneMinus,id:5914,x:30825,y:32564,varname:node_5914,prsc:2|IN-391-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9704,x:32292,y:33602,ptovrint:False,ptlb:Outline_standard,ptin:_Outline_standard,varname:node_9704,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_ToggleProperty,id:2343,x:31249,y:32998,ptovrint:False,ptlb:Use_light,ptin:_Use_light,varname:node_2343,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True;n:type:ShaderForge.SFN_Multiply,id:9445,x:31459,y:33044,varname:node_9445,prsc:2|A-2343-OUT,B-411-OUT;n:type:ShaderForge.SFN_Slider,id:4424,x:30893,y:33226,ptovrint:False,ptlb:Light_intensity,ptin:_Light_intensity,varname:node_4424,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.4,max:1;n:type:ShaderForge.SFN_Slider,id:391,x:30466,y:32526,ptovrint:False,ptlb:Shadow_intensity,ptin:_Shadow_intensity,varname:node_391,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:1;n:type:ShaderForge.SFN_ToggleProperty,id:5388,x:30109,y:32964,ptovrint:False,ptlb:Use_Shadowself,ptin:_Use_Shadowself,varname:node_5388,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True;n:type:ShaderForge.SFN_ToggleProperty,id:8622,x:30109,y:32680,ptovrint:False,ptlb:Use_Shadowother,ptin:_Use_Shadowother,varname:node_8622,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True;n:type:ShaderForge.SFN_If,id:816,x:30488,y:32721,varname:node_816,prsc:2|A-5437-OUT,B-8622-OUT,GT-5437-OUT,EQ-7338-OUT,LT-5437-OUT;n:type:ShaderForge.SFN_Vector1,id:5437,x:30109,y:32602,varname:node_5437,prsc:2,v1:1;n:type:ShaderForge.SFN_If,id:6685,x:30488,y:32868,varname:node_6685,prsc:2|A-5437-OUT,B-5388-OUT,GT-9889-OUT,EQ-4216-OUT,LT-9889-OUT;n:type:ShaderForge.SFN_Vector1,id:9889,x:30109,y:32879,varname:node_9889,prsc:2,v1:1;n:type:ShaderForge.SFN_RemapRange,id:6363,x:32508,y:33602,varname:node_6363,prsc:2,frmn:0,frmx:1,tomn:0,tomx:0.1|IN-9704-OUT;n:type:ShaderForge.SFN_ViewPosition,id:2330,x:31290,y:33563,varname:node_2330,prsc:2;n:type:ShaderForge.SFN_ObjectPosition,id:4455,x:31289,y:33848,varname:node_4455,prsc:2;n:type:ShaderForge.SFN_Subtract,id:145,x:31585,y:33641,varname:node_145,prsc:2|A-2330-X,B-4455-X;n:type:ShaderForge.SFN_Multiply,id:8971,x:31790,y:33641,varname:node_8971,prsc:2|A-145-OUT,B-145-OUT;n:type:ShaderForge.SFN_Subtract,id:6818,x:31540,y:33789,varname:node_6818,prsc:2|A-2330-Y,B-4455-Y;n:type:ShaderForge.SFN_Subtract,id:5732,x:31551,y:33949,varname:node_5732,prsc:2|A-2330-Z,B-4455-Z;n:type:ShaderForge.SFN_Multiply,id:1509,x:31833,y:33806,varname:node_1509,prsc:2|A-6818-OUT,B-6818-OUT;n:type:ShaderForge.SFN_Multiply,id:1194,x:31807,y:33964,varname:node_1194,prsc:2|A-5732-OUT,B-5732-OUT;n:type:ShaderForge.SFN_Add,id:4241,x:32072,y:33806,varname:node_4241,prsc:2|A-8971-OUT,B-1509-OUT,C-1194-OUT;n:type:ShaderForge.SFN_Sqrt,id:2471,x:32271,y:33806,varname:node_2471,prsc:2|IN-4241-OUT;n:type:ShaderForge.SFN_Slider,id:9650,x:32072,y:33989,ptovrint:False,ptlb:Outline_dynamic,ptin:_Outline_dynamic,varname:node_9650,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:0.002;n:type:ShaderForge.SFN_Multiply,id:1548,x:32508,y:33806,varname:node_1548,prsc:2|A-2471-OUT,B-9650-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:858,x:32865,y:33709,ptovrint:False,ptlb:Dynamic_Outline,ptin:_Dynamic_Outline,varname:node_858,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-6363-OUT,B-1548-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:2445,x:30799,y:31959,varname:node_2445,prsc:2;n:type:ShaderForge.SFN_Append,id:6394,x:31069,y:31842,varname:node_6394,prsc:2|A-2445-Y,B-2445-Z;n:type:ShaderForge.SFN_Append,id:1145,x:31069,y:31989,varname:node_1145,prsc:2|A-2445-Z,B-2445-X;n:type:ShaderForge.SFN_Append,id:2368,x:31069,y:32131,varname:node_2368,prsc:2|A-2445-X,B-2445-Y;n:type:ShaderForge.SFN_Tex2dAsset,id:9687,x:31069,y:32295,ptovrint:False,ptlb:Albedo,ptin:_Albedo,varname:node_9687,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:b66bceaf0cc0ace4e9bdc92f14bba709,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:4736,x:31357,y:32130,varname:node_4736,prsc:2,tex:b66bceaf0cc0ace4e9bdc92f14bba709,ntxv:0,isnm:False|UVIN-2368-OUT,TEX-9687-TEX;n:type:ShaderForge.SFN_ChannelBlend,id:9038,x:31630,y:31968,varname:node_9038,prsc:2,chbt:0|M-5225-OUT,R-4590-RGB,G-6770-RGB,B-4736-RGB;n:type:ShaderForge.SFN_Tex2d,id:6770,x:31357,y:31991,varname:node_6770,prsc:2,tex:b66bceaf0cc0ace4e9bdc92f14bba709,ntxv:0,isnm:False|UVIN-1145-OUT,TEX-9687-TEX;n:type:ShaderForge.SFN_Tex2d,id:4590,x:31357,y:31843,varname:node_4590,prsc:2,tex:b66bceaf0cc0ace4e9bdc92f14bba709,ntxv:0,isnm:False|UVIN-6394-OUT,TEX-9687-TEX;n:type:ShaderForge.SFN_ComponentMask,id:5225,x:31357,y:31682,varname:node_5225,prsc:2,cc1:0,cc2:1,cc3:2,cc4:-1|IN-8008-OUT;n:type:ShaderForge.SFN_Multiply,id:8008,x:31069,y:31684,varname:node_8008,prsc:2|A-7324-OUT,B-7324-OUT;n:type:ShaderForge.SFN_Abs,id:7324,x:30799,y:31675,varname:node_7324,prsc:2|IN-4680-OUT;n:type:ShaderForge.SFN_NormalVector,id:4680,x:30599,y:31675,prsc:2,pt:False;n:type:ShaderForge.SFN_FragmentPosition,id:1008,x:29396,y:30567,varname:node_1008,prsc:2;n:type:ShaderForge.SFN_Lerp,id:8145,x:30884,y:30610,varname:node_8145,prsc:2|A-9038-OUT,B-5994-OUT,T-8752-OUT;n:type:ShaderForge.SFN_ObjectPosition,id:1441,x:29396,y:30710,varname:node_1441,prsc:2;n:type:ShaderForge.SFN_Subtract,id:914,x:29592,y:30645,varname:node_914,prsc:2|A-1008-Y,B-1441-Y;n:type:ShaderForge.SFN_Add,id:5158,x:29985,y:30646,varname:node_5158,prsc:2|A-5841-OUT,B-8389-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8389,x:29575,y:30808,ptovrint:False,ptlb:Height,ptin:_Height,varname:node_8389,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Clamp01,id:8752,x:30172,y:30646,varname:node_8752,prsc:2|IN-5158-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:5994,x:29973,y:30434,ptovrint:False,ptlb:Use moss,ptin:_Usemoss,varname:node_5994,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True|A-9038-OUT,B-9404-OUT;n:type:ShaderForge.SFN_Multiply,id:5841,x:29789,y:30645,varname:node_5841,prsc:2|A-914-OUT,B-5607-OUT;n:type:ShaderForge.SFN_Tex2d,id:1667,x:29230,y:31547,varname:node_1667,prsc:2,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-2368-OUT,TEX-2579-TEX;n:type:ShaderForge.SFN_Subtract,id:9602,x:28770,y:31022,varname:node_9602,prsc:2|A-1008-Y,B-1441-Y;n:type:ShaderForge.SFN_Add,id:855,x:29163,y:31023,varname:node_855,prsc:2|A-7108-OUT,B-6055-OUT;n:type:ShaderForge.SFN_Clamp01,id:4730,x:29350,y:31023,varname:node_4730,prsc:2|IN-855-OUT;n:type:ShaderForge.SFN_Multiply,id:7108,x:28966,y:31022,varname:node_7108,prsc:2|A-9602-OUT,B-2794-OUT;n:type:ShaderForge.SFN_Vector1,id:2794,x:28770,y:30966,varname:node_2794,prsc:2,v1:0.4;n:type:ShaderForge.SFN_Lerp,id:6677,x:30884,y:30759,varname:node_6677,prsc:2|A-9038-OUT,B-5994-OUT,T-8328-OUT;n:type:ShaderForge.SFN_Power,id:8774,x:29707,y:31396,varname:node_8774,prsc:2|VAL-3475-OUT,EXP-2040-OUT;n:type:ShaderForge.SFN_Vector1,id:2040,x:29459,y:31547,varname:node_2040,prsc:2,v1:4;n:type:ShaderForge.SFN_Lerp,id:7893,x:31257,y:30740,varname:node_7893,prsc:2|A-6677-OUT,B-8145-OUT,T-4730-OUT;n:type:ShaderForge.SFN_Multiply,id:4831,x:30067,y:31400,varname:node_4831,prsc:2|A-9323-OUT,B-8752-OUT;n:type:ShaderForge.SFN_Multiply,id:9323,x:29897,y:31400,varname:node_9323,prsc:2|A-8774-OUT,B-2040-OUT;n:type:ShaderForge.SFN_Subtract,id:6055,x:28770,y:31149,varname:node_6055,prsc:2|A-8389-OUT,B-8602-OUT;n:type:ShaderForge.SFN_Clamp01,id:8328,x:30269,y:31400,varname:node_8328,prsc:2|IN-4831-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8602,x:28540,y:31163,ptovrint:False,ptlb:Moss_offset,ptin:_Moss_offset,varname:node_8602,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_ChannelBlend,id:1110,x:31697,y:31268,varname:node_1110,prsc:2,chbt:0;n:type:ShaderForge.SFN_Tex2dAsset,id:9721,x:28593,y:30242,ptovrint:False,ptlb:Moss,ptin:_Moss,varname:node_9721,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:ac0a09e34701202498d5fd59b7615923,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:5768,x:28914,y:30064,varname:node_5768,prsc:2,tex:ac0a09e34701202498d5fd59b7615923,ntxv:0,isnm:False|UVIN-6394-OUT,TEX-9721-TEX;n:type:ShaderForge.SFN_Tex2d,id:2404,x:28914,y:30212,varname:node_2404,prsc:2,tex:ac0a09e34701202498d5fd59b7615923,ntxv:0,isnm:False|UVIN-1145-OUT,TEX-9721-TEX;n:type:ShaderForge.SFN_Tex2d,id:5982,x:28914,y:30358,varname:node_5982,prsc:2,tex:ac0a09e34701202498d5fd59b7615923,ntxv:0,isnm:False|UVIN-2368-OUT,TEX-9721-TEX;n:type:ShaderForge.SFN_ChannelBlend,id:9404,x:29181,y:30184,varname:node_9404,prsc:2,chbt:0|M-5225-OUT,R-5768-RGB,G-2404-RGB,B-5982-RGB;n:type:ShaderForge.SFN_ValueProperty,id:5607,x:29597,y:30500,ptovrint:False,ptlb:Moss_transition,ptin:_Moss_transition,varname:node_5607,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.4;n:type:ShaderForge.SFN_Tex2dAsset,id:2579,x:28972,y:31439,ptovrint:False,ptlb:Transition,ptin:_Transition,varname:node_2579,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:5095,x:29230,y:31411,varname:node_5095,prsc:2,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-1145-OUT,TEX-2579-TEX;n:type:ShaderForge.SFN_Tex2d,id:7688,x:29230,y:31271,varname:node_7688,prsc:2,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-6394-OUT,TEX-2579-TEX;n:type:ShaderForge.SFN_ChannelBlend,id:3475,x:29459,y:31387,varname:node_3475,prsc:2,chbt:0|M-5225-OUT,R-7688-RGB,G-5095-RGB,B-1667-RGB;proporder:9047-9687-1462-7238-8697-2343-4424-391-8622-5388-858-9704-9650-5994-8389-9721-8602-5607-2579;pass:END;sub:END;*/

Shader "Custom/Basic_tp" {
    Properties {
        _Color ("Color", Color) = (0.5,0.5,0.5,1)
        _Albedo ("Albedo", 2D) = "white" {}
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
        [MaterialToggle] _Usemoss ("Use moss", Float ) = 0
        _Height ("Height", Float ) = 0
        _Moss ("Moss", 2D) = "white" {}
        _Moss_offset ("Moss_offset", Float ) = 1
        _Moss_transition ("Moss_transition", Float ) = 0.4
        _Transition ("Transition", 2D) = "white" {}
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
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
            uniform float _Outline_standard;
            uniform float _Outline_dynamic;
            uniform fixed _Dynamic_Outline;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_FOG_COORDS(0)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                float node_145 = (_WorldSpaceCameraPos.r-objPos.r);
                float node_6818 = (_WorldSpaceCameraPos.g-objPos.g);
                float node_5732 = (_WorldSpaceCameraPos.b-objPos.b);
                o.pos = mul(UNITY_MATRIX_MVP, float4(v.vertex.xyz + v.normal*lerp( (_Outline_standard*0.1+0.0), (sqrt(((node_145*node_145)+(node_6818*node_6818)+(node_5732*node_5732)))*_Outline_dynamic), _Dynamic_Outline ),1) );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                return fixed4(float3(0,0,0),0);
            }
            ENDCG
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
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
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform fixed _Use_light;
            uniform float _Light_intensity;
            uniform float _Shadow_intensity;
            uniform fixed _Use_Shadowself;
            uniform fixed _Use_Shadowother;
            uniform sampler2D _Albedo; uniform float4 _Albedo_ST;
            uniform float _Height;
            uniform fixed _Usemoss;
            uniform float _Moss_offset;
            uniform sampler2D _Moss; uniform float4 _Moss_ST;
            uniform float _Moss_transition;
            uniform sampler2D _Transition; uniform float4 _Transition_ST;
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
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normal_var = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal)));
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
////// Emissive:
                float3 node_7324 = abs(i.normalDir);
                float3 node_5225 = (node_7324*node_7324).rgb;
                float2 node_6394 = float2(i.posWorld.g,i.posWorld.b);
                float4 node_4590 = tex2D(_Albedo,TRANSFORM_TEX(node_6394, _Albedo));
                float2 node_1145 = float2(i.posWorld.b,i.posWorld.r);
                float4 node_6770 = tex2D(_Albedo,TRANSFORM_TEX(node_1145, _Albedo));
                float2 node_2368 = float2(i.posWorld.r,i.posWorld.g);
                float4 node_4736 = tex2D(_Albedo,TRANSFORM_TEX(node_2368, _Albedo));
                float3 node_9038 = (node_5225.r*node_4590.rgb + node_5225.g*node_6770.rgb + node_5225.b*node_4736.rgb);
                float4 node_5768 = tex2D(_Moss,TRANSFORM_TEX(node_6394, _Moss));
                float4 node_2404 = tex2D(_Moss,TRANSFORM_TEX(node_1145, _Moss));
                float4 node_5982 = tex2D(_Moss,TRANSFORM_TEX(node_2368, _Moss));
                float3 _Usemoss_var = lerp( node_9038, (node_5225.r*node_5768.rgb + node_5225.g*node_2404.rgb + node_5225.b*node_5982.rgb), _Usemoss );
                float4 node_7688 = tex2D(_Transition,TRANSFORM_TEX(node_6394, _Transition));
                float4 node_5095 = tex2D(_Transition,TRANSFORM_TEX(node_1145, _Transition));
                float4 node_1667 = tex2D(_Transition,TRANSFORM_TEX(node_2368, _Transition));
                float node_2040 = 4.0;
                float node_8752 = saturate((((i.posWorld.g-objPos.g)*_Moss_transition)+_Height));
                float3 node_5714 = (_Color.rgb*lerp(lerp(node_9038,_Usemoss_var,saturate(((pow((node_5225.r*node_7688.rgb + node_5225.g*node_5095.rgb + node_5225.b*node_1667.rgb),node_2040)*node_2040)*node_8752))),lerp(node_9038,_Usemoss_var,node_8752),saturate((((i.posWorld.g-objPos.g)*0.4)+(_Height-_Moss_offset)))));
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
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform fixed _Use_light;
            uniform float _Light_intensity;
            uniform float _Shadow_intensity;
            uniform fixed _Use_Shadowself;
            uniform fixed _Use_Shadowother;
            uniform sampler2D _Albedo; uniform float4 _Albedo_ST;
            uniform float _Height;
            uniform fixed _Usemoss;
            uniform float _Moss_offset;
            uniform sampler2D _Moss; uniform float4 _Moss_ST;
            uniform float _Moss_transition;
            uniform sampler2D _Transition; uniform float4 _Transition_ST;
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
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normal_var = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal)));
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 node_7324 = abs(i.normalDir);
                float3 node_5225 = (node_7324*node_7324).rgb;
                float2 node_6394 = float2(i.posWorld.g,i.posWorld.b);
                float4 node_4590 = tex2D(_Albedo,TRANSFORM_TEX(node_6394, _Albedo));
                float2 node_1145 = float2(i.posWorld.b,i.posWorld.r);
                float4 node_6770 = tex2D(_Albedo,TRANSFORM_TEX(node_1145, _Albedo));
                float2 node_2368 = float2(i.posWorld.r,i.posWorld.g);
                float4 node_4736 = tex2D(_Albedo,TRANSFORM_TEX(node_2368, _Albedo));
                float3 node_9038 = (node_5225.r*node_4590.rgb + node_5225.g*node_6770.rgb + node_5225.b*node_4736.rgb);
                float4 node_5768 = tex2D(_Moss,TRANSFORM_TEX(node_6394, _Moss));
                float4 node_2404 = tex2D(_Moss,TRANSFORM_TEX(node_1145, _Moss));
                float4 node_5982 = tex2D(_Moss,TRANSFORM_TEX(node_2368, _Moss));
                float3 _Usemoss_var = lerp( node_9038, (node_5225.r*node_5768.rgb + node_5225.g*node_2404.rgb + node_5225.b*node_5982.rgb), _Usemoss );
                float4 node_7688 = tex2D(_Transition,TRANSFORM_TEX(node_6394, _Transition));
                float4 node_5095 = tex2D(_Transition,TRANSFORM_TEX(node_1145, _Transition));
                float4 node_1667 = tex2D(_Transition,TRANSFORM_TEX(node_2368, _Transition));
                float node_2040 = 4.0;
                float node_8752 = saturate((((i.posWorld.g-objPos.g)*_Moss_transition)+_Height));
                float3 node_5714 = (_Color.rgb*lerp(lerp(node_9038,_Usemoss_var,saturate(((pow((node_5225.r*node_7688.rgb + node_5225.g*node_5095.rgb + node_5225.b*node_1667.rgb),node_2040)*node_2040)*node_8752))),lerp(node_9038,_Usemoss_var,node_8752),saturate((((i.posWorld.g-objPos.g)*0.4)+(_Height-_Moss_offset)))));
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
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
