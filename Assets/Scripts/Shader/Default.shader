Shader "SC/Default"
{  
     Properties
    {
        _MainTex ("Texture", 2D) = "white" {} // 主贴图
        _Transparency ("Transparency", Range(0,1)) = 0.5 // 透明度
    }

    SubShader
    {
        Pass
        {
            Cull Off
            ZWrite On
            ZTest LEqual
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #include "Lighting.cginc"

            // 着色器属性
            sampler2D _MainTex; // 主纹理
            float _Transparency; // 透明度
            float4 _MainTex_ST; // 用于纹理平铺和偏移

            // 顶点输出结构体
            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 worldNormal : NORMAL;
            };

            // 顶点着色器
            v2f vert(appdata_full v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
                o.worldNormal = UnityObjectToWorldNormal(v.normal);
                return o;
            }

            // 片段着色器
            float4 frag(v2f v) : SV_Target
            {
                // 采样主纹理颜色
                float4 texColor = tex2D(_MainTex, v.uv);

                // 计算光照
                float3 worldNormal = normalize(v.worldNormal);
                float3 worldLight = normalize(_WorldSpaceLightPos0.xyz);
                float diff = max(dot(worldNormal, worldLight), 0.0);

                // 使用透明度调整亮度
                float brightness = lerp(0.2, 1.0, _Transparency); // 控制亮度范围
                float4 color = texColor * diff * brightness;

                // 返回最终颜色
                return float4(color.rgb, texColor.a); // 保持原始透明度
            }

            ENDCG
        }
    }

    Fallback "Diffuse"
}  
