using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bullet Trail Config", menuName = "Bullet Trail Config")]
public class bulletScriptableObject : ScriptableObject
{
    public AnimationCurve WidthCurve;
    public float Time = 0.5f;
    public float MinVertexDistance = 0.1f;
    public Gradient ColorGradient;
    public Material Material;
    public int CornerVertices;
    public int EndCapVertices;

    public void SetupTrail(TrailRenderer TrailRenderer)
    {
        TrailRenderer.widthCurve = WidthCurve;
        TrailRenderer.time = Time;
        TrailRenderer.minVertexDistance = MinVertexDistance;
        TrailRenderer.colorGradient = ColorGradient;
        TrailRenderer.sharedMaterial = Material;
        TrailRenderer.numCornerVertices = CornerVertices;
        TrailRenderer.numCapVertices = EndCapVertices;
    }
}
