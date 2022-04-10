Shader "Custom/Shape Surface"
{
    Properties
    {
        _Color ("Color", Color) = (1, 1, 1)
        
    }
    SubShader
    {
        Lighting Off
        
        CGPROGRAM
       
        #pragma surface ConfigureSurface Standard fullforwardshadows
        #pragma target 3.0
        
        float _Smoothness;
        float3 _Color;
 
        struct Input
        {
            float3 worldPos;
        };
        
        float InOutQuad(float x, float scale)
        {
            return x < 0.5 * scale ? 2 * x * x / scale : - 2 * x * x / scale + 4 * x - scale;
        }
        
        void ConfigureSurface(Input input, inout SurfaceOutputStandard surface)
        {
            surface.Albedo = _Color;
            surface.Albedo -= InOutQuad(log(input.worldPos.y / 10), 0.75) * 0.0075;
            surface.Smoothness = 0;
        }
        
        ENDCG
    }
    
    Fallback "Diffuse"
}
