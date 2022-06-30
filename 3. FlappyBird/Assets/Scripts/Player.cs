using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 direction;
    private SpriteRenderer spriteRenderer;
    private int spriteIndex;
    
    public Sprite[] sprites;
    public float gravity = -9.8f;
    public float strength = 5f;
    public AudioSource audio;
    public AudioSource audio2;
    public AudioClip jumpClip;
    public AudioClip hitClip;
    public AudioClip pointClip;

    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            audio.clip = jumpClip;
            audio.Play();
            direction = Vector3.up * strength;
        }

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                audio.clip = jumpClip;
                audio.Play();
                direction = Vector3.up * strength;
            }

        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void AnimateSprite()
    {
        spriteIndex++;

        if(spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        // Up and down rotation of the bird
        Quaternion rot = transform.rotation;
        if (direction.y > 0)
            {
                rot.z = direction.y * 0.04f;
                transform.rotation = rot;
            }
        else
            {
                rot.z = direction.y * 0.04f;
                transform.rotation = rot;
            }
        //

        spriteRenderer.sprite = sprites[spriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            audio.clip = hitClip;
            audio.Play();
            FindObjectOfType<GameManager>().GameOver();
        }
        else if(other.gameObject.tag == "Scoring")
        {
            audio2.clip = pointClip;
            audio2.Play();
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }
}
