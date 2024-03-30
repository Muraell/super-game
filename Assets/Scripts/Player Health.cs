using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float value = 100;
    public RectTransform valueRectTransform;
    public GameObject gameplayUI;
    public GameObject gameOverScreen;
    public Animator animator;

    private float _maxValue;
    private void Start()
    {
        _maxValue = value;
        DrawHealthBar();
    }
    public void DealDamage(float damage)
    {
        value -= damage;
        if (value <= 0)
        {
            PlayerIsDead();
        }
        DrawHealthBar();
        
    }
    // Update is called once per frame
    private void DrawHealthBar()
    {
        valueRectTransform.anchorMax = new Vector2(value / _maxValue, 1);
    }
    
    private void PlayerIsDead()
    {
        gameplayUI.SetActive(false);
        gameOverScreen.SetActive(true);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<FireBallCaster>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
        animator.SetTrigger("death");
    }
}
