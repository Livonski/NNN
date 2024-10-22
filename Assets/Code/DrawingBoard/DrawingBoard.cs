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
        Vector2 pivot = new Vector2(0.5f, 0.5f);

        _sprite = Sprite.Create(_boardTexture, spriteRect, pivot,_spriteRenderer.sprite.pixelsPerUnit);
        _spriteRenderer.sprite = _sprite;

        GenerateTexture();
    }

    public void SetPixel(int x, int y)
    {
        _boardTexture.SetPixel(x, y, Color.white);
        _boardTexture.Apply();
    }

    public void SetPixel(Vector3 localCoordinates)
    {
        int PixelX = (int)((localCoordinates.x + 0.5f) * _size.x);
        int PixelY = (int)((localCoordinates.y + 0.5f) * _size.y);
        _boardTexture.SetPixel(PixelX, PixelY, Color.white);
        _boardTexture.Apply();
    }

    //For some reason if you draw in the edge of image, some pixels on the other side get's painted too
    //I probably need to fix that
    //And add some decreasing brush strength in the future

    public void SetPixel(Vector3 localCoordinates, int brushSize)
    {
        int OriginX = (int)((localCoordinates.x + 0.5f) * _size.x);
        int OriginY = (int)((localCoordinates.y + 0.5f) * _size.y);

        int halfBrushSize = (int)(brushSize / 2);

        for (int y = OriginY - halfBrushSize; y <= OriginY + halfBrushSize; y++)
        {
            for (int x = OriginX - halfBrushSize; x <= OriginX + halfBrushSize; x++)
            {
                _boardTexture.SetPixel(x, y, Color.white);
            }
        }
        _boardTexture.Apply();
    }

    public void GenerateTexture()
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
