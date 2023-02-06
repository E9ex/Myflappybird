using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
   public Sprite[] sprites;
   private int spriteindex;
   private SpriteRenderer spriteRenderer;
   private Vector3 direction;
   public float gravity = -9.8f;
   public float strength = 5f;


   private void Awake()
   {
      spriteRenderer = GetComponent<SpriteRenderer>();
      
      
   }

   private void Start()
   {
      InvokeRepeating(nameof(AnimateSprite),0.15f,0.15f);
   }

   private void OnEnable()
   {
      Vector3 position = transform.position;
      position.y = 0f;
      transform.position = position;
      direction = Vector3.zero;
   }

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.Space))
      {
         direction = Vector3.up*strength;
         
      }

      /*if (Input.touchCount>0)//mobile.
      {
         Touch touch = Input.GetTouch(0);
         if(touch.phase==TouchPhase.Began)
            direction = Vector3.up*strength;
      }*/

      direction.y += gravity * Time.deltaTime;
      transform.position += direction*Time.deltaTime;
   }

   private void AnimateSprite()
   {
      spriteindex++;
      if (spriteindex>=sprites.Length)
      {
         spriteindex = 0;
      }

      spriteRenderer.sprite = sprites[spriteindex];//for update.

   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if(other.gameObject.tag=="Obstacle")
         FindObjectOfType<gamemanager>().gameover();
      if (other.gameObject.tag=="scoring")
         FindObjectOfType<gamemanager>().Increase();
         
      
   }
}
