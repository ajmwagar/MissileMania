// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.34 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.34;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:True,rprd:True,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:32794,y:32678,varname:node_3138,prsc:2|diff-6164-OUT,spec-4442-OUT,normal-5467-OUT,emission-174-OUT,transm-6155-OUT,lwrap-6155-OUT,custl-6155-OUT,voffset-8057-OUT;n:type:ShaderForge.SFN_Subtract,id:3597,x:31445,y:32882,varname:node_3597,prsc:2|A-2207-OUT,B-4805-OUT;n:type:ShaderForge.SFN_Vector1,id:4805,x:31266,y:32964,varname:node_4805,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Abs,id:195,x:31617,y:32882,varname:node_195,prsc:2|IN-3597-OUT;n:type:ShaderForge.SFN_Frac,id:2207,x:31266,y:32830,varname:node_2207,prsc:2|IN-3973-OUT;n:type:ShaderForge.SFN_Panner,id:4066,x:30928,y:32830,varname:node_4066,prsc:2,spu:0.25,spv:0|UVIN-2617-UVOUT;n:type:ShaderForge.SFN_ComponentMask,id:3973,x:31095,y:32830,varname:node_3973,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-4066-UVOUT;n:type:ShaderForge.SFN_Multiply,id:3513,x:31792,y:32932,cmnt:Triangle Wave,varname:node_3513,prsc:2|A-195-OUT,B-9897-OUT;n:type:ShaderForge.SFN_Vector1,id:9897,x:31617,y:33018,varname:node_9897,prsc:2,v1:2;n:type:ShaderForge.SFN_Power,id:6155,x:31996,y:32995,cmnt:Panning gradient,varname:node_6155,prsc:2|VAL-3513-OUT,EXP-8970-OUT;n:type:ShaderForge.SFN_NormalVector,id:5430,x:32254,y:33572,prsc:2,pt:False;n:type:ShaderForge.SFN_Multiply,id:8057,x:32481,y:33402,varname:node_8057,prsc:2|A-4987-OUT,B-2087-OUT,C-5430-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2087,x:32254,y:33404,ptovrint:False,ptlb:Bulge Scale,ptin:_BulgeScale,varname:_BulgeScale,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.2;n:type:ShaderForge.SFN_Lerp,id:6164,x:32363,y:32671,varname:node_6164,prsc:2|A-423-RGB,B-2100-OUT,T-6155-OUT;n:type:ShaderForge.SFN_Lerp,id:2101,x:32223,y:32827,varname:node_2101,prsc:2|A-8964-RGB,B-9889-OUT,T-6155-OUT;n:type:ShaderForge.SFN_Multiply,id:174,x:32481,y:33234,cmnt:Glow,varname:node_174,prsc:2|A-3083-RGB,B-6248-OUT,C-4987-OUT;n:type:ShaderForge.SFN_Color,id:3083,x:32254,y:33066,ptovrint:False,ptlb:Glow Color,ptin:_GlowColor,varname:_GlowColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.2391481,c3:0.1102941,c4:1;n:type:ShaderForge.SFN_Vector3,id:9889,x:31996,y:32843,varname:node_9889,prsc:2,v1:0,v2:0,v3:1;n:type:ShaderForge.SFN_Normalize,id:5467,x:32481,y:33066,varname:node_5467,prsc:2|IN-2101-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8970,x:31792,y:33079,ptovrint:False,ptlb:Bulge Shape,ptin:_BulgeShape,varname:_BulgeShape,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:5;n:type:ShaderForge.SFN_Vector1,id:2100,x:32134,y:32692,varname:node_2100,prsc:2,v1:0.1;n:type:ShaderForge.SFN_ValueProperty,id:6248,x:32254,y:33236,ptovrint:False,ptlb:Glow Intensity,ptin:_GlowIntensity,varname:_GlowIntensity,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1.2;n:type:ShaderForge.SFN_TexCoord,id:2617,x:30709,y:32668,varname:node_2617,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Relay,id:4987,x:32254,y:33312,varname:node_4987,prsc:2|IN-6155-OUT;n:type:ShaderForge.SFN_Color,id:423,x:31721,y:32363,ptovrint:False,ptlb:Diffuse Color,ptin:_DiffuseColor,varname:node_423,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.8666667,c3:0.4666667,c4:0;n:type:ShaderForge.SFN_Tex2d,id:8964,x:31916,y:32657,ptovrint:False,ptlb:Normal Map,ptin:_NormalMap,varname:node_8964,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Slider,id:4442,x:32454,y:32413,ptovrint:False,ptlb:Specular,ptin:_Specular,varname:node_4442,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;proporder:3083-8970-6248-2087-423-8964-4442;pass:END;sub:END;*/

Shader "BlasterRings/VertexDisplacement" {
    Properties {
        _GlowColor ("Glow Color", Color) = (1,0.2391481,0.1102941,1)
        _BulgeShape ("Bulge Shape", Float ) = 5
        _GlowIntensity ("Glow Intensity", Float ) = 1.2
        _BulgeScale ("Bulge Scale", Float ) = 0.2
        _DiffuseColor ("Diffuse Color", Color) = (1,0.8666667,0.4666667,0)
        _NormalMap ("Normal Map", 2D) = "bump" {}
        _Specular ("Specular", Range(0, 1)) = 1
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
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
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float _BulgeScale;
            uniform float4 _GlowColor;
            uniform float _BulgeShape;
            uniform float _GlowIntensity;
            uniform float4 _DiffuseColor;
            uniform sampler2D _NormalMap; uniform float4 _NormalMap_ST;
            uniform float _Specular;
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
                float4 node_1618 = _Time + _TimeEditor;
                float node_6155 = pow((abs((frac((o.uv0+node_1618.g*float2(0.25,0)).r)-0.5))*2.0),_BulgeShape); // Panning gradient
                float node_4987 = node_6155;
                v.vertex.xyz += (node_4987*_BulgeScale*v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _NormalMap_var = UnpackNormal(tex2D(_NormalMap,TRANSFORM_TEX(i.uv0, _NormalMap)));
                float4 node_1618 = _Time + _TimeEditor;
                float node_6155 = pow((abs((frac((i.uv0+node_1618.g*float2(0.25,0)).r)-0.5))*2.0),_BulgeShape); // Panning gradient
                float3 normalLocal = normalize(lerp(_NormalMap_var.rgb,float3(0,0,1),node_6155));
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0+1.0);
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                #if UNITY_SPECCUBE_BLENDING || UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMin[0] = unity_SpecCube0_BoxMin;
                    d.boxMin[1] = unity_SpecCube1_BoxMin;
                #endif
                #if UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMax[0] = unity_SpecCube0_BoxMax;
                    d.boxMax[1] = unity_SpecCube1_BoxMax;
                    d.probePosition[0] = unity_SpecCube0_ProbePosition;
                    d.probePosition[1] = unity_SpecCube1_ProbePosition;
                #endif
                d.probeHDR[0] = unity_SpecCube0_HDR;
                d.probeHDR[1] = unity_SpecCube1_HDR;
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float3 specularColor = float3(_Specular,_Specular,_Specular);
                float3 directSpecular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 indirectSpecular = (gi.indirect.specular)*specularColor;
                float3 specular = (directSpecular + indirectSpecular);
/////// Diffuse:
                NdotL = dot( normalDirection, lightDirection );
                float3 w = float3(node_6155,node_6155,node_6155)*0.5; // Light wrapping
                float3 NdotLWrap = NdotL * ( 1.0 - w );
                float3 forwardLight = max(float3(0.0,0.0,0.0), NdotLWrap + w );
                float3 backLight = max(float3(0.0,0.0,0.0), -NdotLWrap + w ) * float3(node_6155,node_6155,node_6155);
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = (forwardLight+backLight) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float node_2100 = 0.1;
                float3 diffuseColor = lerp(_DiffuseColor.rgb,float3(node_2100,node_2100,node_2100),node_6155);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float node_4987 = node_6155;
                float3 emissive = (_GlowColor.rgb*_GlowIntensity*node_4987);
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
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
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float _BulgeScale;
            uniform float4 _GlowColor;
            uniform float _BulgeShape;
            uniform float _GlowIntensity;
            uniform float4 _DiffuseColor;
            uniform sampler2D _NormalMap; uniform float4 _NormalMap_ST;
            uniform float _Specular;
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
                float4 node_7021 = _Time + _TimeEditor;
                float node_6155 = pow((abs((frac((o.uv0+node_7021.g*float2(0.25,0)).r)-0.5))*2.0),_BulgeShape); // Panning gradient
                float node_4987 = node_6155;
                v.vertex.xyz += (node_4987*_BulgeScale*v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _NormalMap_var = UnpackNormal(tex2D(_NormalMap,TRANSFORM_TEX(i.uv0, _NormalMap)));
                float4 node_7021 = _Time + _TimeEditor;
                float node_6155 = pow((abs((frac((i.uv0+node_7021.g*float2(0.25,0)).r)-0.5))*2.0),_BulgeShape); // Panning gradient
                float3 normalLocal = normalize(lerp(_NormalMap_var.rgb,float3(0,0,1),node_6155));
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float3 specularColor = float3(_Specular,_Specular,_Specular);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = dot( normalDirection, lightDirection );
                float3 w = float3(node_6155,node_6155,node_6155)*0.5; // Light wrapping
                float3 NdotLWrap = NdotL * ( 1.0 - w );
                float3 forwardLight = max(float3(0.0,0.0,0.0), NdotLWrap + w );
                float3 backLight = max(float3(0.0,0.0,0.0), -NdotLWrap + w ) * float3(node_6155,node_6155,node_6155);
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = (forwardLight+backLight) * attenColor;
                float node_2100 = 0.1;
                float3 diffuseColor = lerp(_DiffuseColor.rgb,float3(node_2100,node_2100,node_2100),node_6155);
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
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
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float _BulgeScale;
            uniform float _BulgeShape;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_6047 = _Time + _TimeEditor;
                float node_6155 = pow((abs((frac((o.uv0+node_6047.g*float2(0.25,0)).r)-0.5))*2.0),_BulgeShape); // Panning gradient
                float node_4987 = node_6155;
                v.vertex.xyz += (node_4987*_BulgeScale*v.normal);
                o.pos = UnityObjectToClipPos(v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
