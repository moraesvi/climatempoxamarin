namespace CTWeather.Xamarin.Model.Logic
{
    public class CityCTModel
    {
        public int CityId { get; set; }
        public string Uf { get; set; }
        public string City { get; set; }
        public override string ToString()
        {
            return $"Uf: {Uf} - City: {City}";
        }
    }
}
