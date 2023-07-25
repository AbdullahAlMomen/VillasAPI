using VillasAPICore.Models.DTO;

namespace VillasAPICore.DataStore
{
    public static class VillaDataStore
    {
        public static List<VillaDTO> VillaDTOs = new List<VillaDTO>
        {
            new VillaDTO { Id = 1,Name = "Matiranga"},
             new VillaDTO { Id = 2,Name = "Bonsai"},
        };
    }
}
