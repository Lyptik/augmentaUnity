﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AugmentaCameraControllable : Controllable {

    [Header("Camera settings")]
    [Range(0.01f, 500f)]
    [OSCProperty]
    public float CamDistToAugmenta;

    [Header("Augmenta settings")]
    [OSCProperty]
    public float Zoom;

    private AugmentaCamera MyAugmentaCamera;

    public override void Awake()
    {
        MyAugmentaCamera = FindObjectOfType<AugmentaCamera>();
        if (MyAugmentaCamera == null)
            Debug.LogWarning("Couldn't find a " + this.GetType().Name + " script");
        TargetScript = MyAugmentaCamera;
        base.Awake();
    }

    public override void DataLoaded()
    {
        base.DataLoaded();
        MyAugmentaCamera.ForceCoreCameraUpdate();
    }

    public override void OnUiValueChanged(string name)
    {
        base.OnUiValueChanged(name);
        MyAugmentaCamera.ForceCoreCameraUpdate();
    }
}
