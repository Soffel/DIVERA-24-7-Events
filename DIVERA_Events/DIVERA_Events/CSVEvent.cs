using Client;
using Extensions;

namespace DIVERA_Events
{
    internal sealed class CSVEvent
    {
        public string Title { get; set; }
        public string Date { get; set; }
        public string Meldung { get; set; }
        public string Ort { get; set; }

        public static explicit operator CSVEvent(EventResult result)
        => new()
        {
            Title = result.Title,
            Date = result.Date.ToDateTime().ToString("dd.MM.yyyy HH:mm"),
            Meldung = result.Text,
            Ort = result.Address,
        };
    }
}
