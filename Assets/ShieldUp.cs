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
        audioSourceLoop = gameObject.GetComponent<AudioSource>();
        audioSourceLoop.loop = true;
        
    }

    private void Start()
    {
        myRidgidBody = GetComponent<Rigidbody>();
        audioSourceLoop.clip = SoundFX.ShieldActive;
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
            audioSource.PlayDelayed(1.15f);
        }
        if (Shieldup && !isGrounded)
        {
            Shieldup = false;
            ShieldBall.SetActive(false);
            audioSource.Stop();
            audioSource.PlayOneShot(SoundFX.ShieldDown);
        }
        
    }
}