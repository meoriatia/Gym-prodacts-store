using Models;
using System.Data;

namespace WebService.DAL
{
    public class MaterialCreator : IModelCreator<Material>
    {
        public Material CreateModel(IDataReader src)
        {
            Material material = new Material()
            {
                MaterialId = Convert.ToInt16(src["MaterialId"]),
                MaterialName = Convert.ToString(src["MaterialName"]),
                MaterialDescription = Convert.ToString(src["MaterialDescription"]),
            };
            return material;
        }
    }
}
