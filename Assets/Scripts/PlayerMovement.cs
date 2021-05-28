﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public enum PlayerModes
    {
        MovementMode,
        InspectMode
    }

    public Vector3 targetPos;
    public bool isFacingRight = false;
    private int targetPosOnTheRight;
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

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        currentSprite = this.gameObject.GetComponent<SpriteRenderer>();
        _currentMode = PlayerModes.InspectMode;
    }


    private void Update()
    {
        StartCoroutine(DEBUG_ToggleMode());
        if (_currentMode == PlayerModes.MovementMode)
            CanMove();
    }

    private void FixedUpdate()
    {
        MoveToTargetPosition();
    }

    private IEnumerator DEBUG_ToggleMode()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            if (_currentMode != PlayerModes.MovementMode) _currentMode = PlayerModes.MovementMode;

        if (Input.GetKeyDown(KeyCode.Alpha2))
            if (_currentMode != PlayerModes.InspectMode) _currentMode = PlayerModes.InspectMode;

        yield return null;
    }

    #region MovementFunctions

    private void CanMove()
    {
        SetTargetPosition();

        if (targetPosOnTheRight == 1 && !isFacingRight)
            FlipSprite();
        else if (targetPosOnTheRight == -1 && isFacingRight)
            FlipSprite();

        if (Input.GetKeyDown(KeyCode.Space))
            rb.velocity = Vector2.up * 100 * jumpAmount;

    }

    private void SetTargetPosition()
    {
        Vector3 _mousePos = Input.mousePosition;
        targetPos = Camera.main.ScreenToWorldPoint(new Vector3(_mousePos.x, _mousePos.y, 1));

        if (targetPos.x < this.transform.position.x)
            targetPosOnTheRight = -1;
        else if (targetPos.x > this.transform.position.x)
            targetPosOnTheRight = 1;
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
        if (rb.velocity.y != 0)
        {
            currentSprite.sprite = jump;
        }
        if (Mathf.Abs(this.transform.position.x - targetPos.x) > 20)
        {
            rb.velocity = new Vector2(targetPosOnTheRight * moveSpeed * 1000 * Time.fixedDeltaTime, rb.velocity.y);
            currentSprite.sprite = run;
        }
        else
        {
            this.transform.position = targetPos = new Vector2(targetPos.x, transform.position.y);
            currentSprite.sprite = idle;
        }
    }

    #endregion

}
