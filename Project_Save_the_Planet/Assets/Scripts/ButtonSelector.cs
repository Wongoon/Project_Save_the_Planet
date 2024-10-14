using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonSelector : MonoBehaviour
{
    public Button[] buttons; // ������ ��ư��
    public Sprite selectedSprite; // ��ư�� ���õǾ��� ���� �̹���
    public Sprite defaultSprite;  // ��ư�� �⺻ �̹���

    private int selectedButtonIndex = 0; // ���� ���õ� ��ư �ε���

    void Start()
    {
        // ù ��° ��ư�� �⺻���� ����
        if (buttons.Length > 0)
        {
            SelectButton(selectedButtonIndex);
        }
    }

    void Update()
    {
        if (buttons.Length == 0) return; // ��ư �迭�� ��� ������ �ƹ� ���۵� ���� ����

        // �� ȭ��ǥ�� ������ ���� ��ư ����
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ChangeButtonImage(selectedButtonIndex, defaultSprite); // ���� ��ư �̹����� �⺻���� ����
            selectedButtonIndex--; // �ε����� ���ҽ��� ���� ��ư���� �̵�
            if (selectedButtonIndex < 0) // ù ��° ��ư���� ���� ���� ������ ��ư���� �̵�
            {
                selectedButtonIndex = buttons.Length - 1; // �迭�� ������ ��ư���� �̵�
            }
            SelectButton(selectedButtonIndex);
        }

        // �Ʒ� ȭ��ǥ�� ������ ���� ��ư ����
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ChangeButtonImage(selectedButtonIndex, defaultSprite); // ���� ��ư �̹����� �⺻���� ����
            selectedButtonIndex++; // �ε����� �������� ���� ��ư���� �̵�
            if (selectedButtonIndex >= buttons.Length) // ������ ��ư���� �Ʒ��� ���� ù ��° ��ư���� �̵�
            {
                selectedButtonIndex = 0; // �迭�� ù ��° ��ư���� �̵�
            }
            SelectButton(selectedButtonIndex);
        }

        // ���� Ű�� ������ ��ư Ŭ��
        if (Input.GetKeyDown(KeyCode.Return))
        {
            buttons[selectedButtonIndex].onClick.Invoke();
        }
    }

    // ��ư�� �����ϴ� �Լ�
    private void SelectButton(int index)
    {
        // ���õ� ��ư�� �̹����� ����
        ChangeButtonImage(index, selectedSprite);
        // EventSystem�� ���� UI���� ���õ� ���·� ����
        EventSystem.current.SetSelectedGameObject(buttons[index].gameObject);
    }

    // ��ư �̹��� ���� �Լ�
    private void ChangeButtonImage(int index, Sprite newSprite)
    {
        Image buttonImage = buttons[index].GetComponent<Image>();
        if (buttonImage != null)
        {
            buttonImage.sprite = newSprite;
        }
    }
}