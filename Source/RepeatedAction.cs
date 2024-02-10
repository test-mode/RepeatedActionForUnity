using System;
using UnityEngine;

public sealed class RepeatedAction : MonoBehaviour
{
    public event Action Elapsed;

    [SerializeField, Tooltip("Repeat rate in seconds")] private float _repeatEvery;
    [SerializeField, Tooltip("Invoke when elapsed")] private bool _enabled = true;
    private float timer;

    /// <summary>
    /// Changes repeat rate of the action in seconds based on given float value. Can be changed any time during gameplay.
    /// </summary>
    public float RepeatEvery
    {
        get { return _repeatEvery; }
        set { _repeatEvery = value; }
    }

    /// <summary>
    /// Enables/disables invoke of Elapsed action based on the given true/false value.
    /// </summary>
    public bool SetEnabled
    {
        get { return _enabled; }
        set { _enabled = value; }
    }

    private void Update()
    {
        if (_enabled)
        {
            timer += Time.deltaTime;

            if (timer > _repeatEvery)
            {
                timer = 0;
                Elapsed?.Invoke();
            }
        }
    }
}
