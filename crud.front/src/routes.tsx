import { Routes, Route } from "react-router-dom";
import ClienteForm from "./pages/Clientes/ClienteForm";
import ClienteList from "./pages/Clientes/ClientesList";

export default function AppRoutes() {
    return (
        <Routes>
            <Route path="/" element={<ClienteList />} />
            <Route path="/novo-cliente" element={<ClienteForm />} />
        </Routes>
    );
}
