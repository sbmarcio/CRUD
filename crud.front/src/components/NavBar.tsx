import { Link } from "react-router-dom";

export default function Navbar() {
    return (
        <nav style={{ padding: "10px", backgroundColor: "#eee" }}>
            <Link to="/" style={{ marginRight: "10px" }}>Lista de Clientes</Link>
            <Link to="/novo-cliente">Novo Cliente</Link>
        </nav>
    );
}
