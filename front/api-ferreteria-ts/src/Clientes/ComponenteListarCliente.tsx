import axios, { AxiosResponse } from "axios";
import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { ClienteDTO } from "./cliente.model";

export default function ComponenteListarCliente() {
  //definimos la direccion del END POINT
  const url = "https://localhost:44318/api-ferreteria/cliente/custom";
  //creamos una variable y una funcion
  //variable --> autores
  //funcion --> setAutores
  const [clientes, setClientes] = useState<ClienteDTO[]>();
  //se realiza la peticion al API por medio del axios
  const peticionesGet = async () => {
    await axios
      .get(url)
      .then((response) => {
        setClientes(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
  };

  //se llama a la peticion
  useEffect(() => {
    peticionesGet();
  }, []);
  ////////////////////////////////////
  return (
    <div>
      <h1>Lista de Clientes</h1>
      <div className="table-responsive">
        <table className="table table-hover table-bordered">
          <thead className="table-dark">
            <tr>
              <th scope="col">Código</th>
              <th scope="col">Nombre</th>
              <th scope="col">Apellido</th>
              <th scope="col">Num° Documento</th>
              <th scope="col">Estado</th>
              <th scope="col"></th>
              <th scope="col"></th>
            </tr>
          </thead>
          <tbody>
            {/* se muestra los datos de la tabla */}
            {clientes?.map((cliente) => (
              <tr key={cliente.codigo}>
                <th scope="row"> {cliente.codigo}</th>
                
                <td>{cliente.nombre}</td>
                <td>{cliente.apellido}</td>
                <td>{cliente.numdocumento}</td>
                <td>{cliente.estado}</td>
                <td>
                  <a
                    href="/clientes/actualizar/${cliente.codigo}"
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

      <a href="clientes/registrar" className="btn btn-primary">
        Registrar Cliente
      </a>
    </div>
  );
}
