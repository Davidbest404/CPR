using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown dropdown;
    [SerializeField]
    private Button addButton;
    [SerializeField]
    private TMP_InputField inputField;
    private List<ResourceTypes> options;
    void Start()
    {
        string[] _temporaryOptions = Enum.GetNames(typeof(ResourceTypes));
        options = new();
        for (int i = 0; i < _temporaryOptions.Length; i++)
        {
            options.Add((ResourceTypes)Enum.Parse(typeof(ResourceTypes), _temporaryOptions[i]));
            dropdown.options.Add(new(_temporaryOptions[i]));
        }
        addButton.onClick.AddListener(OnButtonClick);
    }
    void OnButtonClick()
    {
        ResourceTypes selectedType = options[dropdown.value];
        if (int.TryParse(inputField.text, out int result))
        {
            SResourceManager.Instance.AddResource(selectedType, result);
        }
        Debug.Log(SResourceManager.Instance.GetResourceCount(selectedType));
    }
}
