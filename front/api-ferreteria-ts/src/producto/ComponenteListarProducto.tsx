import axios from "axios";
import { useEffect, useState } from "react";
import { ProductoDTO } from "./producto.model";

export default function ComponenteListarProducto() {
    const url = "https://localhost:44318/api-ferreteria/producto";
    const [productos, setProductos] = useState<ProductoDTO[]>();
    const peticionesGet = async () => {
        await axios
            .get(url)
            .then((response) => {
                setProductos(response.data);
            })
            .catch((error) => {
                console.log(error);
            });
    };

    useEffect(() => {
        peticionesGet();
    }, []);
    return (
        <div>
            <h1>Lista de Productos</h1>
            <div className="table-responsive">
                <table className="table table-hover table-bordered">
                    <thead className="table-dark">
                        <tr>
                            <th scope="col">Código</th>
                            <th scope="col">Nombre</th>
                            <th scope="col">Descripción</th>
                            <th scope="col">Estado</th>
                            <th scope="col">Categoría</th>
                            <th scope="col"></th>
                            <th scope="col"></th>
                        </tr>
                    </thead>
                    <tbody>
                        {/* se muestra los datos de la tabla */}
                        {productos?.map((productos) => (
                            <tr key={productos.codigo}>
                                <th scope="row">{productos.codigo}</th>
                                
                                <td>{productos.nombre}</td>
                                <td>{productos.descripcion}</td>
                                <td>{productos.estado}</td>
                                <td>{productos.categoria}</td>
                                <td>
                                    <a
                                        href="/productos/actualizar/${productos.codigo}"
                                        className="btn btn-success"
                                    >
                                        Actualizar
                                    </a>
                                </td>
                                <td>
                                    <a href="#" className="btn btn-danger">
                                        Eliminar
                                    </a>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
            <a href="productos/registrar" className="btn btn-primary">
                Registrar Cliente
            </a>
        </div>
    );
}