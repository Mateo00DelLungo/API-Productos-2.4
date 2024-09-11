using System.Reflection;

namespace APIProductos_2._4.Models
{
    public interface IAplicacion
    {
        List<Producto> Get();
        List<Producto> Update(Producto oProducto);
        void Delete(int id);
        void Add(Producto oProducto);
    }
}
