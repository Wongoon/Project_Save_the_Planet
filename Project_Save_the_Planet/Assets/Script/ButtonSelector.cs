using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonSelector : MonoBehaviour
{
    public Button[] buttons; // 선택할 버튼들
    public Sprite selectedSprite; // 버튼이 선택되었을 때의 이미지
    public Sprite defaultSprite;  // 버튼의 기본 이미지

    private int selectedButtonIndex = 0; // 현재 선택된 버튼 인덱스

    void Start()
    {
        // 첫 번째 버튼을 기본으로 선택
        if (buttons.Length > 0)
        {
            SelectButton(selectedButtonIndex);
        }
    }

    void Update()
    {
        if (buttons.Length == 0) return; // 버튼 배열이 비어 있으면 아무 동작도 하지 않음

        // 위 화살표를 누르면 이전 버튼 선택
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ChangeButtonImage(selectedButtonIndex, defaultSprite); // 이전 버튼 이미지를 기본으로 변경
            selectedButtonIndex--; // 인덱스를 감소시켜 이전 버튼으로 이동
            if (selectedButtonIndex < 0) // 첫 번째 버튼에서 위로 가면 마지막 버튼으로 이동
            {
                selectedButtonIndex = buttons.Length - 1; // 배열의 마지막 버튼으로 이동
            }
            SelectButton(selectedButtonIndex);
        }

        // 아래 화살표를 누르면 다음 버튼 선택
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ChangeButtonImage(selectedButtonIndex, defaultSprite); // 이전 버튼 이미지를 기본으로 변경
            selectedButtonIndex++; // 인덱스를 증가시켜 다음 버튼으로 이동
            if (selectedButtonIndex >= buttons.Length) // 마지막 버튼에서 아래로 가면 첫 번째 버튼으로 이동
            {
                selectedButtonIndex = 0; // 배열의 첫 번째 버튼으로 이동
            }
            SelectButton(selectedButtonIndex);
        }

        // 엔터 키를 누르면 버튼 클릭
        if (Input.GetKeyDown(KeyCode.Return))
        {
            buttons[selectedButtonIndex].onClick.Invoke();
        }
    }

    // 버튼을 선택하는 함수
    private void SelectButton(int index)
    {
        // 선택된 버튼의 이미지를 변경
        ChangeButtonImage(index, selectedSprite);
        // EventSystem을 통해 UI에서 선택된 상태로 변경
        EventSystem.current.SetSelectedGameObject(buttons[index].gameObject);
    }

    // 버튼 이미지 변경 함수
    private void ChangeButtonImage(int index, Sprite newSprite)
    {
        Image buttonImage = buttons[index].GetComponent<Image>();
        if (buttonImage != null)
        {
            buttonImage.sprite = newSprite;
        }
    }
}