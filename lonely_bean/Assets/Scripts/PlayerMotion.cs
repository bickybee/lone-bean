using UnityEngine;
using System.Collections;

public class PlayerMotion : MonoBehaviour {

	public float speed = 100f;
	public float jump = 1000f;
	public float maxVelocityX = 1000f;
	public float maxVelocityY = 1000f;

	public bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	private Rigidbody2D body;
	private Animator animator;

	public AudioClip[] audioClips;

	// Use this for initialization
	void Start () {
		body = gameObject.GetComponent<Rigidbody2D>();
		animator = gameObject.GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update() {

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		animator.SetBool ("Grounded", grounded);

		var absVelX = Mathf.Abs (body.velocity.x);
		var absVelY = Mathf.Abs (body.velocity.y);

		Vector3 velocityVector = new Vector3 (0, 0, 0);

		if (grounded && Input.GetKey (KeyCode.Space) ) {
			animator.SetBool ("Walking", false);
			if (absVelY < maxVelocityY) {
				body.AddForce (new Vector2 (0, jump), ForceMode2D.Impulse);
				grounded = false;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    PlaySound(1);
                }
                
			}
		}
		if (Input.GetKey ("right")) {
			if (absVelX < maxVelocityX) {
				body.velocity = new Vector2 (speed, body.velocity.y);
			}
			transform.localScale = new Vector3 (-1, 1, 1);
			animator.SetBool ("Walking", true);
		} else if (Input.GetKey ("left")) {
			if (absVelX < maxVelocityX) {
				body.velocity = new Vector2 (-speed, body.velocity.y);;
			}
			transform.localScale = Vector3.one;
			animator.SetBool ("Walking", true);
		} else {
			animator.SetBool ("Walking", false);
		}
					
	}


	void PlaySound(int clipIndex){
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(audioClips[clipIndex]);
    }
}
