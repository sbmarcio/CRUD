export interface ClienteDTO {
  id?: number;
  nome: string;
  endereco: string;
  documento: string;
  email: string;
  telefone: string;
  tipoClienteId: number;
  ativo: boolean;
}