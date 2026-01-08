using UnityEngine;
using System.Collections.Generic; 

public class FloorFaderSimple : MonoBehaviour
{
    public Transform player;
    public LayerMask floorLayer;
    public float transparentAlpha = 0.3f;

    private List<Material> lastMaterials = new List<Material>();    // Rayがあたっているオブジェクト

    void Update()
    {
        if (player == null) return;

        Vector3 direction = player.position - transform.position;
        float distance = direction.magnitude;
        Debug.DrawRay(transform.position, direction, Color.red);

        RaycastHit[] hits = Physics.RaycastAll(transform.position, direction, distance, floorLayer);
        List<Material> currentMaterials = new List<Material>();

        // Rayにあたったオブジェクトを透明化
        for (int i = 0; i < hits.Length; i++)
        {
            Renderer rend = hits[i].collider.GetComponent<Renderer>();
            if (rend != null)
            {
                Material mat = rend.material;
                SetMaterialAlpha(mat, transparentAlpha);
                currentMaterials.Add(mat); 
            }
        }

        // Rayがあたらなくなったオブジェクトを基に戻す
        for (int i = 0; i < lastMaterials.Count; i++)
        {
            if (!currentMaterials.Contains(lastMaterials[i]))
            {
                SetMaterialAlpha(lastMaterials[i], 1.0f); 
            }
        }

        lastMaterials = currentMaterials;
    }

    void SetMaterialAlpha(Material mat, float alpha)
    {
        if (mat == null) return;

        Color c = mat.color;
        c.a = alpha;
        mat.color = c;

        if (alpha < 1.0f)
        {
            mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            mat.SetInt("_ZWrite", 0);
            mat.EnableKeyword("_ALPHABLEND_ON");
            mat.renderQueue = 3000;
        }
        else
        {
            mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
            mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
            mat.SetInt("_ZWrite", 1);
            mat.DisableKeyword("_ALPHABLEND_ON");
            mat.renderQueue = -1;
        }
    }
}