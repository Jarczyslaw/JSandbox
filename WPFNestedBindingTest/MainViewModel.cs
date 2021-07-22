namespace WPFNestedBindingTest
{
    public class MainViewModel : NotifyPropertyChanged
    {
        private Item item2;

        public MainViewModel()
        {
            Item = new Item();
            Item2 = new Item();
        }

        public RelayCommand InvalidUpdateValue => new RelayCommand(() => Item.Value++);

        public RelayCommand InvalidOverrideValue => new RelayCommand(() => Item = new Item
        {
            Value = 666
        });

        public RelayCommand ValidUpdateValue => new RelayCommand(() => Item2.Value++);

        public RelayCommand ValidOverrideValue => new RelayCommand(() => Item2 = new Item
        {
            Value = 666
        });

        public Item Item { get; set; }

        public Item Item2
        {
            get => item2;
            set => Set(ref item2, value);
        }
    }
}