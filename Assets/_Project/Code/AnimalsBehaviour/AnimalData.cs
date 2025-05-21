namespace _Project.Code.AnimalsBehaviour
{
    public readonly struct AnimalData
    {
        public readonly AnimalType type;
        public readonly AnimalForm form;
        public readonly AnimalColor color;

        public AnimalData(AnimalType type, AnimalForm form, AnimalColor color)
        {
            this.type = type;
            this.form = form;
            this.color = color;
        }
    }
}