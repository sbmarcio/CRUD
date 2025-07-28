import { useEffect, useState } from "react";
import { getClientes, deleteCliente } from "../../services/clienteService";

type ClienteFormValues = {
    id?: 0,
    nome: string;
    documento: string;
    tipoClienteId: number;
    ativo: boolean;
    email?: string | null;
    endereco?: string | null;
    telefone?: string | null;
};

export default function ClientesList() {
    const [clientes, setClientes] = useState<ClienteFormValues[]>([]);

    useEffect(() => {
        getClientes().then(setClientes);
    }, []);

    function handleDelete(id: number) {
        if (confirm("Deseja excluir este cliente?")) {
            deleteCliente(id).then(() =>
                setClientes((prev) => prev.filter((c) => c.id !== id))
            );
        }
    }

    return (
        <div>
            <h2>Clientes</h2>
            <ul>
                {clientes.map((cliente) => (
                    <li key={cliente.id}>
                        {cliente.nome} - {cliente.email}
                        <button onClick={() => handleDelete(cliente.id!)}>Excluir</button>
                    </li>
                ))}
            </ul>
        </div>
    );
}
