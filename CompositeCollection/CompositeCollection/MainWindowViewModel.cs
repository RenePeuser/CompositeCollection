using System.Collections.ObjectModel;
using CompositeCollection.Model;
using BindingBase = CompositeCollection.Base.BindingBase;

namespace CompositeCollection
{
    public class MainWindowViewModel : BindingBase
    {
        public MainWindowViewModel()
        {
            SourceA = new ObservableCollection<Person>();
            SourceB = new ObservableCollection<Person>();
        }


        public void AddItemToSourceA()
        {
            SourceA.Add(new Person("Max - " + SourceA.Count, "M" + SourceA.Count));
        }

        public void AddItemToSourceB()
        {
            SourceB.Add(new Person("Muster" + SourceB.Count, "M" + SourceB.Count));
        }

        public ObservableCollection<Person> SourceA { get; }

        public ObservableCollection<Person> SourceB { get; }
    }
}
