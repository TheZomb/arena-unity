using System;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.BuiltinInterfaces;
using RosMessageTypes.Rosgraph;
using Unity.Robotics.Core;

public class ROSClockPublisher : MonoBehaviour
{
    [SerializeField]
    Clock.ClockMode m_ClockMode;
    [SerializeField, HideInInspector]
    Clock.ClockMode m_LastSetClockMode;
    [SerializeField]
    double m_PublishRateHz = 100f;
    double m_LastPublishTimeSeconds;
    ROSConnection m_ROS;
    double PublishPeriodSeconds => 1.0f / m_PublishRateHz;
    bool ShouldPublishMessage => Clock.FrameStartTimeInSeconds - PublishPeriodSeconds > m_LastPublishTimeSeconds;

    CommandLineParser commandLineArgs;
    string topicName;

    void OnValidate()
    {
        var clocks = FindObjectsOfType<ROSClockPublisher>();
        if (clocks.Length > 1)
        {
            Debug.LogWarning("Found too many clock publishers in the scene, there should only be one!");
        }

        if (Application.isPlaying && m_LastSetClockMode != m_ClockMode)
        {
            Debug.LogWarning("Can't change ClockMode during simulation! Setting it back...");
            m_ClockMode = m_LastSetClockMode;
        }
        
        SetClockMode(m_ClockMode);
    }

    void SetClockMode(Clock.ClockMode mode)
    {
        Clock.Mode = mode;
        m_LastSetClockMode = mode;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Init command line args
        commandLineArgs = gameObject.AddComponent<CommandLineParser>();
        commandLineArgs.Initialize();

        topicName = commandLineArgs.sim_namespace != null ? "/" + commandLineArgs.sim_namespace + "/clock" : "/clock";

        SetClockMode(m_ClockMode);
        // Register topic
        m_ROS = FindObjectOfType<ROSConnection>();
        m_ROS.RegisterPublisher<ClockMsg>(topicName);
    }

    void PublishMessage()
    {
        var publishTime = Clock.time;
        var clockMsg = new TimeMsg
        {
            sec = (uint)publishTime,
            nanosec = (uint)((publishTime - Math.Floor(publishTime)) * Clock.k_NanoSecondsInSeconds)
        };
        m_LastPublishTimeSeconds = publishTime;
        m_ROS.Publish(topicName, clockMsg);
    }

    void Update()
    {
        if (ShouldPublishMessage)
        {
            PublishMessage();
        }
    }
}
