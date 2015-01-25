using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour 
{
    public float lifeTime = 10;
    public AudioClip arrow; 

    string targetTag;

	void Start () 
    {
        Destroy(gameObject, 60);
	}

    void Update()
    {
        transform.right = Vector3.Slerp(transform.right, rigidbody2D.velocity.normalized, Time.deltaTime * 3);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == targetTag && col.gameObject.GetComponent<Donkey>() == false)
        {
            if(col.gameObject.GetComponent<PlayerController>())
                col.gameObject.GetComponent<PlayerController>().Die();
            PlayArrowHit(col.gameObject);
        }
        if(col.tag == targetTag && col.gameObject.GetComponent<Donkey>()== true)
        {
            Donkey donk = col.gameObject.GetComponent<Donkey>();
            donk.healthPoints--;
            Destroy(this);
        }
        else if (col.tag == "Ground")
        {
            rigidbody2D.fixedAngle = true;
            rigidbody2D.isKinematic = true;
            collider2D.enabled = false;
            StartCoroutine(PlayArrowMiss());
        }
    }

    public void SetTargetTag(string targetTag)
    {
        this.targetTag = targetTag;
    }

    void PlayArrowHit(GameObject g)
    {
        audio.Play();
        Destroy(g);
        Destroy(gameObject);
    }

    IEnumerator PlayArrowMiss()
    {
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        Destroy(gameObject, lifeTime);
    }
}
