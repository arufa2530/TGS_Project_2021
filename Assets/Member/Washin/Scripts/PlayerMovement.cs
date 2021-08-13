﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public enum PlayerModes
    {
        MovementMode,
        InspectMode,
        IdleMode
    }

    public static PlayerMovement instance;

    public Vector3 targetPos;
    public bool isFacingRight = false;
    [SerializeField] bool isJumping = false;
    private int targetPosOnTheRight;
    private float offsetMouseDetect = 30f;
    [SerializeField]
    private float moveSpeed = 0;
    Rigidbody2D rb;
    public Sprite idle;
    public Sprite run;
    public Sprite jump;
    [SerializeField]
    public float jumpAmount;
    private SpriteRenderer currentSprite = null;
    [SerializeField]
    private PlayerModes _currentMode;
    [SerializeField]
    Animator _animator;
    Animation[] states;

    [SerializeField] DisplayCurrentMode currentModeUI;

    float distance;

    [SerializeField] float jumpCooldown;
    [SerializeField] float jumpCurrentTime;


    private void Awake()
    {
        if (PlayerReferences.playerMovement != null)
        {
            Destroy(transform.parent.gameObject);
            return;
        }
        if (instance == null) instance = this;
        rb = this.GetComponent<Rigidbody2D>();
        currentSprite = this.gameObject.GetComponent<SpriteRenderer>();
        _currentMode = PlayerModes.InspectMode;
        _animator = GetComponent<Animator>();
        targetPos = this.transform.position;
        jumpCurrentTime = jumpCooldown;
        PlayerReferences.playerMovement = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetModeToIdle(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SetModeToIdle(false);
        }

        if (_currentMode == PlayerModes.IdleMode) return;

        TogglePlayerMode();

        if (_currentMode == PlayerModes.MovementMode)
            CanMove();

        //CheckTargetPosIsGreaterThanMinDistance();
    }

    private void FixedUpdate()
    {
        MoveToTargetPosition();
    }

    private void CheckTargetPosIsGreaterThanMinDistance()
    {
        distance = Vector3.Distance(this.transform.position, targetPos);
        Debug.Log(distance);
    }

    public void TogglePlayerMode()
    {
        if (Input.GetMouseButtonDown(2))
            if (_currentMode == PlayerModes.InspectMode)
            {
                //Debug.Log("ModeChanged");
                ChangePlayerMode(PlayerModes.MovementMode);
            }
            else if (_currentMode == PlayerModes.MovementMode)
            {
                ChangePlayerMode(PlayerModes.InspectMode);
            }
    }

    public void SetModeToIdle(bool shouldIdle)
    {
        if (shouldIdle)
        {
            ChangePlayerMode(PlayerModes.IdleMode);
        }
        else
        {
            ChangePlayerMode(PlayerModes.InspectMode);
        }
    }

    public void ChangePlayerMode(PlayerModes targetPlayerMode)
    {
        _currentMode = targetPlayerMode;
        switch (targetPlayerMode)
        {
            case PlayerModes.MovementMode:
                currentModeUI.ChangeMode(1);
                break;
            case PlayerModes.InspectMode:
                currentModeUI.ChangeMode(2);
                targetPos = this.transform.position;
                break;
            case PlayerModes.IdleMode:
                currentModeUI.ChangeMode(3);
                break;
            default:
                Debug.LogError("PlayerModeErrorCatchSwitch");
                break;
        }
    }

    #region MovementFunctions

    private void CanMove()
    {
        SetTargetPosition();

        if (jumpCurrentTime < jumpCooldown)
        {
            jumpCurrentTime += Time.deltaTime / jumpCooldown;
        }

        if (Input.GetMouseButtonDown(1))
        {
            //if (jumpCurrentTime >= jumpCooldown)
            if (!isJumping)
            {
                rb.velocity = Vector2.up * 100 * jumpAmount;
                jumpCurrentTime = 0;
                isJumping = true;
            }
        }
    }

    private void SetTargetPosition()
    {
        Vector3 _mousePos = Input.mousePosition;
        targetPos = Camera.main.ScreenToWorldPoint(new Vector3(_mousePos.x, _mousePos.y, 1));

        if (targetPos.x - offsetMouseDetect < this.transform.position.x)
        {
            targetPosOnTheRight = -1;
            if (isFacingRight)
                FlipSprite();

        }
        else if (targetPos.x + offsetMouseDetect > this.transform.position.x)
        {
            targetPosOnTheRight = 1;
            if (!isFacingRight)
                FlipSprite();
        }
    }

    private void FlipSprite()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = this.transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void MoveToTargetPosition()
    {
        if (rb.velocity.y != 0 && isJumping == false)
        {
            rb.velocity = new Vector2(targetPosOnTheRight * moveSpeed * 1000 * Time.fixedDeltaTime, rb.velocity.y);
            _animator.Play("JumpB");
            isJumping = true;
        }
        else if (Mathf.Abs(this.transform.position.x - targetPos.x) > offsetMouseDetect)
        {
            rb.velocity = new Vector2(targetPosOnTheRight * moveSpeed * 1000 * Time.fixedDeltaTime, rb.velocity.y);
            _animator.Play("DashB");
        }
        else
        {
            Vector3 tempVec = rb.velocity;
            rb.velocity = new Vector2(0, rb.velocity.y);
            _animator.Play("WaitB");
        }
    }

    #endregion

    public void SetPlayerPosition(Vector3 playerNewPosition)
    {
        this.transform.position = playerNewPosition;
        targetPos = this.transform.position;
    }

    public void SetIsPlayerJumping(bool isPlayerJumping)
    {
        isJumping = isPlayerJumping;
    }

    public PlayerModes GetCurrentPlayerMode()
    {
        return _currentMode;
    }
}
