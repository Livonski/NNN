using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingBoard : MonoBehaviour
{
    [SerializeField] private Texture2D _boardTexture;
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _sprite;

    [SerializeField] private Vector2Int _size;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _size = new Vector2Int(_spriteRenderer.sprite.texture.width, _spriteRenderer.sprite.texture.height);
        _boardTexture = new Texture2D(_size.x, _size.y, TextureFormat.ARGB32, false);  

        Rect spriteRect = new Rect(_spriteRenderer.sprite.rect);
        //Vector2 pivot = _spriteRenderer.sprite.pivot;
        Vector2 pivot = Vector2.zero;
        _sprite = Sprite.Create(_boardTexture, spriteRect, pivot);
        _spriteRenderer.sprite = _sprite;

        GenerateTexture();
        //OnUpdate();
    }

    public void AddPixel(int x, int y)
    {

    }

    private void OnUpdate()
    {

    }

    private void GenerateTexture()
    {
        for (int y = 0; y < _size.y; y++)
        {
            for (int x = 0; x < _size.y; x++)
            {
                _boardTexture.SetPixel(x,y,Color.black);
            }
        }
        _boardTexture.Apply();
    }
}
