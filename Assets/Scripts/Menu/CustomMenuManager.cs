using UnityEngine;
using UnityEngine.UI;

public class CustomMenuManager : MonoBehaviour {
    GameObject _selected;
    public GameObject selected {
        get{
            return _selected;
        }
        set{
            _selected = value;
            moveCircles();
        }
    }

    [SerializeField] Transform circleLeftTs;
    [SerializeField] Transform circleRightTs;

    [SerializeField] float offsetPointerY;
    [SerializeField] float offsetPointerX;

    private void Awake() {
        setCirclesActives(false);
    }

    public void moveCircles() {
        RectTransform selectedTs = _selected.GetComponent<RectTransform>();
        Text text = _selected.GetComponent<Text>();
        float canvasWidth = text.canvas.pixelRect.width;
        float offsetX = (offsetPointerX * canvasWidth) / 100;
        float offsetY = (offsetPointerY * canvasWidth) / 100;

        Vector3[] bound = new Vector3[4];
        selectedTs.GetWorldCorners(bound);


        float textWidth = text.preferredWidth;
        float posXLeft = bound[0].x;
        float posXRight = bound[3].x;

        circleLeftTs.position = new Vector2(
            posXLeft - offsetX,
            selectedTs.position.y + offsetY
        );
        circleRightTs.position = new Vector2(
            posXRight + offsetX,
            selectedTs.position.y + offsetY
        );
    }

    public void setCirclesActives(bool value) {
        circleLeftTs.gameObject.SetActive(value);
        circleRightTs.gameObject.SetActive(value);
    }
}
