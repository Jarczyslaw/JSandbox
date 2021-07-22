namespace WPFNestedBindingTest
{
    public class Item : NotifyPropertyChanged
    {
        private int value;

        public int Value
        {
            get => value;
            set => Set(ref this.value, value);
        }
    }
}