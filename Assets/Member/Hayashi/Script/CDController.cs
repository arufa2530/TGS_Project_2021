using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CDController : MonoBehaviour
{
    [SerializeField] GameObject Drive;

    bool IsDrop;
    int ClickVal;

    Collider2D HitCollsion;

    // Start is called before the first frame update
    void Start()
    {
        IsDrop = false;
        ClickVal = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsDrop)
            Follow();

        if (ClickVal > 2 && !IsDrop)
            IsDrop = true;
    }

    private void Follow()
    {
        this.GetComponent<RectTransform>().anchoredPosition = new Vector2(Drive.GetComponent<RectTransform>().anchoredPosition.x + 11f, Drive.GetComponent<RectTransform>().anchoredPosition.y + 24f);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        HitCollsion = collision;
    }

    private void OnMouseDown()
    {
        ClickVal++;
    }

    private void OnMouseDrag()
    {
        if (IsDrop)
        {
            //Cube�̈ʒu�����[���h���W����X�N���[�����W�ɕϊ����āAobjectPoint�Ɋi�[
            Vector3 objectPoint
                = Camera.main.WorldToScreenPoint(transform.position);

            //Cube�̌��݈ʒu(�}�E�X�ʒu)���ApointScreen�Ɋi�[
            Vector3 pointScreen
                = new Vector3(Input.mousePosition.x,
                              Input.mousePosition.y,
                              objectPoint.z);

            //Cube�̌��݈ʒu���A�X�N���[�����W���烏�[���h���W�ɕϊ����āApointWorld�Ɋi�[
            Vector3 pointWorld = Camera.main.ScreenToWorldPoint(pointScreen);
            pointWorld.z = transform.position.z;

            //Cube�̈ʒu���ApointWorld�ɂ���
            transform.position = pointWorld;
        }
    }

    private void OnMouseUpAsButton()
    {
        if (HitCollsion.gameObject.name == "Floppy")
        {
            this.GetComponent<AudioSource>().Play();
        }
    }
}
