using UnityEngine;

public class GrassGenerator : MonoBehaviour
{
    public GameObject GrassStra;
    public float densety;
    float dens = 0;
    Vector3 scale = Vector3.one;
    public GameObject[,] grass = new GameObject[0,0];
    void Update() {
        if (densety != dens || scale != transform.localScale) {
            foreach (GameObject g in grass) {
                Destroy(g);
            }
            grass = new GameObject[(int)(densety * transform.localScale.x), (int)(densety * transform.localScale.z)];
            for (int x = 0; x < grass.GetLength(0); x++) 
                for (int z = 0; z < grass.GetLength(1); z++) {
                    Vector3 pos = new Vector3(x, 0, z)/densety;
                    pos += new Vector3 {
                        x = Random.Range(-0.5f, 0.5f),
                        y = 0,
                        z = Random.Range(-0.5f, 0.5f)
                    };
                    grass[x, z] = Instantiate(GrassStra, pos, Quaternion.identity);
                }

            dens = densety;
            scale = transform.localScale;
        }
    }
}
