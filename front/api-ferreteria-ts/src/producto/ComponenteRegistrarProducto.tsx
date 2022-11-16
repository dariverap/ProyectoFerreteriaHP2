export default function ComponenteRegistrarProducto() {
    return (
        <div>
            <h1>Registro de Producto</h1>
            <form className="form-control">
                <div className="row">
                    <div className="col-6">
                        <label className="form-label">Nombre:</label>
                        <input type="text" className="form-control" id="txtNom" required />
                    </div>
                </div>
                <div className="row">
                    <div className="col-6">
                        <label className="form-label">Descripción:</label>
                        <input type="text" className="form-control" id="txtApe" required />
                    </div>
                </div>
                <div className="row">
                    <div className="col-6">
                        <label className="form-label">Estado:</label>
                        <div className="col-6 form-check">
                            <input type="checkbox" className="form-check-input" id="chkEst" />
                            <label className="form-check-label"></label>
                        </div>
                    </div>
                </div>
                <div className="row">
                    <div className="col-6">
                        <label className="form-label">Categoría:</label>
                        <input type="text" className="form-control" id="txtNom" required />
                    </div>
                </div>
                <div className="row">
                    <div className="col-6">
                        <button type="submit" className="btn btn-success">
                            Actualizar
                        </button>
                    </div>
                </div>
            </form>
        </div>
    );
}