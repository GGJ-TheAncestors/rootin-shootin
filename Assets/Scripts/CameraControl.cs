﻿using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float m_DampTime = 0.2f;                 
    public float m_ScreenEdgeBuffer = 4f;           
    public float m_MinSize = 6.5f;                  
    /*[HideInInspector]*/ public Transform[] m_Targets; 
    public ReferenceList controllers;

    public Vector3 offset;
    private Camera m_Camera;                        
    private Vector3 m_ZoomSpeed;                      
    private Vector3 m_MoveVelocity;                 
    private Vector3 m_DesiredPosition;              


    private void Awake()
    {
        m_Camera = GetComponentInChildren<Camera>();
    }


    private void FixedUpdate()
    {
        Move();
        Zoom();
    }


    private void Move()
    {
        FindAveragePosition();

        transform.position = Vector3.SmoothDamp(transform.position, m_DesiredPosition, ref m_MoveVelocity, m_DampTime);
    }


    private void FindAveragePosition()
    {
        Vector3 averagePos = new Vector3();
        int numTargets = 0;

        List<Transform> m_Targets = new List<Transform>(this.m_Targets);
        for( int i = 0; i < controllers.objects.Count; ++i )
        {
            if( controllers.objects[i].TryGetComponent<HandleInput>( out HandleInput input ) )
            {
                if( input.pawn != null )
                    m_Targets.Add( input.pawn.transform );
            }
        } 

        for (int i = 0; i < m_Targets.Count; i++)
        {
            if (!m_Targets[i].gameObject.activeSelf)
                continue;

            averagePos += m_Targets[i].position;
            numTargets++;
        }

        if (numTargets > 0)
            averagePos /= numTargets;

        m_DesiredPosition = averagePos + offset;
    }


    private void Zoom()
    {
        float requiredSize = FindRequiredSize().x;        
        float distance = requiredSize * 0.5f / Mathf.Tan(m_Camera.fieldOfView * 0.5f * Mathf.Deg2Rad);
        offset = Vector3.SmoothDamp( offset, offset.normalized * distance, ref m_ZoomSpeed, m_DampTime );
    }


    private Vector2 FindRequiredSize()
    {
        Vector3 desiredLocalPos = transform.InverseTransformPoint(m_DesiredPosition);

        float size = 0f;
        Bounds sizeBounds = new Bounds(Vector3.zero, Vector2.one * m_MinSize );

        List<Transform> m_Targets = new List<Transform>(this.m_Targets);
        for( int i = 0; i < controllers.objects.Count; ++i )
        {
            if( controllers.objects[i].TryGetComponent<HandleInput>( out HandleInput input ) )
            {
                if( input.pawn != null )
                    m_Targets.Add( input.pawn.transform );
            }
        } 

        for (int i = 0; i < m_Targets.Count; i++)
        {
            if (!m_Targets[i].gameObject.activeSelf)
                continue;

            Vector3 targetLocalPos = transform.InverseTransformPoint(m_Targets[i].position);

            Vector3 desiredPosToTarget = targetLocalPos - desiredLocalPos;

            sizeBounds.Encapsulate( desiredPosToTarget );

            size = Mathf.Max (size, Mathf.Abs (desiredPosToTarget.y));
            size = Mathf.Max (size, Mathf.Abs (desiredPosToTarget.x) / m_Camera.aspect);
        }
        
        sizeBounds.Expand( m_ScreenEdgeBuffer );
        return sizeBounds.extents * 2;
    }


    public void SetStartPositionAndSize()
    {
        FindAveragePosition();

        transform.position = m_DesiredPosition;

        m_Camera.orthographicSize = FindRequiredSize().x;
    }
}