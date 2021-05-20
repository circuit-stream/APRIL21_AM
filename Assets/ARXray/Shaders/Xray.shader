Shader "Custom/XRay"
{
    SubShader
    {
      Tags { "Queue" = "Transparent+1" }    // renders after all transparent objects (queue = 3001)

      Pass { Blend Zero One }    // makes this object transparent
    }
}