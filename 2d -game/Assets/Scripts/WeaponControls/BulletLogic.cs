using UnityEngine;
using System.Collections;

public class BulletLogic : MonoBehaviour
{

    public Rigidbody2D rb;
    public float bulletSpeed = 3;
    private AudioSource shotSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        shotSound = GetComponent<AudioSource>();
        shotSound.Play();
    }
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {        
        rb.AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);        
        StartCoroutine("WaitAndPrint");
        
    }

    IEnumerator WaitAndPrint()
    {
        // suspend execution for 5 seconds
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
