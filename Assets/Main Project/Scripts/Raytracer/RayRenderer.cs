﻿using UnityEngine;

[ExecuteInEditMode]
public class RayRenderer : MonoBehaviour {
    public struct SphereData {
        public const int SIZE = 44;

        public Vector3 position;
        public float radius;
        public Vector3 albedo;
        public Vector3 specular;
        public float smoothness;
    }

    public enum Type { Sphere }; // Support more types in the future?

    public Transform cachedTrans;
    public Type type = Type.Sphere;
    public float radius = 0.5f;
    public Color albedo = Color.white;
    public Color specularity = Color.gray;
    public float smoothness = 0.5f;

    private int rendererID;

    private void Awake() {
        rendererID = -1;
    }

    private void OnEnable() {
        if(RayTracer.instance != null)
            rendererID = RayTracer.instance.AddRenderer(this);
    }

    private void OnDisable() {
        if(rendererID > -1 && RayTracer.instance != null)
            RayTracer.instance.RemoveRenderer(rendererID);
    }

    private void LateUpdate() {
        if(cachedTrans.hasChanged) {
            RayTracer.instance.MarkRendererDirty();
            cachedTrans.hasChanged = false;
        }
    }
}