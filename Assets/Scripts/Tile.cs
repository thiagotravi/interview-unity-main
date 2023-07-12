using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    /// <summary>
    /// Sprite for empty tile.
    /// </summary>
    public Sprite Empty;
    /// <summary>
    /// Sprite for normal fruit (1 point).
    /// </summary>
    public Sprite Apple;
    /// <summary>
    /// Sprite for head of snake.
    /// </summary>
    public Sprite SnakesHead;
    /// <summary>
    /// Sprite for snake's body.
    /// </summary>
    /// 
    public Sprite SnakesBody;
    /// <summary>
    /// Sprite for snake's tail.
    /// </summary>
    public Sprite SnakesTail;
    /// <summary>
    /// Sprite for snake's bulged body.
    /// </summary>
    public Sprite SnakesBulge;
    /// <summary>
    /// Sprite for snake's L shape
    /// </summary>
    public Sprite SnakesL;
    /// <summary>
    /// Sprite for snake's L bulged shape
    /// </summary>
    public Sprite SnakesLBulged;

    public Sprite Enemy;

    public Sprite Projectile;

    private Image image;
    private Sprite lastUsedImage;
    private RectTransform _rectTransform;
    private TileContent _content;
    private bool _contentHidden;

    public RectTransform RectTransform
    {
        get
        {
            return _rectTransform;
        }
    }

    public TileContent Content
    {
        get
        {
            return _content;
        }
        set
        {
            _content = value;
            ZRotation = 0;
            switch (_content)
            {
                case TileContent.Empty:
                    image.sprite = Empty;
                    break;
                case TileContent.Apple:
                    image.sprite = Apple;
                    break;
                case TileContent.Enemy:
                    image.sprite = Enemy;
                    break;
                case TileContent.SnakesHead:
                    image.sprite = SnakesHead;
                    break;
                case TileContent.SnakesBody:
                    image.sprite = SnakesBody;
                    break;
                case TileContent.SnakesBulge:
                    image.sprite = SnakesBulge;
                    break;
                case TileContent.SnakesTail:
                    image.sprite = SnakesTail;
                    break;
                case TileContent.SnakesL:
                    image.sprite = SnakesL;
                    break;
                case TileContent.SnakesLBulged:
                    image.sprite = SnakesLBulged;
                    break;
            }
            lastUsedImage = image.sprite;
        }
    }

    private float _zRotation = 0;

    /// <summary>
    /// Sets or gets tile's Z-rotation
    /// </summary>
    public float ZRotation
    {
        get
        {
            return _zRotation;
        }
        set
        {
            _zRotation = value;
            transform.rotation = Quaternion.Euler(0, 0, value);
        }
    }

    public bool ContentHidden
    {
        get
        {
            return _contentHidden;
        }
        set
        {
            _contentHidden = value;
            if (value)
            {
                image.sprite = Empty;
            }
            else
            {
                image.sprite = lastUsedImage;
            }
        }
    }

    void Awake()
    {
        image = GetComponent<Image>();
        _rectTransform = GetComponent<RectTransform>();
        Content = TileContent.Empty;
        _contentHidden = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        Content = TileContent.Empty;
    }
}
