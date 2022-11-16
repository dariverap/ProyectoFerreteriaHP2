import axios from "axios";
import { useEffect, useState } from "react";
import { CategoriaDTO } from "./categoria.model";

export default function ComponenteListarCategoria(){

const url = "https://localhost:44318/api-ferreteria/categoria";
//creamos una variable y una funcion
//variable --> autores
//funcion --> setAutores
const [categoria, setCategoria] = useState<CategoriaDTO[]>();
//se realiza la peticion al API por medio del axios
const peticionesGet = async () => {
    await axios
        .get(url)
        .then((response) => {
        setCategoria(response.data);
        })
        .catch((error) => {
        console.log(error);
        });
};

//se llama a la peticion
useEffect(() => {
peticionesGet();
}, []);
////////////////////////////////////////////
    return(
        <div>
        <h1>LISTA DE CATEGORIAS</h1>
        <div className="container table-responsive">
            <table className="table table-bordered  table-hover">
                <thead className="table-dark">
                <tr>
                    <th scope="col">ID</th>
                    <th scope="col">Nombre de la Categoría</th>
                    <th scope="col" className="col-sm-4">Descripción</th>
                    <th scope="col" className="col"></th>
                    <th scope="col" className="col"></th>
                </tr>
                </thead>
                <tbody>
                {/* se muestra los datos de la tabla */}
                {categoria?.map((categoria)=> (
                <tr key={categoria.codigo}>
                    <th scope="row">{categoria.codigo}</th>
                    <td>{categoria.nombre}</td>
                    <td>{categoria.descripcion}</td>
                    <td>
                        <a href="/categoria/actualizar/${categoria.codigo}" className="btn btn-success">Actualizar</a>
                    </td>
                    <td>
                        <a href="" className="btn btn-danger">Eliminar</a>
                    </td>
                </tr>
                ))}                            
                </tbody>
            </table>
        </div>
        <a href="categoria/registrar" className="btn btn-primary">
            Registrar categoria
        </a>
    </div>
    )
}