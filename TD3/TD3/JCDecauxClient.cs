using System.Device.Location;
using System.Text.Json;

//dotnet add package System.Device.Location.Portable --version 1.0.0
namespace TD3
{
    public class JCDecauxClient
    {
        static readonly HttpClient client = new HttpClient();
        const string URL = "https://api.jcdecaux.com/vls/v3";
        const string API_KEY = "f2fb1e333e073677b8625ed9cc3c414e5edfa940";

        public async Task<List<Contract>> GetDisponibleContracts()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(URL + "/contracts?apiKey=" + API_KEY);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                List<Contract> contracts = JsonSerializer.Deserialize<List<Contract>>(responseBody);
                return contracts;

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            return null;
        }

        //Tsak est comme une promise en js
        public async Task<List<Station>> GetSingleContractStations(string contractName)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(URL + "/stations?contract=" + contractName + "&apiKey=" + API_KEY);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                List<Station> stations = JsonSerializer.Deserialize<List<Station>>(responseBody);

                return stations;

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return null;
        }

        public async Task<Station> GetStationInfos(int stationNumber, string contractName)
        {
            try
            {
                List<Station> stations = await GetSingleContractStations(contractName);
                Station validStation = null;

                if (stations != null)
                {
                    foreach (Station station in stations)
                    {
                        if (station.number == stationNumber)
                        {
                            validStation = station;
                        }
                    }
                    return validStation;
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            return null;
        }


        private Position convertToDegrees(Position position)
        {
            double lat = position.latitude;
            double lon = position.longitude;

            if (lat > 90 || lat < -90)
            {
                double degrees = Math.Floor(lat);
                double minutes = (lat - degrees) * 60;
                double seconds = (minutes - Math.Floor(minutes)) * 60;
                lat = lat - (minutes / 60) + (seconds / 3600);

            }
            if (lon > 180 || lon < -180)
            {
                double degrees = Math.Floor(lon);
                double minutes = (lon - degrees) * 60;
                double seconds = (minutes - Math.Floor(minutes)) * 60;
                lon = lon - (minutes / 60) + (seconds / 3600);
            }
            return new Position { latitude = lat, longitude = lon };
        }
        public async Task<Station> FindNearestStation(string contractName, Position position)
        {
            try
            {
                List<Station> stations = await this.GetSingleContractStations(contractName);
                if (stations != null)
                {
                    Position convPosition1 = convertToDegrees(position);
                    GeoCoordinate coordinate = new GeoCoordinate(convPosition1.latitude, convPosition1.longitude);
                    Station foundStation = null;
                    List<Double> distances = new List<Double>();

                    foreach (Station station in stations)
                    {
                        Position convertedPosition = convertToDegrees(station.position);
                        GeoCoordinate geo = new GeoCoordinate(convertedPosition.latitude, convertedPosition.longitude);
                        Double distance = coordinate.GetDistanceTo(geo);
                        distances.Add(distance);
                    }

                    Double min_distance = distances.Min();
                    int index = distances.IndexOf(min_distance);
                    foundStation = stations[index];
                    //Console.WriteLine("La station la plus proche est la station numéro {0}", foundStation.number);
                    return foundStation;
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            return null;
        }
    }
}
