public static class FactoryService
{
    public static IInputController GetCurrentInput()
    {
#if UNITY_EDITOR || UNITY_WEBGL
        return new InputMouseController();
#else
        return new InputTouchController();
#endif
    }
}