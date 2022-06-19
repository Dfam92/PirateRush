using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;



public class PlayerControl : MonoBehaviour
{

    [SerializeField] Rigidbody playerRb;
    [SerializeField] float forwardSpeed;
    [SerializeField] float touchSpeed;
    [SerializeField] GameObject cameraPoint;
    [SerializeField] SfxManager sfx;
    
    [SerializeField] float offSetAfterWaterFall;
    [SerializeField] float initialDifficulty;

    private Touch touch;
    private bool isFalling;
    private float xMaxPosition = 2;
    private Vector2 initialTouchPos;
    private Vector3 initialPosition;

  
    private void Awake()
    {
        initialPosition = transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveHorizontally();
    }

    private void FixedUpdate()
    {
        
        PlayerMove();

    }

    private void PlayerMove()
    {
        if(!isFalling)
        {
            //playerRb.AddForce(Vector3.forward * speed*Time.deltaTime);
            var position = transform.position;
            position.z = ProcessForwardMovement();
            transform.position = position;
        }
        else
        {
            //playerRb.AddForce(Vector3.down * speed * 2*Time.deltaTime);
        }
    }

    private void PlayerMoveHorizontally()
    {
        
        if(Input.touchCount > 0 && !isFalling)
        {
            touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                initialTouchPos = touch.position;
            }

            if(touch.phase == TouchPhase.Moved)
            {
                var direction = touch.position - initialTouchPos;
                if (direction.x > 0 && transform.position.x == initialPosition.x)
                {
                    transform.DOMoveX(xMaxPosition, touchSpeed*Time.deltaTime);
                }
                else if ((direction.x < 0 && transform.position.x > initialPosition.x))
                {
                    transform.DOMoveX(initialPosition.x, touchSpeed * Time.deltaTime);
                }
                else if (direction.x < 0 && transform.position.x == initialPosition.x)
                {
                    transform.DOMoveX(-xMaxPosition, touchSpeed * Time.deltaTime);
                }
                else if (direction.x > 0 && transform.position.x < initialPosition.x)
                {
                    transform.DOMoveX(initialPosition.x, touchSpeed * Time.deltaTime);
                }
            }
        }
    }

    private float ProcessForwardMovement()
    {
        return transform.position.z + forwardSpeed * Time.deltaTime * initialDifficulty;
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Portal"))
        {
          
        }

        if(other.gameObject.CompareTag("WaterFall"))
        {
            var fallRotation = new Vector3(90, transform.rotation.y, transform.rotation.z);
            playerRb.DORotate(fallRotation, 3);
            isFalling = true;
            cameraPoint.transform.DOLocalMoveZ(offSetAfterWaterFall, 4);
        }
    }


    // Control Animations
    /*private IEnumerator SetFalseAnim(Animator animator, string animation, float time)
    {
        yield return new WaitForSeconds(time);
        animator.SetBool(animation, false);
    }

    private IEnumerator SetTrueAnim(Animator animator, string animation, float time)
    {
        yield return new WaitForSeconds(time);
        animator.SetBool(animation, true);
    }*/

   

    public void RockCollision()
    {
        
    }
    
    public void CoinCollision()
    {
        sfx.CoinCollectSfx();
    }

}
