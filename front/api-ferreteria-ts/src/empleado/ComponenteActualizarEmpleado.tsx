import { useParams } from "react-router-dom";

export default function ComponenteActualizarEmpleado() {
    const { idEmp }: any = useParams();
    return (
        <div>
            <h1>Actualización de Empleados</h1>
            <h2 > El id es: {idEmp}</h2 >
            <form className="form-control">
                <div className="row">
                    <div className="col-6">
                        <label className="form-label">Nombre:</label>
                        <input type="text" className="form-control" id="txtNom" required />
                    </div>
                </div>
                <div className="row">
                    <div className="col-6">
                        <label className="form-label">Apellido:</label>
                        <input type="text" className="form-control" id="txtApe" required />
                    </div>
                </div>
            </form>
        </div>
    )
}