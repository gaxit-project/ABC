Shader "Custom/CrackOverlay"
{
    Properties
    {
        _MainTex ("Base Texture", 2D) = "white" {}
        _CrackTex ("Crack Texture (RGBA)", 2D) = "white" {}
        _CrackAmount ("Crack Amount", Range(0,1)) = 0
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows

        sampler2D _MainTex;
        sampler2D _CrackTex;
        float _CrackAmount;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_CrackTex;
        };

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 baseCol = tex2D(_MainTex, IN.uv_MainTex);
            fixed4 crackCol = tex2D(_CrackTex, IN.uv_CrackTex);

            // Ç–Ç—äÑÇÍÇèôÅXÇ…çáê¨
            fixed3 finalColor = lerp(
                baseCol.rgb,
                baseCol.rgb * crackCol.rgb,
                crackCol.a * _CrackAmount
            );

            o.Albedo = finalColor;
            o.Alpha = 1;
        }
        ENDCG
    }
    FallBack "Standard"
}
