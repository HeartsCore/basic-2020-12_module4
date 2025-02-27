﻿using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float rotationSpeed = 60.0f;

    NavMeshAgent agent;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
    }

    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        Vector3 side = transform.right * horizontal * movementSpeed * Time.deltaTime;

        var vertical = Input.GetAxis("Vertical");
        Vector3 forward = transform.forward * vertical * movementSpeed * Time.deltaTime;
        agent.Move(forward + side);
        agent.SetDestination(transform.position + forward + side);

        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
    }
}
