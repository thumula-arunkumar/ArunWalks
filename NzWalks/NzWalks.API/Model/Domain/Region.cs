namespace NzWalks.API.Model.Domain
{
    public class Region
    {
        //Id,code, name , area, lat, long population

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public double Area { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public long Population { get; set; }

        //Navigation 

        public IEnumerable<Walk> walks { get; set; }

    }
}
