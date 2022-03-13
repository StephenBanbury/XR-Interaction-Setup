using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Hand : MonoBehaviour
{
    [SerializeField] private float speed;

    Animator _animator;
    SkinnedMeshRenderer _mesh;
    private float _gripTarget;
    private float _triggerTarget;
    private float _gripCurrent;
    private float _triggerCurrent;
    private const string AnimatorGripParam = "Grip";
    private const string AnimatorTriggerParam = "Trigger";
    private static readonly int Grip = Animator.StringToHash(AnimatorGripParam);
    private static readonly int Trigger = Animator.StringToHash(AnimatorTriggerParam);

    void Start()
    {
        _animator = GetComponent<Animator>();
        _mesh = GetComponentInChildren<SkinnedMeshRenderer>();
    }
    
    void Update()
    {
        AnimateHand();
    }

    internal void SetGrip(float v)
    {
        _gripTarget = v;
    }

    internal void SetTrigger(float v)
    {
        _triggerTarget = v;
    }

    void AnimateHand()
    {
        if (_gripCurrent != _gripTarget)
        {
            Debug.Log($"AnimateHand ({_animator.name}) - gripCurrent:{_gripCurrent}, gripTarget:{_gripTarget}");
            _gripCurrent = Mathf.MoveTowards(_gripCurrent, _gripTarget, Time.deltaTime * speed);
            _animator.SetFloat(AnimatorGripParam, _gripCurrent);
        }
        if (_triggerCurrent != _triggerTarget)
        {
            Debug.Log($"AnimateHand ({_animator.name}) - gripCurrent:{_triggerCurrent}, gripTarget:{_triggerTarget}");
            _triggerCurrent = Mathf.MoveTowards(_triggerCurrent, _triggerTarget, Time.deltaTime * speed);
            _animator.SetFloat(AnimatorTriggerParam, _triggerCurrent);
        }
    }

    public void ToggleVisibility()
    {
        _mesh.enabled = !_mesh.enabled;
    }
}
