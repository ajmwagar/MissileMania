using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ShieldUp : MonoBehaviour {


    private bool isGrounded;
    [SerializeField]
    public Transform[] GroundPoints;
    [SerializeField]
    public float GroundRadius;
    [SerializeField]
    private LayerMask whatIsGround;
    public Rigidbody myRidgidBody;
    public bool Shieldup;
    public GameObject ShieldBall;

    public AudioSource audioSource;
    public AudioSource audioSourceLoop;

    private void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();    
    }

    private void Start()
    {
        myRidgidBody = GetComponent<Rigidbody>();
    }
   
    private void IsGrounded()
    {   
        if (gameObject.transform.position.y >= 0)
        {
            foreach (Transform point in GroundPoints)
            {
                Collider[] colliders = Physics.OverlapSphere(point.position, GroundRadius, whatIsGround);
                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        isGrounded = true;
                        return;
                    }
                }
            }
        }
        isGrounded = false;
    }
    public void FixedUpdate()
    {
        IsGrounded();
    }

    public void Update()
    {
        if (isGrounded && !Shieldup)
        {
            Shieldup = true;
            ShieldBall.SetActive(true);
            audioSource.PlayOneShot(SoundFX.ShieldUp);
            audioSourceLoop.clip = SoundFX.ShieldActive;
            audioSourceLoop.loop = true;
            audioSourceLoop.PlayDelayed(1.15f);

        }
        if (Shieldup && !isGrounded)
        {
            Shieldup = false;
            ShieldBall.SetActive(false);
            audioSourceLoop.Stop();
            audioSource.PlayOneShot(SoundFX.ShieldDown);
        }
        
    }
}