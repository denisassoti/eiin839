
namespace TD3
{
    class Program
    {
        static async Task Main(string[] args)
        {
            JCDecauxClient jCDecauxClient = new JCDecauxClient();

            //question 1
            List<Contract> contracts = await jCDecauxClient.GetDisponibleContracts();

            //question 2
            List<Station> stations = await jCDecauxClient.GetSingleContractStations("marseille");

            //question 3 
            Station station = await jCDecauxClient.GetStationInfos(6, "marseille");

            //question 4
            Position p = new Position();
            p.latitude = 1;
            p.longitude = 10;
            Station s = await jCDecauxClient.FindNearestStation("marseille", p);
            Console.WriteLine(s.ToString());
        }
    }
}