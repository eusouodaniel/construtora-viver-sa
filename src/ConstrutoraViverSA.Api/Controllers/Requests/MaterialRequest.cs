using ConstrutoraViverSA.Api.Controllers.Validators;
using ConstrutoraViverSA.Domain.Dtos;
using ConstrutoraViverSA.Domain.Enums;
using ConstrutoraViverSA.Domain.Exceptions;

namespace ConstrutoraViverSA.Api.Controllers.Requests;

public class MaterialRequest
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public TipoMaterialEnum? Tipo { get; set; }
    public double? Valor { get; set; }

    public void ValidarCriacao()
    {
        var resultado = new CriarMaterialValidator().Validate(this);

        if (resultado.IsValid == false)
        {
            throw new ErroValidacaoException(resultado.ToString());
        }
    }

    public void ValidarEdicao()
    {
        var resultado = new EditarMaterialValidator().Validate(this);

        if (resultado.IsValid == false)
        {
            throw new ErroValidacaoException(resultado.ToString());
        }
    }
}