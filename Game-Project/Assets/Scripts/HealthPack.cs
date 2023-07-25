using System.Collections;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float HealthAmount;
    [SerializeField] AudioClip PickupSound;
    private AudioSource Asource;
    private Player player;
    private bool isTaken;
    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        Asource = this.gameObject.GetComponent<AudioSource>();
        isTaken = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && player.HitPoint < 100 && !isTaken)
        {
            isTaken = true;
            if (player.HitPoint + HealthAmount > 100) { player.HitPoint = 100; }
            else player.HitPoint += HealthAmount;
            Asource.clip = PickupSound;
            Asource.Play();
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(PlayParticle());
            Debug.Log("Health +" + HealthAmount);
        }

    }
    // Update is called once per frame
    private IEnumerator PlayParticle()
    {
        this.gameObject.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(4.0f);
        this.gameObject.SetActive(false);
    }
}
