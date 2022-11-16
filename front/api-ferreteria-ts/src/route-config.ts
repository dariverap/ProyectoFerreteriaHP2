import ComponenteActualizarCliente from "./Clientes/ComponenteActualizarCliente";
import ComponenteListarCliente from "./Clientes/ComponenteListarCliente";
import ComponenteRegistrarCliente from "./Clientes/ComponenteRegistrarCliente";
import ComponentePrincipal from "./principal/ComponentePrincipal";
import ComponenteRedireccionar from "./principal/ComponenteRedireccionado";

const rutas = [
    //RUTAS PARA LISTAR,ACTUALIZAR Y REGISTRAR CLIENTES
    { path: "/clientes/actualizar/:id", componente: ComponenteActualizarCliente },
    { path: "/clientes/registrar", componente: ComponenteRegistrarCliente },
    { path: "/clientes", componente: ComponenteListarCliente },
    { path: "/", componente: ComponentePrincipal },
    
    //creando un path para rutas no encontradas, esto siempre va al finalizar
    { path: "*", componente: ComponenteRedireccionar },
  ];
  export default rutas;
  