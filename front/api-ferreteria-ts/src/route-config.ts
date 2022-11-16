import ComponenteActualizarCategoria from "./categorias/ComponenteActualizarCategoria";
import ComponenteListarCategoria from "./categorias/ComponenteListarCategoria";
import ComponenteRegistrarCategoria from "./categorias/ComponenteRegistrarCategoria";
import ComponenteActualizarCliente from "./clientes/ComponenteActualizarCliente";
import ComponenteListarCliente from "./clientes/ComponenteListarCliente";
import ComponenteRegistrarCliente from "./clientes/ComponenteRegistrarCliente";
import ComponenteActualizarEmpleado from "./empleado/ComponenteActualizarEmpleado";
import ComponenteListarempleado from "./empleado/ComponenteListarEmpleado";
import ComponenteRegistrarEmpleado from "./empleado/ComponenteRegistrarEmpleado";
import ComponentePrincipal from "./principal/ComponentePrincipal";
import ComponenteRedireccionar from "./principal/ComponenteRedireccionado";
import ComponenteActualizarProducto from "./producto/ComponenteActualizarProducto";
import ComponenteListarProducto from "./producto/ComponenteListarProducto";
import ComponenteRegistrarProducto from "./producto/ComponenteRegistrarProducto";

const rutas = [
    //RUTAS PARA LISTAR,ACTUALIZAR Y REGISTRAR CLIENTES
    { path: "/clientes/actualizar/:id", componente: ComponenteActualizarCliente },
    { path: "/clientes/registrar", componente: ComponenteRegistrarCliente },
    { path: "/clientes", componente: ComponenteListarCliente },
    { path: "/", componente: ComponentePrincipal },

    //RUTAS PARA LISTAR,ACTUALIZAR Y REGISTRAR CATEGORIAS
    { path: "/categorias/actualizar/:id", componente: ComponenteActualizarCategoria},
    { path: "/categorias/registrar", componente: ComponenteRegistrarCategoria},
    { path: "/categorias", componente: ComponenteListarCategoria},

    //RUTAS PARA LISTAR,ACTUALIZAR Y REGISTRAR EMPLEADOS
    { path: "empleados/actualizarEmp/:id", componente: ComponenteActualizarEmpleado },
    { path: "/empleados/registrarEmp", componente: ComponenteRegistrarEmpleado },
    { path: "/empleados", componente: ComponenteListarempleado },
    { path: "/", componente: ComponentePrincipal },

    //RUTAS PARA LISTAR, ACTUALIZAR Y REGISTRAR PRODUCTOS
    { path: "/productos/actualizar/:id", componente: ComponenteActualizarProducto},
    { path: "/productos/registrar", componente: ComponenteRegistrarProducto}, 
    { path: "/productos", componente: ComponenteListarProducto},
    { path: "/", componente: ComponentePrincipal },    
    
    //creando un path para rutas no encontradas, esto siempre va al finalizar
    { path: "*", componente: ComponenteRedireccionar },
  ];
  export default rutas;
  