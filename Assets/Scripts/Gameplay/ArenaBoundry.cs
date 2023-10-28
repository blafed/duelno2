using UnityEngine;

public class ArenaBoundry : MonoBehaviour
{
    public Rect rect => new Rect((Vector2)transform.position - size / 2, size);

    public static ArenaBoundry current;
    public Vector2 size = new Vector2(30, 20);

    [SerializeField] float wallThickness = 1;
    [SerializeField] GameObject wallTemplate;
    Transform[] walls = new Transform[4];

    private void Awake()
    {
        current = this;
    }

    private void Start()
    {
        for (int i = 0; i < walls.Length; i++)
        {
            walls[i] = Instantiate(wallTemplate, transform).transform;
        }

        var wall = walls[0];
        wall.localPosition = new Vector2(0, size.y / 2 + wallThickness / 2); // place the wall at the top edge of the boundry
        wall.localScale = new Vector2(size.x + wallThickness * 2, wallThickness);

        wall = walls[1];
        wall.localPosition = new Vector2(0, -size.y / 2 - wallThickness / 2); // place the wall at the bottom edge of the boundry
        wall.localScale = new Vector2(size.x + wallThickness * 2, wallThickness);

        wall = walls[2];
        wall.localPosition = new Vector2(size.x / 2 + wallThickness / 2, 0); // place the wall at the right edge of the boundry
        wall.localScale = new Vector2(wallThickness, size.y); // make the wall vertically smaller by wallThickness to avoid interference at the corners

        wall = walls[3];
        wall.localPosition = new Vector2(-size.x / 2 - wallThickness / 2, 0); // place the wall at the left edge of the boundry
        wall.localScale = new Vector2(wallThickness, size.y); // make the wall vertically smaller by wallThickness to avoid interference at the corners
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, size);
    }
}