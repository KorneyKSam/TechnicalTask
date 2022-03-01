namespace EventSystem
{
    public static class Events
    {
        public static readonly Event onInputToRight = new Event();
        public static readonly Event onInputToLeft = new Event();
        public static readonly EventWithParameter<TypeOfControl> onControlChanged = new EventWithParameter<TypeOfControl>();
    }
}
