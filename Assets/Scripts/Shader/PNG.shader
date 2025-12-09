Shader "SC/PNG"
{
Properties
    {
        _MainTex ("Texture", 2D) = "white" {} // 主贴图
    }
    SubShader
    {
        Cull Off
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        LOD 200

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha // 启用透明度混合
            ZWrite Off // 关闭深度写入，确保透明物体正确渲染

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // 获取贴图像素颜色（包括透明度）
                fixed4 texColor = tex2D(_MainTex, i.uv);

                // 直接返回贴图像素颜色，保留透明度
                return texColor;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}