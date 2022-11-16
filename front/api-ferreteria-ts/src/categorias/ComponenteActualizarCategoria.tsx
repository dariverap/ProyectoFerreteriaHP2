import { useParams } from "react-router-dom";

export default function ComponenteActualizarCategoria(){
    const { id }:any = useParams();
    return(
        <div>
        <h1>Actualización de Categorias</h1>
        <h2>El id es: {id} </h2>
        <form className="form-control">
            <div className="row">
                <div className="col-6">
                    <label className="form-label">Nombre de la categoría:</label>
                    <input type="email" className="form-control" id="txtnombre" required/>
                </div>
            </div>
            <div className="row">
                <div className="col-6">
                    <label className="form-label">Descripción</label>
                    <input type="password" className="form-control" id="txtdesc" required/>
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
                        Actualizar
                    </button>
                </div>
            </div>
        </form>
    </div>
    )
}