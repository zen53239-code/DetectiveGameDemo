Shader "SC/Light"
{
    Properties
     {
     //内部使用的名称  //声明的数据类型
    _Color("Color",Color)=(1,1,1,1)
         //外部使用的名称   //赋值（1,1,1,1）
     }
SubShader
    {
        pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
 
            #include"UnityCG.cginc"
 
            float4 _Color ;
 
            appdata_base vert(appdata_base v)
            {
            v.vertex =UnityObjectToClipPos(v.vertex);
            return v;
            }
 
            float4 frag():SV_TARGET
            {
            return _Color;
            }
            ENDCG
        }
    }
}
