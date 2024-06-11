Shader "Custom/ExampleShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
        _Speed ("Speed", Float) = 1.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Lambert
        #pragma vertex vert
        #include "UnityCG.cignc"

        sampler2D _MainTex;
        fixed4 _Color;
        float _Speed;

        struct Input
        {
            float2 uv_MainTex;
            float4 textcoord: TEXTCOORD;
        };
        UNITY_INSTANCING_BUFFER_END(props)

        void surf (Input IN, inout SurfaceOutput o)
        {
            // Tạo một hiệu ứng wave dựa trên thời gian và tọa độ UV
            float wave = sin(_Time.y * _Speed + IN.uv_MainTex.x * 10.0);
            
            // Lấy màu từ texture và thêm hiệu ứng wave vào đó
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex + wave * 0.1);

            // Kết hợp màu từ texture và màu từ thuộc tính Color
            c *= _Color;

            // Gán kết quả cho đầu ra
            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
