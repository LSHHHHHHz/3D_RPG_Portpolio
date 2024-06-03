using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransformFactory : MonoBehaviour
{
    public static TransformFactory instance;
    public Transform buyPopupTransform;
    public Transform shopPopupTransform;
    private void Awake()
    {
        instance = this;
    }
}
