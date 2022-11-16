export default function ComponenteRegistrarEmpleado() {
    return (
        <div>
            <h1>Registro de Empleados</h1>
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
                <div className="row">
                    <div className="col-6 mt-4">
                        <button type="submit" className="btn btn-success">
                            Guardar
                        </button>
                    </div>
                </div>
            </form>
        </div>
    )
}