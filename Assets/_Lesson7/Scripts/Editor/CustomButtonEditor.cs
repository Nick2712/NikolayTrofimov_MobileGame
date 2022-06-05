using UnityEditor;
using UnityEditor.UI;
using UnityEditor.UIElements;
using UnityEngine.UIElements;


namespace NikolayTrofimov_MobileGame_Lesson7
{
    [CustomEditor(typeof(CustomButtonByInheritance))]
    internal class CustomButtonEditor : ButtonEditor
    {
        private SerializedProperty m_InteractableProperty;

        protected override void OnEnable()
        {
            m_InteractableProperty = serializedObject.FindProperty("m_Interactable");
        }

        public override VisualElement CreateInspectorGUI()
        {
            var root = new VisualElement();

            var animationType = new PropertyField(serializedObject.FindProperty(CustomButtonByInheritance.AnimationTypeName));
            var curveEase = new PropertyField(serializedObject.FindProperty(CustomButtonByInheritance.CurveEaseName));
            var duration = new PropertyField(serializedObject.FindProperty(CustomButtonByInheritance.DurationName));
            var strength = new PropertyField(serializedObject.FindProperty(CustomButtonByInheritance.StrengthName));

            var tweenLaber = new Label("Settings Tween");
            var interactableLabel = new Label("Interactable");

            root.Add(tweenLaber);
            root.Add(animationType);
            root.Add(curveEase);
            root.Add(duration);
            root.Add(strength);

            root.Add(interactableLabel);
            root.Add(new IMGUIContainer(OnInspectorGUI));

            return root;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(m_InteractableProperty);

            EditorGUI.BeginChangeCheck();
            EditorGUI.EndChangeCheck();

            serializedObject.ApplyModifiedProperties();
        }
    }
}
