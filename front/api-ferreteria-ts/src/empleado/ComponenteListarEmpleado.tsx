import axios from "axios";
import { useEffect, useState } from "react";
import EmpleadoDTO from "./empleado.model"

export default function ComponenteListarempleado() {
    const url = "https://localhost:44318/api-ferreteria/empleado";
    const [empleados, setEmpleados] = useState<EmpleadoDTO[]>();
    const peticionesGet = async () => {
        await axios
            .get(url)
            .then((response) => {
                setEmpleados(response.data);
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
            <h1>Lista de empleados</h1>
            <div className="table-responsive">
                <table className="table table-hover table-bordered">
                    <thead className="table-dark">
                        <tr>
                            <th scope="col">Código</th>
                            <th scope="col">Nombre</th>
                            <th scope="col">Apellido</th>
                            <th scope="col">Estado</th>
                            <th scope="col"></th>
                            <th scope="col"></th>
                        </tr>
                    </thead>
                    <tbody>
                        {/* se muestra los datos de la tabla */}
                        {empleados?.map((empleado) => (
                            <tr key={empleado.codigo}>
                                <th scope="row">{empleado.codigo}</th>

                                <td>{empleado.nombre}</td>
                                <td>{empleado.apellido}</td>
                                <td>{empleado.estado}</td>
                                <td>
                                    <a
                                        href="/empleados/actualizarEmp/${cliente.codigo}"
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
            <a href="empleados/registrarEmp" className="btn btn-primary">
                Registrar empleado
            </a>
        </div>
    );
}