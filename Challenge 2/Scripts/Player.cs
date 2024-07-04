using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject dogPrefab;
    private bool activationReady = true;
    private float activationDelayTime = 0.5f;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && activationReady)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            StartCoroutine(ActivationCooldown());
        }
    }

    private IEnumerator ActivationCooldown()
    {
        activationReady = false;
        yield return new WaitForSeconds(activationDelayTime);
        activationReady = true;
    }
}
