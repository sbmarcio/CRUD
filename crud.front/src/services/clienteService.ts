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

const baseUrl = "http://localhost:5000/api/cliente";

export async function getClientes(): Promise<ClienteFormValues[]> {
    const res = await fetch(baseUrl);
    return res.json();
}

export async function getCliente(id: number): Promise<ClienteFormValues> {
    const res = await fetch(`${baseUrl}/${id}`);
    return res.json();
}

export async function createCliente(cliente: ClienteFormValues): Promise<number> {
    const res = await fetch(baseUrl, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(cliente),
    });
    const data = await res.json();
    return data.id;
}

export async function updateCliente(cliente: ClienteFormValues): Promise<void> {
    await fetch(`${baseUrl}/${cliente.id}`, {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(cliente),
    });
}

export async function deleteCliente(id: number): Promise<void> {
    await fetch(`${baseUrl}/${id}`, { method: "DELETE" });
}
