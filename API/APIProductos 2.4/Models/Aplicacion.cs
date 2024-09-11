
using Microsoft.AspNetCore.Localization;

namespace APIProductos_2._4.Models
{
    public class Aplicacion : IAplicacion
    {
        private static readonly List<Producto> productos = new List<Producto>();
        public void Add(Producto oProducto)
        {
            productos.Add(oProducto);
        }

        public void Delete(int id)
        {
            productos.Remove(productos.Find(oProducto => oProducto.Codigo == id));
        }

        public List<Producto> Get()
        {
            return productos;
        }

        public List<Producto> Update(Producto oProducto)
        {
            if (productos.Exists(producto => producto.Codigo == oProducto.Codigo))
            {
                int index = productos.FindIndex(prod => prod.Codigo == oProducto.Codigo);
                productos[index].Nombre = oProducto.Nombre;
                productos[index].Precio = oProducto.Precio;
                return productos;
            }
            else 
            {
                return null;
            }
        }
    }
}
