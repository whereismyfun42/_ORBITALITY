using UnityEngine;

public class ScrollTexture : MonoBehaviour {

    public float ScrollX = 0.5f;
    public float ScrollY = 0.5f;
    public Material mat;

	
	// Update is called once per frame
	void Update () {
        Random random = new Random();
        float OffsetX = Time.time * ScrollX;
        float OffsetY = Time.time * ScrollY;

        mat.mainTextureOffset = new Vector2(OffsetX, OffsetY);
		
	}
}
