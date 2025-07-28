import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import type { ClienteDTO } from "../../types/ClienteDTO";
import * as yup from "yup";
import FormField from "../../components/FormField";
import { createCliente } from "../../services/clienteService";
import type { SubmitHandler } from "react-hook-form";

const clienteSchema = yup.object().shape({
  nome: yup.string().required("Nome é obrigatório"),
  documento: yup.string().required("Documento é obrigatório"),
  email: yup.string().email("Email inválido").nullable(),
  endereco: yup.string().nullable(),
  telefone: yup.string().nullable(),
  tipoClienteId: yup
    .number()
    .required("Tipo de cliente é obrigatório")
    .typeError("Selecione um tipo válido"),
  ativo: yup.boolean().required(),
});

const initialValues: ClienteDTO = {
  id: 0,
  nome: '',
  documento: '',
  email: '',
  endereco: '',
  telefone: '',
  tipoClienteId: 0,
  ativo: false
};

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

export default function ClienteForm() {

  const { register, handleSubmit, formState: { errors } } = useForm({
    defaultValues: initialValues,
    mode: 'onSubmit',
    resolver: yupResolver(clienteSchema)
  });

  const onSubmit: SubmitHandler<ClienteFormValues> = async (data) => {
    try {
      await createCliente(data);
      alert("Cliente criado com sucesso!");
    } catch (err) {
      console.error(err);
      alert("Erro ao criar cliente.");
    }
  };

  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <FormField label="Nome" error={errors.nome?.message}>
        <input {...register("nome")} />
      </FormField>

      <FormField label="Documento" error={errors.documento?.message}>
        <input {...register("documento")} />
      </FormField>

      <FormField label="Email" error={errors.email?.message}>
        <input type="email" {...register("email")} />
      </FormField>

      <FormField label="Tipo Cliente" error={errors.tipoClienteId?.message}>
        <select {...register("tipoClienteId")}>
          <option value="">Selecione</option>
          <option value="1">Pessoa Física</option>
          <option value="2">Pessoa Jurídica</option>
        </select>
      </FormField>

      <button type="submit">Salvar</button>
    </form>
  );
}
