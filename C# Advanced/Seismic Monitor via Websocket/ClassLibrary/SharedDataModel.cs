using System.Collections.ObjectModel;

namespace ClassLibrary
{
    // Shared data model
    public class SharedDataModel
    {
        public ObservableCollection<SeismicEventModel> _seismicEvents { get; set; } = new ObservableCollection<SeismicEventModel>();
    }
}
