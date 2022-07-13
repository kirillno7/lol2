using UnityEngine;


public class MyAdvancedGUI : MonoBehaviour
{
    [SerializeField, Range(0f, 5f)]
    [Tooltip("Значение находится в диапазоне от 0 до 100")]
    private float mySlider = 1.0f; // Положение пользовательского слайдера
    [Header("Custom color")]
    public Color myColor;         // Градиент цвета
    public MeshRenderer GO;      // Ссылка на рендер объекта

    [SerializeField, TextArea(5, 10)]
    private string field;

    [SerializeField] public Sprite sprite;
    [SerializeField] GameObject obj;


    private void Update()
    {
        var us = obj.GetComponent<HealthController>();
        mySlider = us.CurrentHealth;
    }
    
   
    
    void OnGUI()
    {
        mySlider = LabelSlider(new Rect(10, 10, 200, 20), mySlider, 0, 100, "My Hp"); // Отрисовка пользовательского слайдера
        
        myColor = RGBSlider(new Rect(10, 30, 200, 20), myColor);  // Отрисовка пользовательского набора слайдеров для получения градиента цвета
        GO.material.color = myColor; // Покраска объекта
    }

    // Отрисовка пользовательского слайдера
    float LabelSlider(Rect screenRect, float sliderValue, float sliderMinValue, float sliderMaxValue, string labelText) // ДЗ добавить MinValue
    {
        // создаём прямоугольник с координатами в пространстве и заданой шириной и высотой 
        Rect labelRect = new Rect(screenRect.x, screenRect.y, screenRect.width / 2, screenRect.height);
               
        GUI.Label(labelRect, labelText);   // создаём Label на экране

        Rect sliderRect = new Rect(screenRect.x + screenRect.width / 2, screenRect.y, screenRect.width / 2, screenRect.height); // Задаём размеры слайдера
        sliderValue = GUI.HorizontalSlider(sliderRect, sliderValue, sliderMinValue, sliderMaxValue); // Вырисовываем слайдер и считываем его параметр
        return sliderValue; // Возвращаем значение слайдера
    }

    // Отрисовка тройной слайдер группы, каждый слайдер отвечает за свой цвет
    Color RGBSlider(Rect screenRect, Color rgb)
    {
        // Используя пользовательский слайдер, создаём его
        rgb.r = LabelSlider(screenRect, rgb.r, 0, 1.0f, "Red");
        
        // делаем промежуток
        screenRect.y += 20;
        rgb.g = LabelSlider(screenRect, rgb.g, 0, 1.0f, "Green");

        screenRect.y += 20;
        rgb.b = LabelSlider(screenRect, rgb.b, 0, 1.0f, "Blue");

        screenRect.y += 20;
        rgb.a = LabelSlider(screenRect, rgb.a, 0, 1.0f, "Alpha");
        return rgb; // возвращаем цвет
    } 
}
