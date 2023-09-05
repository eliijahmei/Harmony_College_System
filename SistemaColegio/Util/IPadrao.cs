using SistemaColegio.Entidades;
using System.Data;

public interface PessoaModel
{
    void Create(Pessoa pessoa);

    void Update(Pessoa pessoa);

    void Online(Pessoa pessoa);

    void Offline(Pessoa pessoa);

    DataTable Listar();
}
