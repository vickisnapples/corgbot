Shader "Somian/Unlit/Transparent" {

 

Properties {

    _Color ("Main Color (A=Opacity)", Color) = (1,1,1,.3)

    _MainTex ("Base (A=Opacity)", 2D) = ""

}

 

Category {

    Tags {"Queue"="Transparent" "IgnoreProjector"="True"}

    ZWrite Off

    Blend SrcAlpha OneMinusSrcAlpha 

 

    SubShader {Pass {

        // GLSL combinations: 1
Program "vp" {
SubProgram "opengl " {
Keywords { }
"!!GLSL

#ifndef SHADER_API_OPENGL
    #define SHADER_API_OPENGL 1
#endif
#ifndef SHADER_API_DESKTOP
    #define SHADER_API_DESKTOP 1
#endif
#define highp
#define mediump
#define lowp
#line 28


        varying mediump vec2 uv;

        

        #ifdef VERTEX

        uniform mediump vec4 _MainTex_ST;

        void main() {

            gl_Position = gl_ModelViewProjectionMatrix * gl_Vertex;

            uv = gl_MultiTexCoord0.xy * _MainTex_ST.xy + _MainTex_ST.zw;

        }

        #endif

        

        #ifdef FRAGMENT

        uniform lowp sampler2D _MainTex;

        uniform lowp vec4 _Color;

        void main() {

            gl_FragColor = texture2D(_MainTex, uv) * _Color;

        }

        #endif      

        "
}
SubProgram "gles " {
Keywords { }
"!!GLES

#ifndef SHADER_API_GLES
    #define SHADER_API_GLES 1
#endif
#ifndef SHADER_API_MOBILE
    #define SHADER_API_MOBILE 1
#endif
#line 28


        varying mediump vec2 uv;

        

        
        

             

        
#ifdef VERTEX
#define gl_ModelViewProjectionMatrix glstate_matrix_mvp
uniform highp mat4 glstate_matrix_mvp;
#define gl_Vertex _glesVertex
attribute vec4 _glesVertex;
#define gl_MultiTexCoord0 _glesMultiTexCoord0
attribute vec4 _glesMultiTexCoord0;


        uniform mediump vec4 _MainTex_ST;

        void main() {

            gl_Position = gl_ModelViewProjectionMatrix * gl_Vertex;

            uv = gl_MultiTexCoord0.xy * _MainTex_ST.xy + _MainTex_ST.zw;

        }

        
#endif
#ifdef FRAGMENT


        uniform lowp sampler2D _MainTex;

        uniform lowp vec4 _Color;

        void main() {

            gl_FragColor = texture2D(_MainTex, uv) * _Color;

        }

        
#endif"
}
SubProgram "glesdesktop " {
Keywords { }
"!!GLES

#ifndef SHADER_API_GLES
    #define SHADER_API_GLES 1
#endif
#ifndef SHADER_API_DESKTOP
    #define SHADER_API_DESKTOP 1
#endif
#line 28


        varying mediump vec2 uv;

        

        
        

             

        
#ifdef VERTEX
#define gl_ModelViewProjectionMatrix glstate_matrix_mvp
uniform highp mat4 glstate_matrix_mvp;
#define gl_Vertex _glesVertex
attribute vec4 _glesVertex;
#define gl_MultiTexCoord0 _glesMultiTexCoord0
attribute vec4 _glesMultiTexCoord0;


        uniform mediump vec4 _MainTex_ST;

        void main() {

            gl_Position = gl_ModelViewProjectionMatrix * gl_Vertex;

            uv = gl_MultiTexCoord0.xy * _MainTex_ST.xy + _MainTex_ST.zw;

        }

        
#endif
#ifdef FRAGMENT


        uniform lowp sampler2D _MainTex;

        uniform lowp vec4 _Color;

        void main() {

            gl_FragColor = texture2D(_MainTex, uv) * _Color;

        }

        
#endif"
}
}

#LINE 63


    }}

    

    SubShader {Pass {

        SetTexture[_MainTex] {Combine texture * constant ConstantColor[_Color]}

    }}

}

 

}