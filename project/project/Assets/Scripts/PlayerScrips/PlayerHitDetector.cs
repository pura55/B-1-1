using UnityEngine;

public class PlayerHitDetector : MonoBehaviour 
{
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("‚Ô‚Â‚©‚Á‚½‘Šè: " + col.gameObject.name);
        if (col.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("“G‚É‚Ô‚Â‚©‚Á‚½I");
            Destroy(col.gameObject);
        }
    }
}
