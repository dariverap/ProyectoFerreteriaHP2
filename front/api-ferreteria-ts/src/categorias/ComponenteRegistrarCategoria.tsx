export default function ComponenteRegistrarCategoria(){
    return(
        <div>
        <h1>Registro de Categorias</h1>
        <form className="form-control">
            <div className="row">
                <div className="col-6">
                    <label className="form-label">Nombre de la categoría:</label>
                    <input type="text" className="form-control" id="txtnombre" required/>
                </div>
            </div>
            <div className="row">
                <div className="col-6">
                    <label className="form-label">Descripción</label>
                    <input type="text" className="form-control" id="txtdesc" required/>
                </div>
            </div>
            <div className="row">
                <div className="col-6">
                    <label className="form-label">Estado:</label>
                    <div className="col-6 form-check">
                        <input type="checkbox" className="form-check-input" id="chkEst"/>
                        <label className="form-check-label">Habilitado</label>
                    </div>
                </div>
            </div>
            <div className="row">
                <div className="col-6">
                    <button type="submit" className="btn btn-primary">
                        Registrar
                    </button>
                </div>
            </div>
        </form>
    </div>
    )
}