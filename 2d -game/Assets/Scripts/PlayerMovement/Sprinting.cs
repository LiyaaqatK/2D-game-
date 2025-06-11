using UnityEngine;

public class Sprinting : MonoBehaviour

{
    private float defaultMovementMultiplier = 1.0f;
    private bool isSprinting;
    public bool IsSprinting
    {
        get { return isSprinting; }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }
    }
    public float GetSpeedMultiplier()
    {
        if (isSprinting)
            return defaultMovementMultiplier * 2.5f;
        else
            return defaultMovementMultiplier;
    }
}
